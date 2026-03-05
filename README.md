# 🔒 CyberHub_Chatbot

> A console-based cybersecurity awareness chatbot built with .NET 10, designed to educate users about online safety through an interactive, personalized conversation experience.

---

## 📖 Project Overview

**CyberHub_Chatbot** is an interactive command-line chatbot that teaches cybersecurity best practices and raises digital safety awareness. It uses a friendly, conversational approach — complete with ASCII art, color-coded output, typewriter effects, and audio greetings — to make learning about cybersecurity engaging and accessible.

**Target Audience:**
- Students and beginners learning about online safety
- Everyday users who want practical cybersecurity tips
- Educators looking for a simple awareness demonstration tool

**Learning Objectives:**
- Understand common cyber threats (phishing, malware, ransomware, social engineering)
- Learn best practices for passwords, 2FA, Wi-Fi security, and data privacy
- Develop safe browsing and social media habits

---

## ✨ Features

### 🔊 Voice & Audio
- Plays a `.wav` audio greeting on startup via `SoundPlayer`
- Audio playback runs asynchronously to avoid blocking the UI
- Graceful fallback — the chatbot continues normally if the audio file is missing or playback fails

### 🎨 Visual Elements
- Custom ASCII art banner displayed at launch (`AsciiArt.GetCyberSecurityLogo()`)
- Color-coded console output (green prompts, cyan headers, yellow topics, red errors)
- Bordered messages using Unicode box-drawing characters (`╔═╗║╚╝`)
- Section headers for organized topic display

### 💬 User Interaction
- Personalized experience — asks for the user's name and addresses them throughout the session
- Natural conversation flow with a typewriter animation effect on responses
- Supports commands like `help` (topic list) and `exit` (graceful goodbye)
- Responds to social cues (greetings, thank-you messages)

### 🧠 Response System
- Keyword-based topic matching across **15 cybersecurity topics**
- Conversational handlers for greetings, purpose questions, and gratitude
- Informative fallback response listing all available topics when a query is unrecognized

### ✅ Input Handling
- Empty input validation with user-friendly prompts
- Name validation loop — does not allow blank usernames
- Case-insensitive query matching
- Global error handling with `try/catch` in the main loop

### 🖥️ UI Enhancements
- UTF-8 console encoding for proper emoji and Unicode rendering
- Adjustable spacing between messages for readability
- Typewriter effect with surrogate-pair-safe character rendering

---

## 🏗️ Technical Implementation

### Code Organization

The project follows a clean **separation of concerns** pattern:

| Folder/File | Responsibility |
|---|---|
| `Program.cs` | Application entry point, initialization, main chat loop |
| `Services/ChatService.cs` | Query processing and response generation |
| `Services/AudioService.cs` | Audio greeting playback |
| `Utils/ConsoleHelper.cs` | Console I/O utilities (colors, borders, typewriter effect) |
| `Utils/AsciiArt.cs` | ASCII art banner content |
| `Models/UserSession.cs` | User session data model |

### Key Technologies

- **.NET 10** (Console Application)
- **C# 14**
- **System.Media.SoundPlayer** (via `System.Windows.Extensions` NuGet package)
- **System.Text.Encoding.UTF8** for full Unicode/emoji support
- **Async/Await** for non-blocking audio and typewriter effects

---

## 📁 Project Structure

```
CyberHub_Chatbot/
├── Audio/
│   └── greeting.wav              # Startup audio greeting
├── Models/
│   └── UserSession.cs            # User session data (name, start time, message count)
├── Services/
│   ├── AudioService.cs           # Async WAV audio playback
│   └── ChatService.cs            # Keyword-based response engine
├── Utils/
│   ├── AsciiArt.cs               # ASCII art logo
│   └── ConsoleHelper.cs          # Console display utilities
├── Program.cs                    # Entry point and chat loop
├── CyberHub_Chatbot.csproj       # Project configuration
└── README.md
```

---

## ⚙️ Setup & Installation

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- **Windows** (required for `SoundPlayer` audio playback)
- A terminal that supports Unicode/UTF-8

### Installation Steps

```bash
# 1. Clone the repository
git clone https://github.com/T1na2-design/CyberHub_Chatbot.git

# 2. Navigate to the project directory
cd CyberHub_Chatbot

# 3. Restore dependencies
dotnet restore

# 4. Build the project
dotnet build

# 5. Run the chatbot
dotnet run
```

### Audio Setup

Place a WAV file at `Audio/greeting.wav` in the project root. The file is automatically copied to the output directory on build. If no audio file is present, the chatbot starts silently without errors.

> **Note:** Only `.wav` format is supported by `SoundPlayer`.

---

