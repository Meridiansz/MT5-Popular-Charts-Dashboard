namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeRuntimeResources();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            topPanel = new Panel();
            loginPanel = new Panel();
            btnConnect = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtAccountId = new TextBox();
            lblAccountId = new Label();
            lblLoginTitle = new Label();
            lblStatus = new Label();
            statusDotPanel = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            sidebarPanel = new Panel();
            lblSelectedRange = new Label();
            btnYearly = new Button();
            btnMonthly = new Button();
            btnWeekly = new Button();
            btnDaily = new Button();
            lblTimeframesSubtitle = new Label();
            lblTimeframes = new Label();
            mainDashboardPanel = new Panel();
            rangePanel = new Panel();
            cardGridPanel = new TableLayoutPanel();
            pnlCard1 = new Panel();
            pnlTrend1 = new Panel();
            lblChange1 = new Label();
            lblPrice1 = new Label();
            lblPriceCaption1 = new Label();
            cmbSymbol1 = new ComboBox();
            lblCardKicker1 = new Label();
            pnlCard2 = new Panel();
            pnlTrend2 = new Panel();
            lblChange2 = new Label();
            lblPrice2 = new Label();
            lblPriceCaption2 = new Label();
            cmbSymbol2 = new ComboBox();
            lblCardKicker2 = new Label();
            pnlCard3 = new Panel();
            pnlTrend3 = new Panel();
            lblChange3 = new Label();
            lblPrice3 = new Label();
            lblPriceCaption3 = new Label();
            cmbSymbol3 = new ComboBox();
            lblCardKicker3 = new Label();
            pnlCard4 = new Panel();
            pnlTrend4 = new Panel();
            lblChange4 = new Label();
            lblPrice4 = new Label();
            lblPriceCaption4 = new Label();
            cmbSymbol4 = new ComboBox();
            lblCardKicker4 = new Label();
            bottomStatusPanel = new Panel();
            lblClock = new Label();
            lblLoginNotice = new Label();
            clockTimer = new System.Windows.Forms.Timer(components);
            marketTimer = new System.Windows.Forms.Timer(components);
            topPanel.SuspendLayout();
            loginPanel.SuspendLayout();
            sidebarPanel.SuspendLayout();
            mainDashboardPanel.SuspendLayout();
            rangePanel.SuspendLayout();
            cardGridPanel.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            bottomStatusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(35, 35, 43);
            topPanel.Controls.Add(loginPanel);
            topPanel.Controls.Add(lblStatus);
            topPanel.Controls.Add(statusDotPanel);
            topPanel.Controls.Add(lblSubtitle);
            topPanel.Controls.Add(lblTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(26, 14, 26, 14);
            topPanel.Size = new Size(1240, 112);
            topPanel.TabIndex = 0;
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loginPanel.BackColor = Color.FromArgb(42, 42, 50);
            loginPanel.Controls.Add(btnConnect);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Controls.Add(txtAccountId);
            loginPanel.Controls.Add(lblAccountId);
            loginPanel.Controls.Add(lblLoginTitle);
            loginPanel.Location = new Point(679, 16);
            loginPanel.Name = "loginPanel";
            loginPanel.Padding = new Padding(14);
            loginPanel.Size = new Size(535, 80);
            loginPanel.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.BackColor = Color.FromArgb(41, 151, 255);
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatAppearance.BorderColor = Color.FromArgb(41, 151, 255);
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 113, 210);
            btnConnect.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 166, 255);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(393, 31);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(128, 32);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Sign In";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += BtnConnect_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(30, 30, 36);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(252, 36);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(122, 24);
            txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(209, 209, 214);
            lblPassword.Location = new Point(252, 18);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 13);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "PASSWORD";
            // 
            // txtAccountId
            // 
            txtAccountId.BackColor = Color.FromArgb(30, 30, 36);
            txtAccountId.BorderStyle = BorderStyle.FixedSingle;
            txtAccountId.Font = new Font("Segoe UI", 9.5F);
            txtAccountId.ForeColor = Color.White;
            txtAccountId.Location = new Point(111, 36);
            txtAccountId.Name = "txtAccountId";
            txtAccountId.PlaceholderText = "MT5 Account ID";
            txtAccountId.Size = new Size(122, 24);
            txtAccountId.TabIndex = 2;
            // 
            // lblAccountId
            // 
            lblAccountId.AutoSize = true;
            lblAccountId.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblAccountId.ForeColor = Color.FromArgb(209, 209, 214);
            lblAccountId.Location = new Point(111, 18);
            lblAccountId.Name = "lblAccountId";
            lblAccountId.Size = new Size(84, 13);
            lblAccountId.TabIndex = 1;
            lblAccountId.Text = "MT5 ACCOUNT ID";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.White;
            lblLoginTitle.Location = new Point(14, 37);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(76, 19);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Account Login";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(209, 209, 214);
            lblStatus.Location = new Point(50, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 19);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Awaiting login";
            // 
            // statusDotPanel
            // 
            statusDotPanel.BackColor = Color.FromArgb(255, 82, 82);
            statusDotPanel.Location = new Point(29, 79);
            statusDotPanel.Name = "statusDotPanel";
            statusDotPanel.Size = new Size(12, 12);
            statusDotPanel.TabIndex = 2;
            statusDotPanel.Resize += StatusDotPanel_Resize;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(209, 209, 214);
            lblSubtitle.Location = new Point(30, 49);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(346, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Multi timeframe trend analysis and live market watch";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(26, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MT5 Popular Charts Dashboard";
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(25, 25, 31);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 112);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(24, 28, 24, 24);
            sidebarPanel.Size = new Size(0, 648);
            sidebarPanel.TabIndex = 1;
            // 
            // lblSelectedRange
            // 
            lblSelectedRange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedRange.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSelectedRange.ForeColor = Color.FromArgb(209, 209, 214);
            lblSelectedRange.Location = new Point(1022, 34);
            lblSelectedRange.Name = "lblSelectedRange";
            lblSelectedRange.Size = new Size(146, 22);
            lblSelectedRange.TabIndex = 6;
            lblSelectedRange.Text = "Active range: D1";
            lblSelectedRange.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnYearly
            // 
            btnYearly.BackColor = Color.FromArgb(42, 42, 50);
            btnYearly.Cursor = Cursors.Hand;
            btnYearly.FlatAppearance.BorderColor = Color.FromArgb(62, 62, 74);
            btnYearly.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 151, 255);
            btnYearly.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 52, 62);
            btnYearly.FlatStyle = FlatStyle.Flat;
            btnYearly.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnYearly.ForeColor = Color.White;
            btnYearly.Location = new Point(820, 24);
            btnYearly.Name = "btnYearly";
            btnYearly.Size = new Size(116, 38);
            btnYearly.TabIndex = 5;
            btnYearly.Tag = "Y1";
            btnYearly.Text = "Yearly  Y1";
            btnYearly.TextAlign = ContentAlignment.MiddleCenter;
            btnYearly.UseVisualStyleBackColor = false;
            btnYearly.Click += TimeframeButton_Click;
            // 
            // btnMonthly
            // 
            btnMonthly.BackColor = Color.FromArgb(42, 42, 50);
            btnMonthly.Cursor = Cursors.Hand;
            btnMonthly.FlatAppearance.BorderColor = Color.FromArgb(62, 62, 74);
            btnMonthly.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 151, 255);
            btnMonthly.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 52, 62);
            btnMonthly.FlatStyle = FlatStyle.Flat;
            btnMonthly.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnMonthly.ForeColor = Color.White;
            btnMonthly.Location = new Point(696, 24);
            btnMonthly.Name = "btnMonthly";
            btnMonthly.Size = new Size(116, 38);
            btnMonthly.TabIndex = 4;
            btnMonthly.Tag = "MN";
            btnMonthly.Text = "Monthly  MN";
            btnMonthly.TextAlign = ContentAlignment.MiddleCenter;
            btnMonthly.UseVisualStyleBackColor = false;
            btnMonthly.Click += TimeframeButton_Click;
            // 
            // btnWeekly
            // 
            btnWeekly.BackColor = Color.FromArgb(42, 42, 50);
            btnWeekly.Cursor = Cursors.Hand;
            btnWeekly.FlatAppearance.BorderColor = Color.FromArgb(62, 62, 74);
            btnWeekly.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 151, 255);
            btnWeekly.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 52, 62);
            btnWeekly.FlatStyle = FlatStyle.Flat;
            btnWeekly.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnWeekly.ForeColor = Color.White;
            btnWeekly.Location = new Point(572, 24);
            btnWeekly.Name = "btnWeekly";
            btnWeekly.Size = new Size(116, 38);
            btnWeekly.TabIndex = 3;
            btnWeekly.Tag = "W1";
            btnWeekly.Text = "Weekly  W1";
            btnWeekly.TextAlign = ContentAlignment.MiddleCenter;
            btnWeekly.UseVisualStyleBackColor = false;
            btnWeekly.Click += TimeframeButton_Click;
            // 
            // btnDaily
            // 
            btnDaily.BackColor = Color.FromArgb(41, 151, 255);
            btnDaily.Cursor = Cursors.Hand;
            btnDaily.FlatAppearance.BorderColor = Color.FromArgb(41, 151, 255);
            btnDaily.FlatAppearance.MouseDownBackColor = Color.FromArgb(22, 113, 210);
            btnDaily.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 166, 255);
            btnDaily.FlatStyle = FlatStyle.Flat;
            btnDaily.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnDaily.ForeColor = Color.White;
            btnDaily.Location = new Point(448, 24);
            btnDaily.Name = "btnDaily";
            btnDaily.Size = new Size(116, 38);
            btnDaily.TabIndex = 2;
            btnDaily.Tag = "D1";
            btnDaily.Text = "Daily  D1";
            btnDaily.TextAlign = ContentAlignment.MiddleCenter;
            btnDaily.UseVisualStyleBackColor = false;
            btnDaily.Click += TimeframeButton_Click;
            // 
            // lblTimeframesSubtitle
            // 
            lblTimeframesSubtitle.Font = new Font("Segoe UI", 9F);
            lblTimeframesSubtitle.ForeColor = Color.FromArgb(152, 152, 164);
            lblTimeframesSubtitle.Location = new Point(24, 43);
            lblTimeframesSubtitle.Name = "lblTimeframesSubtitle";
            lblTimeframesSubtitle.Size = new Size(330, 21);
            lblTimeframesSubtitle.TabIndex = 1;
            lblTimeframesSubtitle.Text = "Minimal timeframe control for market trend focus";
            // 
            // lblTimeframes
            // 
            lblTimeframes.AutoSize = true;
            lblTimeframes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTimeframes.ForeColor = Color.White;
            lblTimeframes.Location = new Point(24, 18);
            lblTimeframes.Name = "lblTimeframes";
            lblTimeframes.Size = new Size(116, 21);
            lblTimeframes.TabIndex = 0;
            lblTimeframes.Text = "Analysis Range";
            // 
            // mainDashboardPanel
            // 
            mainDashboardPanel.BackColor = Color.FromArgb(30, 30, 36);
            mainDashboardPanel.Controls.Add(cardGridPanel);
            mainDashboardPanel.Controls.Add(rangePanel);
            mainDashboardPanel.Controls.Add(bottomStatusPanel);
            mainDashboardPanel.Dock = DockStyle.Fill;
            mainDashboardPanel.Location = new Point(0, 112);
            mainDashboardPanel.Name = "mainDashboardPanel";
            mainDashboardPanel.Padding = new Padding(24, 24, 24, 16);
            mainDashboardPanel.Size = new Size(1240, 648);
            mainDashboardPanel.TabIndex = 2;
            // 
            // rangePanel
            // 
            rangePanel.BackColor = Color.FromArgb(35, 35, 43);
            rangePanel.Controls.Add(lblSelectedRange);
            rangePanel.Controls.Add(btnYearly);
            rangePanel.Controls.Add(btnMonthly);
            rangePanel.Controls.Add(btnWeekly);
            rangePanel.Controls.Add(btnDaily);
            rangePanel.Controls.Add(lblTimeframesSubtitle);
            rangePanel.Controls.Add(lblTimeframes);
            rangePanel.Dock = DockStyle.Top;
            rangePanel.Location = new Point(24, 24);
            rangePanel.Name = "rangePanel";
            rangePanel.Size = new Size(1192, 82);
            rangePanel.TabIndex = 2;
            // 
            // cardGridPanel
            // 
            cardGridPanel.ColumnCount = 2;
            cardGridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardGridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardGridPanel.Controls.Add(pnlCard1, 0, 0);
            cardGridPanel.Controls.Add(pnlCard2, 1, 0);
            cardGridPanel.Controls.Add(pnlCard3, 0, 1);
            cardGridPanel.Controls.Add(pnlCard4, 1, 1);
            cardGridPanel.Dock = DockStyle.Fill;
            cardGridPanel.Location = new Point(24, 106);
            cardGridPanel.Name = "cardGridPanel";
            cardGridPanel.RowCount = 2;
            cardGridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardGridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardGridPanel.Size = new Size(1192, 492);
            cardGridPanel.TabIndex = 0;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.FromArgb(42, 42, 50);
            pnlCard1.Controls.Add(pnlTrend1);
            pnlCard1.Controls.Add(lblChange1);
            pnlCard1.Controls.Add(lblPrice1);
            pnlCard1.Controls.Add(lblPriceCaption1);
            pnlCard1.Controls.Add(cmbSymbol1);
            pnlCard1.Controls.Add(lblCardKicker1);
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.Location = new Point(12, 12);
            pnlCard1.Margin = new Padding(12);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Padding = new Padding(22);
            pnlCard1.Size = new Size(456, 263);
            pnlCard1.TabIndex = 0;
            pnlCard1.Paint += CardPanel_Paint;
            // 
            // pnlTrend1
            // 
            pnlTrend1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTrend1.BackColor = Color.FromArgb(34, 34, 42);
            pnlTrend1.Location = new Point(22, 124);
            pnlTrend1.Name = "pnlTrend1";
            pnlTrend1.Size = new Size(412, 117);
            pnlTrend1.TabIndex = 5;
            pnlTrend1.Paint += ChartPanel_Paint;
            // 
            // lblChange1
            // 
            lblChange1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChange1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChange1.ForeColor = Color.FromArgb(209, 209, 214);
            lblChange1.Location = new Point(297, 84);
            lblChange1.Name = "lblChange1";
            lblChange1.Size = new Size(137, 22);
            lblChange1.TabIndex = 4;
            lblChange1.Text = "Awaiting login";
            lblChange1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrice1
            // 
            lblPrice1.AutoSize = true;
            lblPrice1.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblPrice1.ForeColor = Color.FromArgb(0, 230, 118);
            lblPrice1.Location = new Point(22, 78);
            lblPrice1.Name = "lblPrice1";
            lblPrice1.Size = new Size(54, 31);
            lblPrice1.TabIndex = 3;
            lblPrice1.Text = "--.--";
            // 
            // lblPriceCaption1
            // 
            lblPriceCaption1.AutoSize = true;
            lblPriceCaption1.Font = new Font("Segoe UI", 9F);
            lblPriceCaption1.ForeColor = Color.FromArgb(209, 209, 214);
            lblPriceCaption1.Location = new Point(22, 61);
            lblPriceCaption1.Name = "lblPriceCaption1";
            lblPriceCaption1.Size = new Size(77, 15);
            lblPriceCaption1.TabIndex = 2;
            lblPriceCaption1.Text = "Current Price";
            // 
            // cmbSymbol1
            // 
            cmbSymbol1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSymbol1.BackColor = Color.FromArgb(24, 24, 31);
            cmbSymbol1.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSymbol1.FlatStyle = FlatStyle.Flat;
            cmbSymbol1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            cmbSymbol1.ForeColor = Color.White;
            cmbSymbol1.FormattingEnabled = true;
            cmbSymbol1.ItemHeight = 30;
            cmbSymbol1.Location = new Point(22, 22);
            cmbSymbol1.Name = "cmbSymbol1";
            cmbSymbol1.Size = new Size(196, 33);
            cmbSymbol1.TabIndex = 1;
            cmbSymbol1.DrawItem += SymbolCombo_DrawItem;
            cmbSymbol1.TextChanged += SymbolCombo_TextChanged;
            // 
            // lblCardKicker1
            // 
            lblCardKicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCardKicker1.AutoSize = true;
            lblCardKicker1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCardKicker1.ForeColor = Color.FromArgb(152, 152, 164);
            lblCardKicker1.Location = new Point(325, 32);
            lblCardKicker1.Name = "lblCardKicker1";
            lblCardKicker1.Size = new Size(109, 13);
            lblCardKicker1.TabIndex = 0;
            lblCardKicker1.Text = "CUSTOM SYMBOL";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.FromArgb(42, 42, 50);
            pnlCard2.Controls.Add(pnlTrend2);
            pnlCard2.Controls.Add(lblChange2);
            pnlCard2.Controls.Add(lblPrice2);
            pnlCard2.Controls.Add(lblPriceCaption2);
            pnlCard2.Controls.Add(cmbSymbol2);
            pnlCard2.Controls.Add(lblCardKicker2);
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.Location = new Point(492, 12);
            pnlCard2.Margin = new Padding(12);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Padding = new Padding(22);
            pnlCard2.Size = new Size(456, 263);
            pnlCard2.TabIndex = 1;
            pnlCard2.Paint += CardPanel_Paint;
            // 
            // pnlTrend2
            // 
            pnlTrend2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTrend2.BackColor = Color.FromArgb(34, 34, 42);
            pnlTrend2.Location = new Point(22, 124);
            pnlTrend2.Name = "pnlTrend2";
            pnlTrend2.Size = new Size(412, 117);
            pnlTrend2.TabIndex = 5;
            pnlTrend2.Paint += ChartPanel_Paint;
            // 
            // lblChange2
            // 
            lblChange2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChange2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChange2.ForeColor = Color.FromArgb(209, 209, 214);
            lblChange2.Location = new Point(297, 84);
            lblChange2.Name = "lblChange2";
            lblChange2.Size = new Size(137, 22);
            lblChange2.TabIndex = 4;
            lblChange2.Text = "Awaiting login";
            lblChange2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrice2
            // 
            lblPrice2.AutoSize = true;
            lblPrice2.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblPrice2.ForeColor = Color.FromArgb(0, 230, 118);
            lblPrice2.Location = new Point(22, 78);
            lblPrice2.Name = "lblPrice2";
            lblPrice2.Size = new Size(54, 31);
            lblPrice2.TabIndex = 3;
            lblPrice2.Text = "--.--";
            // 
            // lblPriceCaption2
            // 
            lblPriceCaption2.AutoSize = true;
            lblPriceCaption2.Font = new Font("Segoe UI", 9F);
            lblPriceCaption2.ForeColor = Color.FromArgb(209, 209, 214);
            lblPriceCaption2.Location = new Point(22, 61);
            lblPriceCaption2.Name = "lblPriceCaption2";
            lblPriceCaption2.Size = new Size(77, 15);
            lblPriceCaption2.TabIndex = 2;
            lblPriceCaption2.Text = "Current Price";
            // 
            // cmbSymbol2
            // 
            cmbSymbol2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSymbol2.BackColor = Color.FromArgb(24, 24, 31);
            cmbSymbol2.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSymbol2.FlatStyle = FlatStyle.Flat;
            cmbSymbol2.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            cmbSymbol2.ForeColor = Color.White;
            cmbSymbol2.FormattingEnabled = true;
            cmbSymbol2.ItemHeight = 30;
            cmbSymbol2.Location = new Point(22, 22);
            cmbSymbol2.Name = "cmbSymbol2";
            cmbSymbol2.Size = new Size(196, 33);
            cmbSymbol2.TabIndex = 1;
            cmbSymbol2.DrawItem += SymbolCombo_DrawItem;
            cmbSymbol2.TextChanged += SymbolCombo_TextChanged;
            // 
            // lblCardKicker2
            // 
            lblCardKicker2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCardKicker2.AutoSize = true;
            lblCardKicker2.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCardKicker2.ForeColor = Color.FromArgb(152, 152, 164);
            lblCardKicker2.Location = new Point(325, 32);
            lblCardKicker2.Name = "lblCardKicker2";
            lblCardKicker2.Size = new Size(109, 13);
            lblCardKicker2.TabIndex = 0;
            lblCardKicker2.Text = "CUSTOM SYMBOL";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.FromArgb(42, 42, 50);
            pnlCard3.Controls.Add(pnlTrend3);
            pnlCard3.Controls.Add(lblChange3);
            pnlCard3.Controls.Add(lblPrice3);
            pnlCard3.Controls.Add(lblPriceCaption3);
            pnlCard3.Controls.Add(cmbSymbol3);
            pnlCard3.Controls.Add(lblCardKicker3);
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.Location = new Point(12, 299);
            pnlCard3.Margin = new Padding(12);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Padding = new Padding(22);
            pnlCard3.Size = new Size(456, 263);
            pnlCard3.TabIndex = 2;
            pnlCard3.Paint += CardPanel_Paint;
            // 
            // pnlTrend3
            // 
            pnlTrend3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTrend3.BackColor = Color.FromArgb(34, 34, 42);
            pnlTrend3.Location = new Point(22, 124);
            pnlTrend3.Name = "pnlTrend3";
            pnlTrend3.Size = new Size(412, 117);
            pnlTrend3.TabIndex = 5;
            pnlTrend3.Paint += ChartPanel_Paint;
            // 
            // lblChange3
            // 
            lblChange3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChange3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChange3.ForeColor = Color.FromArgb(209, 209, 214);
            lblChange3.Location = new Point(297, 84);
            lblChange3.Name = "lblChange3";
            lblChange3.Size = new Size(137, 22);
            lblChange3.TabIndex = 4;
            lblChange3.Text = "Awaiting login";
            lblChange3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrice3
            // 
            lblPrice3.AutoSize = true;
            lblPrice3.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblPrice3.ForeColor = Color.FromArgb(0, 230, 118);
            lblPrice3.Location = new Point(22, 78);
            lblPrice3.Name = "lblPrice3";
            lblPrice3.Size = new Size(54, 31);
            lblPrice3.TabIndex = 3;
            lblPrice3.Text = "--.--";
            // 
            // lblPriceCaption3
            // 
            lblPriceCaption3.AutoSize = true;
            lblPriceCaption3.Font = new Font("Segoe UI", 9F);
            lblPriceCaption3.ForeColor = Color.FromArgb(209, 209, 214);
            lblPriceCaption3.Location = new Point(22, 61);
            lblPriceCaption3.Name = "lblPriceCaption3";
            lblPriceCaption3.Size = new Size(77, 15);
            lblPriceCaption3.TabIndex = 2;
            lblPriceCaption3.Text = "Current Price";
            // 
            // cmbSymbol3
            // 
            cmbSymbol3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSymbol3.BackColor = Color.FromArgb(24, 24, 31);
            cmbSymbol3.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSymbol3.FlatStyle = FlatStyle.Flat;
            cmbSymbol3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            cmbSymbol3.ForeColor = Color.White;
            cmbSymbol3.FormattingEnabled = true;
            cmbSymbol3.ItemHeight = 30;
            cmbSymbol3.Location = new Point(22, 22);
            cmbSymbol3.Name = "cmbSymbol3";
            cmbSymbol3.Size = new Size(196, 33);
            cmbSymbol3.TabIndex = 1;
            cmbSymbol3.DrawItem += SymbolCombo_DrawItem;
            cmbSymbol3.TextChanged += SymbolCombo_TextChanged;
            // 
            // lblCardKicker3
            // 
            lblCardKicker3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCardKicker3.AutoSize = true;
            lblCardKicker3.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCardKicker3.ForeColor = Color.FromArgb(152, 152, 164);
            lblCardKicker3.Location = new Point(325, 32);
            lblCardKicker3.Name = "lblCardKicker3";
            lblCardKicker3.Size = new Size(109, 13);
            lblCardKicker3.TabIndex = 0;
            lblCardKicker3.Text = "CUSTOM SYMBOL";
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.FromArgb(42, 42, 50);
            pnlCard4.Controls.Add(pnlTrend4);
            pnlCard4.Controls.Add(lblChange4);
            pnlCard4.Controls.Add(lblPrice4);
            pnlCard4.Controls.Add(lblPriceCaption4);
            pnlCard4.Controls.Add(cmbSymbol4);
            pnlCard4.Controls.Add(lblCardKicker4);
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.Location = new Point(492, 299);
            pnlCard4.Margin = new Padding(12);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Padding = new Padding(22);
            pnlCard4.Size = new Size(456, 263);
            pnlCard4.TabIndex = 3;
            pnlCard4.Paint += CardPanel_Paint;
            // 
            // pnlTrend4
            // 
            pnlTrend4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTrend4.BackColor = Color.FromArgb(34, 34, 42);
            pnlTrend4.Location = new Point(22, 124);
            pnlTrend4.Name = "pnlTrend4";
            pnlTrend4.Size = new Size(412, 117);
            pnlTrend4.TabIndex = 5;
            pnlTrend4.Paint += ChartPanel_Paint;
            // 
            // lblChange4
            // 
            lblChange4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChange4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChange4.ForeColor = Color.FromArgb(209, 209, 214);
            lblChange4.Location = new Point(297, 84);
            lblChange4.Name = "lblChange4";
            lblChange4.Size = new Size(137, 22);
            lblChange4.TabIndex = 4;
            lblChange4.Text = "Awaiting login";
            lblChange4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrice4
            // 
            lblPrice4.AutoSize = true;
            lblPrice4.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
            lblPrice4.ForeColor = Color.FromArgb(0, 230, 118);
            lblPrice4.Location = new Point(22, 78);
            lblPrice4.Name = "lblPrice4";
            lblPrice4.Size = new Size(54, 31);
            lblPrice4.TabIndex = 3;
            lblPrice4.Text = "--.--";
            // 
            // lblPriceCaption4
            // 
            lblPriceCaption4.AutoSize = true;
            lblPriceCaption4.Font = new Font("Segoe UI", 9F);
            lblPriceCaption4.ForeColor = Color.FromArgb(209, 209, 214);
            lblPriceCaption4.Location = new Point(22, 61);
            lblPriceCaption4.Name = "lblPriceCaption4";
            lblPriceCaption4.Size = new Size(77, 15);
            lblPriceCaption4.TabIndex = 2;
            lblPriceCaption4.Text = "Current Price";
            // 
            // cmbSymbol4
            // 
            cmbSymbol4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbSymbol4.BackColor = Color.FromArgb(24, 24, 31);
            cmbSymbol4.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSymbol4.FlatStyle = FlatStyle.Flat;
            cmbSymbol4.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            cmbSymbol4.ForeColor = Color.White;
            cmbSymbol4.FormattingEnabled = true;
            cmbSymbol4.ItemHeight = 30;
            cmbSymbol4.Location = new Point(22, 22);
            cmbSymbol4.Name = "cmbSymbol4";
            cmbSymbol4.Size = new Size(196, 33);
            cmbSymbol4.TabIndex = 1;
            cmbSymbol4.DrawItem += SymbolCombo_DrawItem;
            cmbSymbol4.TextChanged += SymbolCombo_TextChanged;
            // 
            // lblCardKicker4
            // 
            lblCardKicker4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCardKicker4.AutoSize = true;
            lblCardKicker4.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCardKicker4.ForeColor = Color.FromArgb(152, 152, 164);
            lblCardKicker4.Location = new Point(325, 32);
            lblCardKicker4.Name = "lblCardKicker4";
            lblCardKicker4.Size = new Size(109, 13);
            lblCardKicker4.TabIndex = 0;
            lblCardKicker4.Text = "CUSTOM SYMBOL";
            // 
            // bottomStatusPanel
            // 
            bottomStatusPanel.BackColor = Color.FromArgb(30, 30, 36);
            bottomStatusPanel.Controls.Add(lblClock);
            bottomStatusPanel.Controls.Add(lblLoginNotice);
            bottomStatusPanel.Dock = DockStyle.Bottom;
            bottomStatusPanel.Location = new Point(24, 598);
            bottomStatusPanel.Name = "bottomStatusPanel";
            bottomStatusPanel.Size = new Size(1192, 34);
            bottomStatusPanel.TabIndex = 1;
            // 
            // lblClock
            // 
            lblClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClock.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblClock.ForeColor = Color.White;
            lblClock.Location = new Point(1085, 8);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(105, 19);
            lblClock.TabIndex = 1;
            lblClock.Text = "00:00:00";
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLoginNotice
            // 
            lblLoginNotice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLoginNotice.Font = new Font("Segoe UI", 9F);
            lblLoginNotice.ForeColor = Color.FromArgb(209, 209, 214);
            lblLoginNotice.Location = new Point(709, 9);
            lblLoginNotice.Name = "lblLoginNotice";
            lblLoginNotice.Size = new Size(370, 18);
            lblLoginNotice.TabIndex = 0;
            lblLoginNotice.Text = "Awaiting account login";
            lblLoginNotice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // clockTimer
            // 
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            // 
            // marketTimer
            // 
            marketTimer.Interval = 900;
            marketTimer.Tick += MarketTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 36);
            ClientSize = new Size(1240, 760);
            Controls.Add(mainDashboardPanel);
            Controls.Add(topPanel);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            MinimumSize = new Size(1060, 680);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MT5 Popular Charts Dashboard";
            FormClosing += Form1_FormClosing;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            mainDashboardPanel.ResumeLayout(false);
            rangePanel.ResumeLayout(false);
            rangePanel.PerformLayout();
            cardGridPanel.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            bottomStatusPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Panel loginPanel;
        private Button btnConnect;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtAccountId;
        private Label lblAccountId;
        private Label lblLoginTitle;
        private Label lblStatus;
        private Panel statusDotPanel;
        private Label lblSubtitle;
        private Label lblTitle;
        private Panel sidebarPanel;
        private Label lblSelectedRange;
        private Button btnYearly;
        private Button btnMonthly;
        private Button btnWeekly;
        private Button btnDaily;
        private Label lblTimeframesSubtitle;
        private Label lblTimeframes;
        private Panel mainDashboardPanel;
        private Panel rangePanel;
        private TableLayoutPanel cardGridPanel;
        private Panel pnlCard1;
        private Panel pnlTrend1;
        private Label lblChange1;
        private Label lblPrice1;
        private Label lblPriceCaption1;
        private ComboBox cmbSymbol1;
        private Label lblCardKicker1;
        private Panel pnlCard2;
        private Panel pnlTrend2;
        private Label lblChange2;
        private Label lblPrice2;
        private Label lblPriceCaption2;
        private ComboBox cmbSymbol2;
        private Label lblCardKicker2;
        private Panel pnlCard3;
        private Panel pnlTrend3;
        private Label lblChange3;
        private Label lblPrice3;
        private Label lblPriceCaption3;
        private ComboBox cmbSymbol3;
        private Label lblCardKicker3;
        private Panel pnlCard4;
        private Panel pnlTrend4;
        private Label lblChange4;
        private Label lblPrice4;
        private Label lblPriceCaption4;
        private ComboBox cmbSymbol4;
        private Label lblCardKicker4;
        private Panel bottomStatusPanel;
        private Label lblClock;
        private Label lblLoginNotice;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Timer marketTimer;
    }
}
