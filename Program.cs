using System;
using System.Text;
using System.Threading.Tasks;
using CybersecurityChatbot.Models;
using CybersecurityChatbot.Services;
using CybersecurityChatbot.Utils;

namespace CybersecurityChatbot
{
    class Program
    {
        private static AudioService _audioService;
        private static ChatService _chatService;
        private static UserSession _currentUser;

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Title = "Cybersecurity Awareness Bot";

            try
            {
                await InitializeChatbot();
                await RunChatbot();
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowError($"An error occurred: {ex.Message}");
            }
            finally
            {
                ConsoleHelper.ShowMessage("\nThank you for using the Cybersecurity Awareness Bot. Stay safe online!", ConsoleColor.Cyan);
            }
        }

        static async Task InitializeChatbot()
        {
            // Display ASCII Art Logo
            ConsoleHelper.ShowAsciiArt(AsciiArt.GetCyberSecurityLogo());

            // Initialize services
            _audioService = new AudioService();
            _chatService = new ChatService();

            // Play voice greeting
            await _audioService.PlayVoiceGreetingAsync();

            // Display welcome message with decorative border
            ConsoleHelper.ShowBorderedMessage("WELCOME TO CYBERSECURITY AWARENESS BOT", ConsoleColor.Green);

            // Get user name
            ConsoleHelper.ShowMessage("Please enter your name:", ConsoleColor.Yellow);
            string userName = ConsoleHelper.GetUserInput();

            while (string.IsNullOrWhiteSpace(userName))
            {
                ConsoleHelper.ShowMessage("Name cannot be empty. Please enter your name:", ConsoleColor.Red);
                userName = ConsoleHelper.GetUserInput();
            }

            _currentUser = new UserSession { UserName = userName };

            // Personalized welcome
            ConsoleHelper.ShowMessage($"\nHello, {_currentUser.UserName}! 👋", ConsoleColor.Cyan);
            ConsoleHelper.ShowMessage("I'm here to help you learn about online safety practices.", ConsoleColor.Cyan);

            // Show available topics
            DisplayHelpTopics();

            // Typing effect for initial message
            await ConsoleHelper.TypeWriterEffect("\nType 'help' anytime to see what I can do, or 'exit' to leave.\n");

            ConsoleHelper.AddSpacing(2);
        }

        static async Task RunChatbot()
        {
            while (true)
            {
                ConsoleHelper.ShowPrompt($"{_currentUser.UserName}> ");
                string userInput = ConsoleHelper.GetUserInput();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleHelper.ShowMessage("Please type something. I'm here to help!", ConsoleColor.Yellow);
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    ConsoleHelper.ShowBorderedMessage($"Goodbye, {_currentUser.UserName}! Stay safe online! 🔒", ConsoleColor.Green);
                    break;
                }

                if (userInput.ToLower() == "help")
                {
                    DisplayHelpTopics();
                    continue;
                }

                // Process the user query with typing effect
                await ProcessUserQueryAsync(userInput);

                ConsoleHelper.AddSpacing(1);
            }
        }

        static async Task ProcessUserQueryAsync(string query)
        {
            string response = _chatService.GetResponse(query);

            // Add typing effect for more natural conversation
            await ConsoleHelper.TypeWriterEffect(response, delay: 30);
        }

        static void DisplayHelpTopics()
        {
            ConsoleHelper.ShowSectionHeader("I CAN HELP YOU WITH THESE TOPICS");

            var topics = new[]
            {
                "🔑 Password Safety",
                "🎣 Phishing Awareness",
                "🌐 Safe Browsing",
                "🦠 Malware Protection",
                "🎭 Social Engineering",
                "🔑 Two-Factor Authentication (2FA)",
                "🛡️ Data Privacy",
                "💰 Ransomware Prevention",
                "📶 Wi-Fi Security",
                "📱 Social Media Safety",
                "🔄 Software Updates & Patching",
                "🤖 About Me"
            };

            foreach (var topic in topics)
            {
                ConsoleHelper.ShowMessage($"  {topic}", ConsoleColor.DarkYellow);
            }

            ConsoleHelper.AddSpacing(1);

            ConsoleHelper.ShowMessage("Try asking:", ConsoleColor.White);
            ConsoleHelper.ShowMessage("  • 'Tell me about password safety'", ConsoleColor.DarkCyan);
            ConsoleHelper.ShowMessage("  • 'How to avoid phishing?'", ConsoleColor.DarkCyan);
            ConsoleHelper.ShowMessage("  • 'Safe browsing tips'", ConsoleColor.DarkCyan);
            ConsoleHelper.ShowMessage("  • 'What is ransomware?'", ConsoleColor.DarkCyan);
            ConsoleHelper.ShowMessage("  • 'How does social engineering work?'", ConsoleColor.DarkCyan);
            ConsoleHelper.ShowMessage("  • 'Tell me about 2FA'", ConsoleColor.DarkCyan);

            ConsoleHelper.AddSpacing(1);
        }
    }
}