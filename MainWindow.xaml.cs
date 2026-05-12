using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CybersecurityChatbot.Models;
using CybersecurityChatbot.Services;
using CybersecurityChatbot.Utils;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private readonly ChatService _chatService;
        private readonly AudioService _audioService;
        private readonly MemoryService _memoryService;
        private bool _isNameCaptured = false;

        public MainWindow()
        {
            InitializeComponent();
            
            _memoryService = new MemoryService();
            _chatService = new ChatService(_memoryService);
            _audioService = new AudioService();
            
            HeaderAscii.Text = AsciiArtConverter.GetCyberSecurityLogo();
            
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _audioService.PlayVoiceGreetingAsync();
            AddBotMessage("Welcome to the Cybersecurity Awareness Bot! 👋\nPlease enter your name:");
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessInput();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Children.Clear();
        }

        private void ProcessInput()
        {
            string input = InputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            InputBox.Text = string.Empty;
            AddUserMessage(input);

            if (!_isNameCaptured)
            {
                _memoryService.Profile.Name = input;
                _isNameCaptured = true;
                UpdateUserInfo();
                AddBotMessage($"Hello, {_memoryService.Profile.Name}! I'm here to help you learn about online safety.\nWhat cybersecurity topic would you like to learn about today? (e.g., passwords, phishing, privacy)");
                return;
            }

            string response = _chatService.GetResponse(input);
            AddBotMessage(response);
            UpdateUserInfo();
        }

        private void AddUserMessage(string message)
        {
            var border = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BD93F9")),
                CornerRadius = new CornerRadius(10, 10, 0, 10),
                Padding = new Thickness(10),
                Margin = new Thickness(50, 5, 5, 5),
                HorizontalAlignment = HorizontalAlignment.Right
            };
            
            var tb = new TextBlock
            {
                Text = message,
                Foreground = Brushes.Black,
                TextWrapping = TextWrapping.Wrap
            };
            border.Child = tb;
            ChatPanel.Children.Add(border);
            ChatScrollViewer.ScrollToEnd();
        }

        private async void AddBotMessage(string message)
        {
            var border = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6272A4")),
                CornerRadius = new CornerRadius(10, 10, 10, 0),
                Padding = new Thickness(10),
                Margin = new Thickness(5, 5, 50, 5),
                HorizontalAlignment = HorizontalAlignment.Left
            };
            
            var tb = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap
            };
            border.Child = tb;
            ChatPanel.Children.Add(border);
            await Task.Delay(100);
            ChatScrollViewer.ScrollToEnd();
        }

        private void UpdateUserInfo()
        {
            UserNameTxt.Text = string.IsNullOrEmpty(_memoryService.Profile.Name) ? "Guest" : _memoryService.Profile.Name;
            UserInterestsTxt.Text = string.IsNullOrEmpty(_memoryService.Profile.FavoriteTopic) ? "None" : _memoryService.Profile.FavoriteTopic;
        }
    }
}