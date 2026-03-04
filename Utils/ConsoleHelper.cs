using System;
using System.Threading.Tasks;

namespace CybersecurityChatbot.Utils
{
    public static class ConsoleHelper
    {
        public static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();
        }

        public static void ShowPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(prompt);
            Console.ResetColor();
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }

        public static void ShowBorderedMessage(string message, ConsoleColor color)
        {
            string border = new string('═', message.Length + 4);
            Console.ForegroundColor = color;
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║  {message}  ║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        public static void ShowSectionHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n╔══ {header} ══╗");
            Console.ResetColor();
        }

        public static void ShowAsciiArt(string art)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(art);
            Console.ResetColor();
        }

        public static void AddSpacing(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        public static async Task TypeWriterEffect(string text, int delay = 50)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsHighSurrogate(text[i]) && i + 1 < text.Length && char.IsLowSurrogate(text[i + 1]))
                {
                    Console.Write(text.AsSpan(i, 2));
                    i++;
                }
                else
                {
                    Console.Write(text[i]);
                }
                await Task.Delay(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
