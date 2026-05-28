using System.Collections.Generic;

namespace CybersecurityChatbot.Models
{
    public class UserProfile
    {
        public string Name { get; set; } = string.Empty;
        public string FavoriteTopic { get; set; } = string.Empty;
        public int InteractionCount { get; set; } = 0;
        public string LastSentiment { get; set; } = "Neutral";
        public List<string> DiscussedTopics { get; } = new List<string>();
    }
}