## 🚀 Usage Guide

### Starting the Application

```bash
dotnet run
```

### What to Expect

1. An ASCII art banner is displayed
2. A voice greeting plays (if `Audio/greeting.wav` exists)
3. A bordered welcome message appears
4. You are prompted to enter your name
5. A personalized greeting and topic list are shown
6. The interactive chat loop begins

### Available Commands

| Command | Action |
|---|---|
| `help` | Display all available cybersecurity topics |
| `exit` | End the session with a goodbye message |

### Example Questions

```
Tell me about password safety
How to avoid phishing?
Safe browsing tips
What is ransomware?
How does social engineering work?
Tell me about 2FA
How are you?
What's your purpose?
```

---

## 🛡️ Cybersecurity Topics Covered

| # | Topic | Trigger Keywords |
|---|---|---|
| 1 | 🔐 Password Safety | `password` |
| 2 | 📧 Phishing Awareness | `phishing` |
| 3 | 🌐 Safe Browsing | `browsing`, `safe web` |
| 4 | 🦠 Malware Protection | `malware`, `virus`, `trojan`, `spyware` |
| 5 | 🎭 Social Engineering | `social engineering`, `manipulation`, `impersonat` |
| 6 | 🔑 Two-Factor Authentication | `two-factor`, `2fa`, `mfa`, `multi-factor` |
| 7 | 🛡️ Data Privacy | `privacy`, `personal data`, `data protection` |
| 8 | 💰 Ransomware Prevention | `ransomware` |
| 9 | 📶 Wi-Fi Security | `wifi`, `wi-fi`, `wireless`, `public network` |
| 10 | 📱 Social Media Safety | `social media`, `facebook`, `instagram`, `online profile` |
| 11 | 🔄 Software Updates & Patching | `update`, `patch`, `software update` |
| 12 | 🪪 Identity Theft Prevention | `identity theft`, `identity fraud`, `stolen identity` |
| 13 | 📨 Email Security | `email security`, `email safety`, `secure email` |
| 14 | 💾 Backup & Data Recovery | `backup`, `back up`, `data recovery` |
| 15 | 📲 Mobile Device Security | `mobile`, `phone security`, `smartphone`, `device security` |

Each topic returns **5 actionable tips** to help users improve their cybersecurity posture.

---

## 🛑 Input Validation & Error Handling

| Scenario | Behavior |
|---|---|
| **Empty input** | Displays: *"Please type something. I'm here to help!"* |
| **Blank username** | Re-prompts: *"Name cannot be empty. Please enter your name:"* |
| **Unrecognized query** | Returns a fallback message listing all available topics |
| **Audio file missing** | Silently skips playback — no crash |
| **Audio playback failure** | Catches the exception and logs: *"Audio playback failed: ..."* |
| **Unhandled exception** | Top-level `try/catch` displays a red error message |
| **Session end** | `finally` block always prints a farewell message |

---

## 🔄 GitHub & Version Control

### Repository

```
https://github.com/T1na2-design/CyberHub_Chatbot
```

### Commit Guidelines

- Make frequent, meaningful commits (minimum **6 commits** recommended)
- Use descriptive commit messages that explain what changed and why

### CI/CD with GitHub Actions

To add a build workflow, create `.github/workflows/dotnet.yml`:

```yaml
name: .NET Build

on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]

jobs:
  build:
    runs-on: windows-latest

    steps:
    - uses: actions/checkout@v4

    - name: Setup .NET
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '10.0.x'

    - name: Restore dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --no-restore

```

### Checking Workflow Runs

1. Go to the repository's **Actions** tab on GitHub
2. Select the workflow run to view build logs and status

---

## 🔧 Troubleshooting

### Audio Not Playing

- Ensure `Audio/greeting.wav` exists in the project root
- Verify the file is in **WAV format** (`.wav`)
- Confirm the `.csproj` includes the `CopyToOutputDirectory` setting for the audio file
- This feature requires **Windows** — `SoundPlayer` is not supported on Linux/macOS

### Build Errors

- Ensure you have the **.NET 10 SDK** installed: `dotnet --version`
- Run `dotnet restore` to restore the `System.Windows.Extensions` NuGet package
- If you see `CS1069` for `SoundPlayer`, the package reference may be missing — verify it exists in the `.csproj`

### Console Display Issues (Garbled Characters / Beeping)

- The application sets `Console.OutputEncoding = Encoding.UTF8` at startup
- Use a terminal that supports UTF-8 (Windows Terminal recommended)
- Legacy `cmd.exe` may not render all emoji correctly

---

## 📄 License

This project is for educational purposes as part of a cybersecurity awareness initiative.

---

> *Stay safe online! 🔒*