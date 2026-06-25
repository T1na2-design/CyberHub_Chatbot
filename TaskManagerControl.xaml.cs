using System.Windows;
using System.Windows.Controls;
using CybersecurityChatbot.Services;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot
{
    public partial class TaskManagerControl : UserControl
    {
        private readonly TaskService _taskService;
        private readonly ActivityLogService _activityLogService;

        public TaskManagerControl()
        {
            InitializeComponent();
            _taskService = new TaskService();
            _activityLogService = new ActivityLogService();
            RefreshTaskList();
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddTaskDialog();
            if (dialog.ShowDialog() == true)
            {
                _taskService.AddTask(dialog.TaskTitle, dialog.TaskDescription, dialog.ReminderDate);
                _activityLogService.LogActivity("Task Added", $"'{dialog.TaskTitle}' added", "Tasks");
                RefreshTaskList();
                MessageBox.Show("Task added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CompleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TaskDataGrid.SelectedItem is UserTask selectedTask)
            {
                _taskService.CompleteTask(selectedTask.Id);
                _activityLogService.LogActivity("Task Completed", $"'{selectedTask.Title}' completed", "Tasks");
                RefreshTaskList();
                MessageBox.Show("Task marked as completed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a task first.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TaskDataGrid.SelectedItem is UserTask selectedTask)
            {
                if (MessageBox.Show($"Delete task '{selectedTask.Title}'?", "Confirm", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _taskService.DeleteTask(selectedTask.Id);
                    _activityLogService.LogActivity("Task Deleted", $"'{selectedTask.Title}' deleted", "Tasks");
                    RefreshTaskList();
                }
            }
            else
            {
                MessageBox.Show("Please select a task first.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            var tasks = _taskService.GetAllTasks();
            TaskDataGrid.ItemsSource = tasks;
            PendingCountTxt.Text = _taskService.GetPendingCount().ToString();
            CompletedCountTxt.Text = _taskService.GetCompletedCount().ToString();
        }

        public TaskService GetTaskService()
        {
            return _taskService;
        }

        public ActivityLogService GetActivityLogService()
        {
            return _activityLogService;
        }
    }
}
