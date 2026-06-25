using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class ActivityLogService
    {
        private static readonly List<ActivityLogEntry> _logs = new List<ActivityLogEntry>();
        private static readonly object _lock = new object();

        public void LogActivity(string action, string details, string category)
        {
            var entry = new ActivityLogEntry(action, details, category);
            lock (_lock)
            {
                _logs.Add(entry);
            }
        }

        public List<ActivityLogEntry> GetRecentLogs(int count = 10)
        {
            lock (_lock)
            {
                return _logs.OrderByDescending(l => l.Timestamp).Take(count).OrderBy(l => l.Timestamp).ToList();
            }
        }

        public List<ActivityLogEntry> GetLogsByCategory(string category)
        {
            lock (_lock)
            {
                return _logs.Where(l => l.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                            .OrderByDescending(l => l.Timestamp)
                            .ToList();
            }
        }

        public List<ActivityLogEntry> GetAllLogs()
        {
            lock (_lock)
            {
                return _logs.OrderByDescending(l => l.Timestamp).ToList();
            }
        }

        public int GetLogCount()
        {
            lock (_lock)
            {
                return _logs.Count;
            }
        }

        public void ClearLogs()
        {
            lock (_lock)
            {
                _logs.Clear();
            }
        }
    }
}
