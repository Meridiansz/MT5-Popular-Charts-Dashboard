using System.Globalization;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private const string DefaultMt5WebSocketUri = "ws://127.0.0.1:8765";

        private static readonly Color ConnectedColor = Color.FromArgb(0, 230, 118);
        private static readonly Color DisconnectedColor = Color.FromArgb(255, 82, 82);
        private static readonly Color ElectricBlue = Color.FromArgb(41, 151, 255);
        private static readonly Color PanelDark = Color.FromArgb(42, 42, 50);
        private static readonly Color PanelDarker = Color.FromArgb(34, 34, 42);
        private static readonly Color SecondaryText = Color.FromArgb(209, 209, 214);
        private static readonly Color WarningGold = Color.FromArgb(255, 193, 7);

        private static readonly string[] AvailableSymbols =
        [
            "EURUSD", "GBPUSD", "USDJPY", "USDCHF", "AUDUSD", "USDCAD",
            "XAUUSD", "XAGUSD", "BTCUSD", "ETHUSD", "SOLUSD", "US30",
            "NAS100", "SPX500", "GER40", "UK100"
        ];

        private static readonly Dictionary<string, decimal> BasePrices = new(StringComparer.OrdinalIgnoreCase)
        {
            ["EURUSD"] = 1.08520m,
            ["GBPUSD"] = 1.27150m,
            ["USDJPY"] = 156.420m,
            ["USDCHF"] = 0.91180m,
            ["AUDUSD"] = 0.66240m,
            ["USDCAD"] = 1.36610m,
            ["XAUUSD"] = 2348.50m,
            ["XAGUSD"] = 31.25m,
            ["BTCUSD"] = 68250.00m,
            ["ETHUSD"] = 3720.00m,
            ["SOLUSD"] = 168.00m,
            ["US30"] = 39280.00m,
            ["NAS100"] = 18840.00m,
            ["SPX500"] = 5320.00m,
            ["GER40"] = 18590.00m,
            ["UK100"] = 8280.00m
        };

        private readonly List<ChartSlot> _chartSlots = [];
        private readonly Dictionary<Panel, List<decimal>> _priceHistory = new();
        private readonly Dictionary<Panel, decimal> _lastPrices = new();
        private readonly List<Button> _timeframeButtons = [];
        private readonly SemaphoreSlim _sessionGate = new(1, 1);
        private readonly Random _random = new();

        private ClientWebSocket? _webSocket;
        private CancellationTokenSource? _streamCancellation;
        private Task? _listenTask;
        private string _selectedTimeframe = "D1";
        private bool _isLoggedIn;
        private bool _allowFormClose;

        public Form1()
        {
            InitializeComponent();
            StatusDotPanel_Resize(statusDotPanel, EventArgs.Empty);
            RegisterDashboardControls();
            InitializeSymbolSelectors();
            ApplyTimeframeSelection();
            SetLoggedOutUi();
            UpdateClock();
            clockTimer.Start();
        }

        private async void BtnConnect_Click(object? sender, EventArgs e)
        {
            await _sessionGate.WaitAsync();

            try
            {
                if (_isLoggedIn)
                {
                    await LogoutAsync();
                    return;
                }

                await LoginAsync();
            }
            finally
            {
                _sessionGate.Release();
            }
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(txtAccountId.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    this,
                    "MT5 Account ID and password are required.",
                    "Missing Login Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SetLoggingInUi();
            await Task.Delay(350);

            var accountId = txtAccountId.Text.Trim();
            var password = txtPassword.Text;

            _isLoggedIn = true;
            SetLoggedInUi();
            SeedCharts();
            marketTimer.Start();

            _streamCancellation = new CancellationTokenSource();
            _listenTask = Task.Run(() => TryConnectToMt5BackendAsync(accountId, password, _streamCancellation.Token));
        }

        private async Task LogoutAsync()
        {
            SetLoggingOutUi();
            marketTimer.Stop();
            await DisconnectBackendAsync();
            _isLoggedIn = false;
            ClearCharts();
            SetLoggedOutUi();
        }

        private async Task TryConnectToMt5BackendAsync(string accountId, string password, CancellationToken cancellationToken)
        {
            var socket = new ClientWebSocket
            {
                Options =
                {
                    KeepAliveInterval = TimeSpan.FromSeconds(20)
                }
            };

            try
            {
                using var connectTimeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                connectTimeout.CancelAfter(TimeSpan.FromSeconds(3));

                await socket.ConnectAsync(new Uri(DefaultMt5WebSocketUri), connectTimeout.Token);
                _webSocket = socket;

                await SendLoginPayloadAsync(socket, accountId, password, cancellationToken);
                await SendSubscriptionAsync(cancellationToken);
                await ListenToMT5Stream(socket, cancellationToken);
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or UriFormatException or IOException or InvalidOperationException)
            {
                socket.Dispose();
            }
        }

        private async Task ListenToMT5Stream(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            var buffer = new byte[8192];

            try
            {
                while (!cancellationToken.IsCancellationRequested && socket.State == WebSocketState.Open)
                {
                    using var messageStream = new MemoryStream();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            return;
                        }

                        messageStream.Write(buffer, 0, result.Count);
                    }
                    while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var json = Encoding.UTF8.GetString(messageStream.ToArray());
                        ProcessMt5Message(json);
                    }
                }
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException or IOException)
            {
            }
            finally
            {
                if (ReferenceEquals(_webSocket, socket))
                {
                    _webSocket = null;
                }

                socket.Dispose();
            }
        }

        private async Task DisconnectBackendAsync()
        {
            var socket = _webSocket;
            var cancellation = _streamCancellation;

            _webSocket = null;
            _streamCancellation = null;
            cancellation?.Cancel();

            if (socket is not null)
            {
                try
                {
                    if (socket.State is WebSocketState.Open or WebSocketState.CloseReceived)
                    {
                        using var closeTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Session closed", closeTimeout.Token);
                    }
                }
                catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
                {
                }
                finally
                {
                    socket.Dispose();
                }
            }

            cancellation?.Dispose();
            _listenTask = null;
        }

        private async Task SendLoginPayloadAsync(ClientWebSocket socket, string accountId, string password, CancellationToken cancellationToken)
        {
            if (socket.State != WebSocketState.Open)
            {
                return;
            }

            var payload = JsonSerializer.Serialize(new
            {
                action = "login",
                accountId,
                password
            });

            await SendJsonAsync(socket, payload, cancellationToken);
        }

        private async Task SendSubscriptionAsync(CancellationToken cancellationToken)
        {
            var socket = _webSocket;
            if (socket is null || socket.State != WebSocketState.Open)
            {
                return;
            }

            var payload = JsonSerializer.Serialize(new
            {
                action = "subscribe",
                timeframe = _selectedTimeframe,
                symbols = GetCurrentSymbols()
            });

            await SendJsonAsync(socket, payload, cancellationToken);
        }

        private static async Task SendJsonAsync(ClientWebSocket socket, string payload, CancellationToken cancellationToken)
        {
            var bytes = Encoding.UTF8.GetBytes(payload);
            await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, cancellationToken);
        }

        private void ProcessMt5Message(string json)
        {
            try
            {
                using var document = JsonDocument.Parse(json);
                ProcessJsonElement(document.RootElement);
            }
            catch (JsonException)
            {
            }
        }

        private void ProcessJsonElement(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    ProcessJsonElement(item);
                }

                return;
            }

            if (element.ValueKind != JsonValueKind.Object)
            {
                return;
            }

            if (TryGetPropertyIgnoreCase(element, "data", out var dataElement))
            {
                ProcessJsonElement(dataElement);
            }

            var symbol = ReadStringProperty(element, "symbol", "Symbol", "asset", "pair", "instrument");
            if (!string.IsNullOrWhiteSpace(symbol) && TryReadPrice(element, out var price))
            {
                UpdateSymbolPrice(symbol, price);
                return;
            }

            foreach (var property in element.EnumerateObject())
            {
                var normalizedSymbol = NormalizeSymbol(property.Name);
                if (TryReadQuoteValue(property.Value, out var nestedPrice))
                {
                    UpdateSymbolPrice(normalizedSymbol, nestedPrice);
                }
            }
        }

        private async void TimeframeButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button button || button.Tag is not string timeframe)
            {
                return;
            }

            _selectedTimeframe = timeframe;
            ApplyTimeframeSelection();
            ResetAllChartHistory();

            try
            {
                await SendSubscriptionAsync(_streamCancellation?.Token ?? CancellationToken.None);
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
            {
            }
        }

        private void SymbolCombo_TextChanged(object? sender, EventArgs e)
        {
            if (sender is not ComboBox comboBox)
            {
                return;
            }

            var slot = _chartSlots.FirstOrDefault(item => ReferenceEquals(item.SymbolSelector, comboBox));
            if (slot is null)
            {
                return;
            }

            ResetSlot(slot);

            _ = SendSubscriptionSafeAsync();
        }

        private void MarketTimer_Tick(object? sender, EventArgs e)
        {
            if (!_isLoggedIn)
            {
                return;
            }

            foreach (var slot in _chartSlots)
            {
                var symbol = NormalizeSymbol(slot.SymbolSelector.Text);
                if (string.IsNullOrWhiteSpace(symbol))
                {
                    slot.PriceLabel.Text = "--.--";
                    slot.ChangeLabel.Text = "Symbol required";
                    slot.TrendPanel.Invalidate();
                    continue;
                }

                var currentPrice = _lastPrices.TryGetValue(slot.TrendPanel, out var knownPrice)
                    ? knownPrice
                    : GetBasePrice(symbol);

                var nextPrice = GenerateNextPrice(symbol, currentPrice);
                ApplyPriceToSlot(slot, symbol, nextPrice);
            }
        }

        private async Task SendSubscriptionSafeAsync()
        {
            try
            {
                await SendSubscriptionAsync(_streamCancellation?.Token ?? CancellationToken.None);
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
            {
            }
        }

        private void ClockTimer_Tick(object? sender, EventArgs e)
        {
            UpdateClock();
        }

        private void SymbolCombo_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not ComboBox comboBox || e.Index < 0)
            {
                return;
            }

            var symbol = comboBox.GetItemText(comboBox.Items[e.Index]) ?? string.Empty;
            var isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var accentColor = GetSymbolAccentColor(symbol);
            var backgroundColor = isSelected ? Color.FromArgb(48, 68, 90) : Color.FromArgb(24, 24, 31);

            using var backgroundBrush = new SolidBrush(backgroundColor);
            using var accentBrush = new SolidBrush(accentColor);
            using var textBrush = new SolidBrush(Color.White);
            using var subTextBrush = new SolidBrush(Color.FromArgb(160, 209, 209, 214));
            using var categoryFont = new Font("Segoe UI", 7.5f, FontStyle.Bold);

            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            e.Graphics.FillRectangle(accentBrush, e.Bounds.Left + 6, e.Bounds.Top + 7, 4, Math.Max(6, e.Bounds.Height - 14));
            e.Graphics.DrawString(symbol, comboBox.Font, textBrush, e.Bounds.Left + 18, e.Bounds.Top + 5);
            e.Graphics.DrawString(GetSymbolCategory(symbol), categoryFont, subTextBrush, e.Bounds.Right - 78, e.Bounds.Top + 8);
            e.DrawFocusRectangle();
        }

        private void ChartPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(PanelDarker);

            using var gridPen = new Pen(Color.FromArgb(28, 255, 255, 255), 1);
            for (var i = 1; i < 4; i++)
            {
                var y = panel.Height * i / 4;
                e.Graphics.DrawLine(gridPen, 0, y, panel.Width, y);
            }

            if (!_priceHistory.TryGetValue(panel, out var history) || history.Count < 2)
            {
                DrawPlaceholderTrend(panel, e.Graphics);
                return;
            }

            var points = BuildTrendPoints(panel.ClientRectangle, history);
            var positiveMove = history[^1] >= history[0];
            var lineColor = positiveMove ? ConnectedColor : DisconnectedColor;

            using var glowPen = new Pen(Color.FromArgb(70, lineColor), 8)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            using var linePen = new Pen(lineColor, 2.5f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            e.Graphics.DrawLines(glowPen, points);
            e.Graphics.DrawLines(linePen, points);
        }

        private void CardPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var borderPen = new Pen(Color.FromArgb(38, 255, 255, 255), 1);
            using var accentPen = new Pen(Color.FromArgb(140, ElectricBlue), 2);

            var bounds = panel.ClientRectangle;
            bounds.Width -= 1;
            bounds.Height -= 1;
            e.Graphics.DrawRectangle(borderPen, bounds);
            e.Graphics.DrawLine(accentPen, 18, 0, Math.Min(panel.Width - 18, 165), 0);
        }

        private void StatusDotPanel_Resize(object? sender, EventArgs e)
        {
            if (sender is not Panel panel || panel.Width <= 0 || panel.Height <= 0)
            {
                return;
            }

            using var path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width - 1, panel.Height - 1);
            panel.Region?.Dispose();
            panel.Region = new Region(path);
        }

        private async void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_allowFormClose)
            {
                return;
            }

            e.Cancel = true;
            Enabled = false;

            try
            {
                marketTimer.Stop();
                clockTimer.Stop();
                await DisconnectBackendAsync();
            }
            finally
            {
                _allowFormClose = true;
                Close();
            }
        }

        private void RegisterDashboardControls()
        {
            _chartSlots.AddRange(
            [
                new ChartSlot(cmbSymbol1, lblPrice1, lblChange1, pnlTrend1),
                new ChartSlot(cmbSymbol2, lblPrice2, lblChange2, pnlTrend2),
                new ChartSlot(cmbSymbol3, lblPrice3, lblChange3, pnlTrend3),
                new ChartSlot(cmbSymbol4, lblPrice4, lblChange4, pnlTrend4)
            ]);

            foreach (var slot in _chartSlots)
            {
                _priceHistory[slot.TrendPanel] = [];
            }

            _timeframeButtons.AddRange([btnDaily, btnWeekly, btnMonthly, btnYearly]);
        }

        private void InitializeSymbolSelectors()
        {
            var defaults = new[] { "EURUSD", "XAUUSD", "BTCUSD", "GBPUSD" };

            for (var i = 0; i < _chartSlots.Count; i++)
            {
                var selector = _chartSlots[i].SymbolSelector;
                selector.Items.AddRange(AvailableSymbols);
                selector.Text = defaults[i];
                selector.Tag = defaults[i];
            }
        }

        private void SeedCharts()
        {
            foreach (var slot in _chartSlots)
            {
                ResetSlot(slot);
                var symbol = NormalizeSymbol(slot.SymbolSelector.Text);
                var price = GetBasePrice(symbol);

                for (var i = 0; i < 18; i++)
                {
                    price = GenerateNextPrice(symbol, price);
                    ApplyPriceToSlot(slot, symbol, price);
                }
            }
        }

        private void ClearCharts()
        {
            foreach (var slot in _chartSlots)
            {
                _priceHistory[slot.TrendPanel].Clear();
                _lastPrices.Remove(slot.TrendPanel);
                slot.PriceLabel.Text = "--.--";
                slot.ChangeLabel.Text = "Awaiting login";
                slot.ChangeLabel.ForeColor = SecondaryText;
                slot.TrendPanel.Invalidate();
            }
        }

        private void ResetSlot(ChartSlot slot)
        {
            _priceHistory[slot.TrendPanel].Clear();
            _lastPrices.Remove(slot.TrendPanel);
            slot.TrendPanel.Tag = NormalizeSymbol(slot.SymbolSelector.Text);
            slot.PriceLabel.Text = "--.--";
            slot.ChangeLabel.Text = _isLoggedIn ? "Preparing chart" : "Awaiting login";
            slot.ChangeLabel.ForeColor = SecondaryText;
            slot.TrendPanel.Invalidate();
        }

        private void ResetAllChartHistory()
        {
            foreach (var slot in _chartSlots)
            {
                ResetSlot(slot);
            }

            if (_isLoggedIn)
            {
                SeedCharts();
            }
        }

        private void ApplyPriceToSlot(ChartSlot slot, string symbol, decimal price)
        {
            var history = _priceHistory[slot.TrendPanel];
            var previous = history.Count > 0 ? history[^1] : price;

            history.Add(price);
            if (history.Count > 80)
            {
                history.RemoveRange(0, history.Count - 80);
            }

            _lastPrices[slot.TrendPanel] = price;
            slot.PriceLabel.Text = FormatPrice(symbol, price);

            var changePercent = previous == 0 ? 0 : (price - previous) / previous * 100;
            slot.ChangeLabel.Text = $"{changePercent:+0.00;-0.00;0.00}%  {_selectedTimeframe}";
            slot.ChangeLabel.ForeColor = changePercent >= 0 ? ConnectedColor : DisconnectedColor;
            slot.TrendPanel.Tag = symbol;
            slot.TrendPanel.Invalidate();
        }

        private void UpdateSymbolPrice(string symbol, decimal price)
        {
            var normalizedSymbol = NormalizeSymbol(symbol);

            RunOnUiThread(() =>
            {
                foreach (var slot in _chartSlots)
                {
                    if (string.Equals(NormalizeSymbol(slot.SymbolSelector.Text), normalizedSymbol, StringComparison.OrdinalIgnoreCase))
                    {
                        ApplyPriceToSlot(slot, normalizedSymbol, price);
                    }
                }
            });
        }

        private decimal GenerateNextPrice(string symbol, decimal currentPrice)
        {
            var volatility = GetVolatility(symbol) * GetTimeframeMultiplier();
            var direction = (decimal)(_random.NextDouble() - 0.48);
            var change = currentPrice * volatility * direction;

            return Math.Max(0.00001m, currentPrice + change);
        }

        private decimal GetTimeframeMultiplier()
        {
            return _selectedTimeframe switch
            {
                "W1" => 1.8m,
                "MN" => 2.7m,
                "Y1" => 4.2m,
                _ => 1.0m
            };
        }

        private static decimal GetVolatility(string symbol)
        {
            return symbol switch
            {
                "BTCUSD" or "ETHUSD" or "SOLUSD" => 0.006m,
                "NAS100" or "US30" or "SPX500" or "GER40" or "UK100" => 0.0025m,
                "XAUUSD" or "XAGUSD" => 0.002m,
                _ => 0.0008m
            };
        }

        private static decimal GetBasePrice(string symbol)
        {
            return BasePrices.TryGetValue(symbol, out var basePrice) ? basePrice : 100.00m;
        }

        private IReadOnlyList<string> GetCurrentSymbols()
        {
            return _chartSlots
                .Select(slot => NormalizeSymbol(slot.SymbolSelector.Text))
                .Where(symbol => !string.IsNullOrWhiteSpace(symbol))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();
        }

        private void ApplyTimeframeSelection()
        {
            foreach (var button in _timeframeButtons)
            {
                var isSelected = string.Equals(button.Tag as string, _selectedTimeframe, StringComparison.OrdinalIgnoreCase);
                var accentColor = GetTimeframeAccentColor(button.Tag as string);
                button.BackColor = isSelected ? accentColor : Color.FromArgb(28, 28, 36);
                button.ForeColor = Color.White;
                button.FlatAppearance.BorderColor = isSelected ? accentColor : Color.FromArgb(58, 58, 70);
                button.FlatAppearance.MouseOverBackColor = isSelected ? accentColor : Color.FromArgb(42, 42, 54);
            }

            lblSelectedRange.Text = $"Active range: {_selectedTimeframe}";
        }

        private void SetLoggingInUi()
        {
            btnConnect.Enabled = false;
            txtAccountId.Enabled = false;
            txtPassword.Enabled = false;
            statusDotPanel.BackColor = WarningGold;
            lblStatus.Text = "Validating login...";
            lblLoginNotice.Text = "Preparing session";
            lblLoginNotice.ForeColor = WarningGold;
            btnConnect.Text = "Signing In...";
        }

        private void SetLoggedInUi()
        {
            btnConnect.Enabled = true;
            txtAccountId.Enabled = false;
            txtPassword.Enabled = false;
            statusDotPanel.BackColor = ConnectedColor;
            lblStatus.Text = "Account active";
            lblLoginNotice.Text = $"Login approved  |  ID: {txtAccountId.Text.Trim()}";
            lblLoginNotice.ForeColor = ConnectedColor;
            btnConnect.Text = "Sign Out";
        }

        private void SetLoggingOutUi()
        {
            btnConnect.Enabled = false;
            statusDotPanel.BackColor = WarningGold;
            lblStatus.Text = "Closing session...";
            lblLoginNotice.Text = "Closing session";
            lblLoginNotice.ForeColor = WarningGold;
            btnConnect.Text = "Closing...";
        }

        private void SetLoggedOutUi()
        {
            btnConnect.Enabled = true;
            txtAccountId.Enabled = true;
            txtPassword.Enabled = true;
            statusDotPanel.BackColor = DisconnectedColor;
            lblStatus.Text = "Awaiting login";
            lblLoginNotice.Text = "Awaiting account login";
            lblLoginNotice.ForeColor = SecondaryText;
            btnConnect.Text = "Sign In";
        }

        private void UpdateClock()
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
        }

        private static string NormalizeSymbol(string symbol)
        {
            return symbol.Trim().ToUpperInvariant();
        }

        private static string FormatPrice(string symbol, decimal price)
        {
            var format = symbol switch
            {
                "BTCUSD" or "ETHUSD" or "SOLUSD" => "N2",
                "XAUUSD" or "XAGUSD" => "N2",
                "US30" or "NAS100" or "SPX500" or "GER40" or "UK100" => "N2",
                "USDJPY" => "N3",
                _ => "N5"
            };

            return price.ToString(format, CultureInfo.InvariantCulture);
        }

        private static Color GetTimeframeAccentColor(string? timeframe)
        {
            return timeframe switch
            {
                "D1" => Color.FromArgb(41, 151, 255),
                "W1" => Color.FromArgb(0, 230, 118),
                "MN" => Color.FromArgb(155, 89, 255),
                "Y1" => Color.FromArgb(255, 149, 0),
                _ => ElectricBlue
            };
        }

        private static Color GetSymbolAccentColor(string symbol)
        {
            return NormalizeSymbol(symbol) switch
            {
                "BTCUSD" or "ETHUSD" or "SOLUSD" => Color.FromArgb(255, 149, 0),
                "XAUUSD" or "XAGUSD" => Color.FromArgb(255, 214, 10),
                "US30" or "NAS100" or "SPX500" or "GER40" or "UK100" => Color.FromArgb(155, 89, 255),
                _ => ElectricBlue
            };
        }

        private static string GetSymbolCategory(string symbol)
        {
            return NormalizeSymbol(symbol) switch
            {
                "BTCUSD" or "ETHUSD" or "SOLUSD" => "CRYPTO",
                "XAUUSD" or "XAGUSD" => "METAL",
                "US30" or "NAS100" or "SPX500" or "GER40" or "UK100" => "INDEX",
                _ => "FX"
            };
        }

        private static bool TryReadQuoteValue(JsonElement element, out decimal price)
        {
            if (TryReadDecimal(element, out price))
            {
                return true;
            }

            if (element.ValueKind == JsonValueKind.Object && TryReadPrice(element, out price))
            {
                return true;
            }

            price = default;
            return false;
        }

        private static bool TryReadPrice(JsonElement element, out decimal price)
        {
            return TryReadDecimalProperty(element, out price, "price", "currentPrice", "bid", "ask", "last", "close", "value");
        }

        private static bool TryReadDecimalProperty(JsonElement element, out decimal value, params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                if (TryGetPropertyIgnoreCase(element, propertyName, out var property) && TryReadDecimal(property, out value))
                {
                    return true;
                }
            }

            value = default;
            return false;
        }

        private static bool TryReadDecimal(JsonElement element, out decimal value)
        {
            if (element.ValueKind == JsonValueKind.Number && element.TryGetDecimal(out value))
            {
                return true;
            }

            if (element.ValueKind == JsonValueKind.String)
            {
                var text = element.GetString();
                if (decimal.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                {
                    return true;
                }
            }

            value = default;
            return false;
        }

        private static string? ReadStringProperty(JsonElement element, params string[] propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                if (TryGetPropertyIgnoreCase(element, propertyName, out var property) && property.ValueKind == JsonValueKind.String)
                {
                    return property.GetString();
                }
            }

            return null;
        }

        private static bool TryGetPropertyIgnoreCase(JsonElement element, string propertyName, out JsonElement property)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                foreach (var candidate in element.EnumerateObject())
                {
                    if (string.Equals(candidate.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                    {
                        property = candidate.Value;
                        return true;
                    }
                }
            }

            property = default;
            return false;
        }

        private static PointF[] BuildTrendPoints(Rectangle bounds, IReadOnlyList<decimal> history)
        {
            var min = history.Min();
            var max = history.Max();
            var range = max - min;

            if (range == 0)
            {
                range = 1;
            }

            var points = new PointF[history.Count];
            var usableWidth = Math.Max(1, bounds.Width - 20);
            var usableHeight = Math.Max(1, bounds.Height - 20);

            for (var i = 0; i < history.Count; i++)
            {
                var x = bounds.Left + 10 + usableWidth * i / Math.Max(1, history.Count - 1);
                var normalized = (float)((history[i] - min) / range);
                var y = bounds.Top + 10 + usableHeight * (1 - normalized);
                points[i] = new PointF(x, y);
            }

            return points;
        }

        private void DrawPlaceholderTrend(Panel panel, Graphics graphics)
        {
            var points = new[]
            {
                new PointF(12, panel.Height * 0.66f),
                new PointF(panel.Width * 0.22f, panel.Height * 0.54f),
                new PointF(panel.Width * 0.42f, panel.Height * 0.61f),
                new PointF(panel.Width * 0.62f, panel.Height * 0.37f),
                new PointF(panel.Width * 0.82f, panel.Height * 0.44f),
                new PointF(panel.Width - 12, panel.Height * 0.25f)
            };

            using var placeholderPen = new Pen(Color.FromArgb(120, ElectricBlue), 2)
            {
                DashStyle = DashStyle.Dash,
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            using var textBrush = new SolidBrush(Color.FromArgb(130, SecondaryText));
            using var font = new Font("Segoe UI", 8.5f, FontStyle.Regular);

            graphics.DrawLines(placeholderPen, points);
            graphics.DrawString(_isLoggedIn ? "Preparing market data" : "Sign in to activate chart", font, textBrush, 12, panel.Height - 26);
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed || Disposing)
            {
                return;
            }

            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke(action);
                    return;
                }

                action();
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void DisposeRuntimeResources()
        {
            try
            {
                marketTimer?.Stop();
                clockTimer?.Stop();
                _streamCancellation?.Cancel();
            }
            catch (ObjectDisposedException)
            {
            }

            _webSocket?.Dispose();
            _streamCancellation?.Dispose();
            _sessionGate.Dispose();
        }

        private sealed record ChartSlot(ComboBox SymbolSelector, Label PriceLabel, Label ChangeLabel, Panel TrendPanel);
    }
}
