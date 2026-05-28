using System;

namespace CybersecurityChatbot.Services
{
    public class SentimentAnalyzer
    {
        private readonly Random _random = new Random();

        public (string Prefix, string SentimentType) Analyze(string input)
        {
            var lower = input.ToLower();

            if (lower.Contains("worried") || lower.Contains("scared") || lower.Contains("afraid") || lower.Contains("hacked") || lower.Contains("panic"))
            {
                var prefixes = new[] { 
                    "Take a deep breath, it's completely normal to feel concerned about that. Let's tackle this together. ", 
                    "Don't panic. Security issues can be scary, but we can manage this. ", 
                    "I understand you're feeling anxious. Here is some guidance that should put your mind at ease. " 
                };
                return (prefixes[_random.Next(prefixes.Length)], "Anxious");
            }
            if (lower.Contains("frustrated") || lower.Contains("annoying") || lower.Contains("hate") || lower.Contains("hard") || lower.Contains("confused"))
            {
                var prefixes = new[] { 
                    "I completely get it—cybersecurity can feel really overwhelming and frustrating sometimes. ", 
                    "It's okay to feel annoyed. It's a lot to remember, but I'm here to simplify it for you. ", 
                    "I know it feels complicated, but you're doing the right thing by asking. " 
                };
                return (prefixes[_random.Next(prefixes.Length)], "Frustrated");
            }
            if (lower.Contains("happy") || lower.Contains("thanks") || lower.Contains("thank you") || lower.Contains("great") || lower.Contains("good"))
            {
                var prefixes = new[] { 
                    "I'm so glad to hear that! ", 
                    "It makes my digital heart happy to help you! ", 
                    "You're very welcome! Let's keep the positive momentum going. " 
                };
                return (prefixes[_random.Next(prefixes.Length)], "Happy");
            }
            if (lower.Contains("curious") || lower.Contains("wondering") || lower.Contains("tell me") || lower.Contains("how"))
            {
                var prefixes = new[] { 
                    "That's a fantastic question! Let's dive right into it. ", 
                    "I love your curiosity! ", 
                    "Always great to ask 'how' and 'why' in cybersecurity. Here's your answer. " 
                };
                return (prefixes[_random.Next(prefixes.Length)], "Curious");
            }

            return (string.Empty, "Neutral");
        }
    }
}