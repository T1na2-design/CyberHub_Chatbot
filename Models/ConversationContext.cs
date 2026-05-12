namespace CybersecurityChatbot.Models
{
    public class ConversationContext
    {
        public string LastTopic { get; set; } = string.Empty;
        
        public bool IsFollowUp(string input)
        {
            var lower = input.ToLower();
            return lower.Contains("tell me more") || 
                   lower.Contains("another tip") || 
                   lower.Contains("more info") ||
                   lower.Contains("expand on that");
        }
    }
}