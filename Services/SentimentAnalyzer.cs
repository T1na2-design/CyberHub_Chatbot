namespace CybersecurityChatbot.Services
{
    public class SentimentAnalyzer
    {
        public string GetSentimentPrefix(string input)
        {
            var lower = input.ToLower();
            if (lower.Contains("worried") || lower.Contains("scared") || lower.Contains("afraid") || lower.Contains("hacked"))
            {
                return "It's completely normal to feel concerned about that. Let me help clarify things. ";
            }
            if (lower.Contains("frustrated") || lower.Contains("annoying") || lower.Contains("hate") || lower.Contains("hard"))
            {
                return "I understand how frustrating security measures can be, but they are important. ";
            }
            if (lower.Contains("curious") || lower.Contains("wondering") || lower.Contains("tell me"))
            {
                return "That's a great question to ask! ";
            }
            return string.Empty;
        }
    }
}