using System.Collections.Generic;

namespace CybersecurityChatbot.Services
{
    public class KeywordRecognizer
    {
        private readonly Dictionary<string, string> _topicMap;

        public KeywordRecognizer()
        {
            _topicMap = new Dictionary<string, string>
            {
                { "password", "Passwords" },
                { "passwords", "Passwords" },
                { "scan", "Scanning" },
                { "virus", "Scanning" },
                { "malware", "Scanning" },
                { "privacy", "Privacy" },
                { "data", "Privacy" },
                { "phishing", "Phishing" },
                { "scam", "Phishing" },
                { "email", "Phishing" },
                { "browsing", "Browsing" },
                { "web", "Browsing" }
            };
        }

        public string IdentifyTopic(string input)
        {
            var lower = input.ToLower();
            foreach (var kvp in _topicMap)
            {
                if (lower.Contains(kvp.Key))
                {
                    return kvp.Value;
                }
            }
            return string.Empty;
        }
    }
}