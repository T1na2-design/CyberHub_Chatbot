using System.Collections.ObjectModel;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class TaskService
    {
        private List<UserTask> _tasks = new List<UserTask>();
        private int _nextId = 1;

        public ObservableCollection<UserTask> GetAllTasks()
        {
            return new ObservableCollection<UserTask>(_tasks);
        }

        public void AddTask(string title, string description, DateTime reminderDate)
        {
            var task = new UserTask(_nextId++, title, description, reminderDate);
            _tasks.Add(task);
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public void CompleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public List<UserTask> GetPendingTasks()
        {
            return _tasks.Where(t => !t.IsCompleted).ToList();
        }

        public List<UserTask> GetUpcomingReminders(int daysAhead = 7)
        {
            var today = DateTime.Now;
            var futureDate = today.AddDays(daysAhead);
            
            return _tasks.Where(t => 
                !t.IsCompleted && 
                t.ReminderDate >= today && 
                t.ReminderDate <= futureDate)
                .OrderBy(t => t.ReminderDate)
                .ToList();
        }

        public int GetCompletedCount()
        {
            return _tasks.Count(t => t.IsCompleted);
        }

        public int GetPendingCount()
        {
            return _tasks.Count(t => !t.IsCompleted);
        }
    }
}
