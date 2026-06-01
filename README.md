<div align="center">

Topics: metatrader5, mql5, market-watch, expert-advisor, mql4, metatrader, forex-trading, data-visualization, charting, market-data, forex-charts, trading-terminal, multi-asset, mt4, mt5, trading-bot, mt5-market-watch, mt5-charts-dashboard, multi-asset-dashboard

# MT5 Market Watch Dashboard

**A modern Windows desktop market watch interface for MetaTrader 5 style workflows, built with .NET 8 and WinForms. It gives traders a clean multi-asset command screen with login gating, symbol selectors, live price cards, timeframe filters, and glowing chart panels for fast market monitoring.**

<br>

[![Stars](https://img.shields.io/badge/Stars-Repository-00D4AA?style=for-the-badge)](https://github.com/your-username/volume-profile-mt5/stargazers)
[![Forks](https://img.shields.io/badge/Forks-Community-4D9FFF?style=for-the-badge)](https://github.com/your-username/volume-profile-mt5/network)
[![Issues](https://img.shields.io/badge/Issues-Tracker-FF4D6A?style=for-the-badge)](https://github.com/your-username/volume-profile-mt5/issues)
[![Platform](https://img.shields.io/badge/Platform-MetaTrader%205-00D4AA?style=for-the-badge)](https://www.metatrader5.com)
[![License](https://img.shields.io/badge/License-MIT-4D9FFF?style=for-the-badge)](LICENSE)



</div>

---

## Screenshot

<img width="1227" height="790" alt="Screenshot_2" src="https://github.com/user-attachments/assets/03b6adac-3641-46b9-a19a-4e0b0202abd8" />


---

## 🎬 Demo

<div align="center">

<img src="https://i.imgur.com/dQix6NX.gif" alt="Demo">

</div>


---

## Why This Project

Trading dashboards need to be fast, readable, and focused. **MT5 Market Watch Dashboard** is designed as a compact visual terminal where a trader can authenticate, select important markets, and follow price movement across multiple instruments without switching screens.

It is useful for:

- Forex and CFD dashboard prototypes
- MT5 bridge UI concepts
- Multi-asset market monitor demos
- WinForms trading interface portfolios
- Real-time WebSocket data experiments

---

## What It Does

| Module | Description |
|---|---|
| Account Login | Requires MT5 account ID and password before the dashboard activates |
| Market Stream | Attempts to connect to a local MT5 WebSocket bridge at `ws://127.0.0.1:8765` |
| Symbol Cards | Displays four configurable instruments at once |
| Price Engine | Updates simulated prices when live feed data is not available |
| Timeframe Controls | Switches between D1, W1, MN, and Y1 market views |
| Custom Charts | Renders smooth trend lines directly inside WinForms panels |
| Asset Categories | Highlights FX, metals, crypto, and index instruments with distinct colors |

---

## Features

| Feature | Benefit |
|---|---|
| Dark Trading UI | Professional terminal-style layout for long sessions |
| Multi-Symbol Watchlist | Track EURUSD, XAUUSD, BTCUSD, GBPUSD, indices, and more |
| Live Login Status | Clear connected, disconnected, and validation states |
| WebSocket Ready | Designed for local MT5 bridge integration |
| Synthetic Market Mode | Keeps the dashboard usable without an active backend |
| Dynamic Price Formatting | Adapts decimals for FX pairs, JPY pairs, metals, crypto, and indices |
| Smooth Chart Drawing | Uses anti-aliased custom rendering for visual polish |
| Safe Shutdown | Cleans up timers, sockets, and cancellation tokens on close |

---

## Supported Markets

```text
FX       EURUSD, GBPUSD, USDJPY, USDCHF, AUDUSD, USDCAD
Metals   XAUUSD, XAGUSD
Crypto   BTCUSD, ETHUSD, SOLUSD
Indices  US30, NAS100, SPX500, GER40, UK100
```

---

## Interface Flow

```text
MT5 Login
   |
   v
WebSocket Subscribe
   |
   v
Symbol Cards + Timeframe Filter
   |
   v
Live Price Updates or Synthetic Price Engine
   |
   v
Visual Market Watch Dashboard
```

---

## Quick Start

**Requirements:**

- Windows 10 or Windows 11
- .NET 8 SDK
- Visual Studio 2022

```bash
git clone https://github.com/your-username/mt5-market-watch-dashboard.git
cd mt5-market-watch-dashboard
```

Open `WinFormsApp1.slnx` in Visual Studio and press **F5**.

---

## How to Use

1. Launch the application.
2. Enter an MT5 account ID and password.
3. Click **Sign In**.
4. Select symbols in the four market cards.
5. Switch between D1, W1, MN, and Y1.
6. Watch the cards update with live or simulated market movement.

---

## MT5 Bridge Payload

The dashboard can process JSON payloads from a local bridge. A simple message can look like this:

```json
{
  "symbol": "EURUSD",
  "price": 1.0852
}
```

The parser also accepts common aliases such as `asset`, `pair`, `instrument`, `bid`, `ask`, `last`, `close`, and `value`.

---

## Roadmap

- [x] Multi-symbol dashboard layout
- [x] Local WebSocket bridge support
- [x] Synthetic price fallback
- [x] Timeframe selection
- [ ] Add candlestick rendering
- [ ] Add saved watchlists
- [ ] Add alert rules
- [ ] Add production MT5 bridge adapter

---

## License

MIT

---

<div align="center">

MT5 Market Watch Dashboard - .NET 8 WinForms Trading UI

</div>
