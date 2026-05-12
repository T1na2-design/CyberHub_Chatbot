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
                { "password", "Passwords" }, { "passcode", "Passwords" },
                { "scan", "Malware" }, { "virus", "Malware" }, { "malware", "Malware" }, { "trojan", "Malware" },
                { "privacy", "Privacy" }, { "data", "Privacy" },
                { "phishing", "Phishing" }, { "scam", "Phishing" },
                { "browsing", "Browsing" }, { "web", "Browsing" }, { "website", "Browsing" },
                { "ransomware", "Ransomware" }, { "ransom", "Ransomware" },
                { "social engineering", "Social Engineering" }, { "manipulation", "Social Engineering" },
                { "2fa", "Two-Factor Authentication" }, { "two-factor", "Two-Factor Authentication" }, { "mfa", "Two-Factor Authentication" }, { "multi-factor", "Two-Factor Authentication" },
                { "wifi", "Wi-Fi Security" }, { "wi-fi", "Wi-Fi Security" }, { "network", "Wi-Fi Security" },
                { "social media", "Social Media" }, { "facebook", "Social Media" }, { "instagram", "Social Media" },
                { "update", "Software Updates" }, { "patch", "Software Updates" },
                { "identity", "Identity Theft" }, { "theft", "Identity Theft" }, { "stolen", "Identity Theft" },
                { "email", "Email Security" },
                { "backup", "Backups" }, { "recovery", "Backups" },
                { "mobile", "Mobile Security" }, { "phone", "Mobile Security" }, { "smartphone", "Mobile Security" },
                { "iot", "IoT & Smart Home" }, { "smart home", "IoT & Smart Home" }, { "smart device", "IoT & Smart Home" }
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