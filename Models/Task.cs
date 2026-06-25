namespace CybersecurityChatbot.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReminderDate { get; set; }
        public bool IsCompleted { get; set; }

        public UserTask() { }

        public UserTask(int id, string title, string description, DateTime reminderDate)
        {
            Id = id;
            Title = title;
            Description = description;
            ReminderDate = reminderDate;
            IsCompleted = false;
        }
    }
}
