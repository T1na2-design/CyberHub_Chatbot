namespace CybersecurityChatbot.Models
{
    public class ActivityLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public ActivityLogEntry() { }

        public ActivityLogEntry(string action, string details, string category)
        {
            Timestamp = DateTime.Now;
            Action = action;
            Details = details;
            Category = category;
        }

        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Category}: {Action} - {Details}";
        }
    }
}
