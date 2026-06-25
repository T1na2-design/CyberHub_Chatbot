# 🔒 CyberHub_Chatbot

> A WPF-based cybersecurity awareness chatbot built with .NET 10, designed to educate users about online safety through chat, tasks, quizzes, and activity tracking.

---

## 📖 Project Overview

**CyberHub_Chatbot** is an interactive desktop chatbot that teaches cybersecurity best practices and raises digital safety awareness. It uses a friendly, conversational approach with chat guidance, tabbed tools, activity logging, quiz feedback, and a dark UI theme to make learning engaging and accessible.

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

### 💬 Chat Experience
- Personalized conversation flow that captures the user's name and adapts responses
- Natural-language intent handling for tasks, quiz launching, and log viewing
- Friendly fallback responses for unrecognized questions

### 🔊 Voice & Audio
- Plays a `.wav` audio greeting on startup via `SoundPlayer`
- Audio playback runs asynchronously to avoid blocking the UI
- Graceful fallback if the audio file is missing or playback fails

### 🎨 Visual Design
- Dark theme built for readability across the chat, task manager, quiz, and activity log tabs
- ASCII art banner shown at launch
- Color-coded UI feedback for success, warnings, and errors

### 🧠 Response System
- Keyword-based topic matching across **16 cybersecurity topics**
- Conversational handlers for greetings, purpose questions, and gratitude
- Informative fallback response listing all available topics when a query is unrecognized

### ✅ Input Handling
- Empty input validation with user-friendly prompts
- Name validation loop that does not allow blank usernames
- Case-insensitive query matching
- Global error handling with `try/catch` in the main loop

### 🧩 Part 3 Features
- Task Manager tab for creating, completing, deleting, and tracking tasks
- Quiz tab with 10 cybersecurity questions, score tracking, and results feedback
- Activity Log tab for viewing, exporting, refreshing, and clearing logged actions
- NLP-based chat routing that points users to the right tab or feature

---

## 🏗️ Technical Implementation

### Code Organization

The project follows a clean separation of concerns:

| Folder/File | Responsibility |
|---|---|
| `MainWindow.xaml` | Main WPF shell and tab navigation |
| `ChatService.cs` | Chat response generation |
| `AudioService.cs` | Audio greeting playback |
| `NLPHandler.cs` | Intent detection and routing |
| `TaskManagerControl.xaml` | Task management UI |
| `QuizControl.xaml` | Quiz UI and gameplay flow |
| `ActivityLogControl.xaml` | Activity log viewer |
| `Models/*.cs` | Data models for sessions, tasks, and logs |

### Key Technologies

- **.NET 10** (WPF Desktop Application)
- **C#**
- **WPF XAML** for desktop UI composition
- **System.Media.SoundPlayer** (via `System.Windows.Extensions` NuGet package)
- **Async/Await** for non-blocking audio and UI responsiveness

---

## 📁 Project Structure

```
CyberHub_Chatbot/
├── ActivityLogControl.xaml
├── AddTaskDialog.xaml
├── App.xaml
├── MainWindow.xaml
├── QuizControl.xaml
├── TaskManagerControl.xaml
├── Audio/
├── Models/
├── Services/
├── Utils/
└── CyberHub_Chatbot.csproj
```

---

## ⚙️ Setup & Installation

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- **Windows** (required for WPF and `SoundPlayer` audio playback)
- A system that can run WPF desktop apps

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

1. The app opens in a dark-themed desktop window
2. A voice greeting plays if `Audio/greeting.wav` exists
3. The chat tab prompts for your name and guides you into the app
4. You can switch between Chat, Tasks, Quiz, and Activity Log tabs
5. The quiz and log tabs show live activity updates as you use the app

### Chat Routing

- Type `add task` or `new task` to open the Task Manager tab
- Type `start quiz` or `play quiz` to open the Quiz tab
- Type `show log` or `activity log` to open the Activity Log tab
- Other messages use the standard chat response flow

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
| 16 | 🏠 IoT & Smart Home Security | `iot`, `smart home`, `smart device` |

Each topic returns **5 actionable tips** to help users improve their cybersecurity posture.

---

## 🧩 Part 3 Feature Summary

### Task Manager
- Create tasks with title, description, and reminder date
- View tasks in a DataGrid
- Mark tasks as completed or delete them
- Track pending and completed counts
- Log task activity and view upcoming reminders

### Quiz Game
- 10-question cybersecurity quiz
- Multiple choice and true/false questions
- Immediate feedback with score tracking
- Progress indicator and restart flow
- Randomized question order

### Activity Log
- Logs all major user actions with timestamps
- Categories include Tasks, Quiz, and Chat
- View recent activity, export logs, and clear logs
- Display format: [Timestamp] Category: Action - Details

### NLP Routing
- Detects simple intents for adding tasks, starting the quiz, and showing the log
- Routes chat messages to the right feature tab

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

### UI Readability Issues

- Make sure the window is not scaled too small; the quiz and activity log panels need room to avoid text crowding
- If the text looks washed out, use the updated dark theme styles in the WPF controls
- Refresh the Activity Log tab after switching between tabs to see the latest shared entries

---

## 📄 License

This project is for educational purposes as part of a cybersecurity awareness initiative.

---

> *Stay safe online! 🔒*
