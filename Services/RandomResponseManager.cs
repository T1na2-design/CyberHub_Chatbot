using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.Services
{
    public class RandomResponseManager
    {
        private readonly Dictionary<string, List<string>> _responses;
        private readonly Random _random = new Random();

        public RandomResponseManager()
        {
            _responses = new Dictionary<string, List<string>>
            {
                { "Passwords", new List<string> {
                    "Always use a mix of uppercase, lowercase, numbers, and symbols.",
                    "Never reuse the same password across multiple sites.",
                    "Consider using a password manager.",
                    "Enable Two-Factor Authentication (2FA) wherever possible.",
                    "Passphrases are often stronger and easier to remember than random characters."
                }},
                { "Scanning", new List<string> {
                    "Keep your antivirus updated to the latest signature database.",
                    "Run regular full system scans.",
                    "Don't ignore alerts from your security software.",
                    "Be careful when plugging in unfamiliar USB drives."
                }},
                { "Privacy", new List<string> {
                    "Review app permissions on your phone regularly.",
                    "Use a VPN when connected to public Wi-Fi.",
                    "Be mindful of what you share on social media.",
                    "Clear your browser cookies and cache frequently."
                }},
                { "Phishing", new List<string> {
                    "Always check the sender's email address.",
                    "Hover over links to see the real destination before clicking.",
                    "Beware of urgent requests for personal information.",
                    "If an offer seems too good to be true, it probably is."
                }},
                { "Browsing", new List<string> {
                    "Look for the padlock and HTTPS in the address bar.",
                    "Keep your web browser updated.",
                    "Use an ad-blocker or privacy extension.",
                    "Don't download files from untrusted websites."
                }}
            };
        }

        public string GetRandomResponse(string topic)
        {
            if (_responses.TryGetValue(topic, out var list))
            {
                return list[_random.Next(list.Count)];
            }
            return "I don't have tips for that specific topic yet.";
        }
    }
}