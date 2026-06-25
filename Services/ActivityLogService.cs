using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class ActivityLogService
    {
        private List<ActivityLogEntry> _logs = new List<ActivityLogEntry>();

        public void LogActivity(string action, string details, string category)
        {
            var entry = new ActivityLogEntry(action, details, category);
            _logs.Add(entry);
        }

        public List<ActivityLogEntry> GetRecentLogs(int count = 10)
        {
            return _logs.OrderByDescending(l => l.Timestamp).Take(count).OrderBy(l => l.Timestamp).ToList();
        }

        public List<ActivityLogEntry> GetLogsByCategory(string category)
        {
            return _logs.Where(l => l.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(l => l.Timestamp)
                        .ToList();
        }

        public List<ActivityLogEntry> GetAllLogs()
        {
            return _logs.OrderByDescending(l => l.Timestamp).ToList();
        }

        public int GetLogCount()
        {
            return _logs.Count;
        }

        public void ClearLogs()
        {
            _logs.Clear();
        }
    }
}
