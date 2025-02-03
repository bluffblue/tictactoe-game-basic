<div align="center">
  <h1>🎮 Mobile TicTacToe Game</h1>
  <p>
    <strong>A Cross-Platform TicTacToe Game Built with Xamarin.Form</strong>
  </p>
  <p>
    <a href="#features">Features</a> •
    <a href="#installation">Installation</a> •
    <a href="#usage">Usage</a> •
    <a href="#architecture">Architecture</a>
  </p>
</div>

---

## ✨ Features

🎯 **Core Features**
- Intuitive and responsive touch interface
- Real-time game state updates
- Smart win detection algorithm
- Draw game detection
- Instant game reset functionality

🎨 **Technical Features**
- Clean MVVM Architecture
- Reactive UI with data binding
- Cross-platform compatibility
- High-performance game logic
- Smooth animations and transitions

## 🛠️ Technical Stack

- **Framework:** Xamarin.Forms
- **Language:** C# .NET
- **UI Design:** XAML
- **Architecture:** MVVM Pattern
- **Platform:** Android (iOS support coming soon)

## ⚙️ Prerequisites

Before you begin, ensure you have the following installed:
- Visual Studio 2019/2022 with Mobile Development workload
- Xamarin.Forms (latest version)
- .NET SDK 6.0 or later
- Android SDK (API 31 or later)
- JDK 11 or later

## 📥 Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/bluffblue/tictactoe-game-basic.git
   cd tictactoe-game-basic
   ```

2. **Open in Visual Studio**
   - Launch Visual Studio
   - Open `TicTacToe.sln`
   - Wait for solution restoration

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the Solution**
   ```bash
   dotnet build
   ```

## 🎮 Game Rules

1. **Setup**
   - Game starts with an empty 3x3 grid
   - First player uses "X", second player uses "O"

2. **Gameplay**
   - Players take turns placing their symbol
   - Tap any empty cell to make a move
   - First to get 3 in a row wins
   - Game ends in draw if board fills up

3. **Winning Conditions**
   - Three symbols in a horizontal row
   - Three symbols in a vertical row
   - Three symbols in a diagonal line

## 🚀 Running the Game

1. **Connect Device**
   - Connect Android device via USB
   - Enable USB debugging
   - OR use Android Emulator

2. **Launch Application**
   - Set Android project as startup
   - Select target device
   - Press F5 to debug

## 🏗️ Architecture

This project follows Clean Architecture principles:

- **Models:** Core game logic and state
- **ViewModels:** UI logic and data binding
- **Views:** User interface components
- **Services:** Game utilities and helpers

## 🤝 Contributing

We welcome contributions! Here's how:

1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔗 Links

- [Project Homepage](https://github.com/bluffblue/tictactoe-game-basic)
- [Issue Tracker](https://github.com/bluffblue/tictactoe-game-basic/issues)
- [Documentation](https://github.com/bluffblue/tictactoe-game-basic/wiki)

## 📞 Contact

- bluffblue - [@bluffbluee](https://x.com/bluffbluee)
- Email - lienhartcharles@gmail.com

## 🙏 Acknowledgments

- Xamarin.Forms Community
- Microsoft Documentation
- Stack Overflow Community

---

<div align="center">
  Made with ❤️ by <a href="https://github.com/bluffblue">bluffblue</a>
</div>
