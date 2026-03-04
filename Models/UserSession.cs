namespace CybersecurityChatbot.Models
{
    public class UserSession
    {
        public string UserName { get; set; }
        public DateTime SessionStartTime { get; set; } = DateTime.Now;
        public int MessageCount { get; set; }
    }
}
