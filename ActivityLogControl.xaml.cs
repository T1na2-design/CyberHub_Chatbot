using System.Windows;
using System.Windows.Controls;
using System.IO;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    public partial class ActivityLogControl : UserControl
    {
        private readonly ActivityLogService _activityLogService;

        public ActivityLogControl()
        {
            InitializeComponent();
            _activityLogService = new ActivityLogService();
            RefreshActivityLog();
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshActivityLog();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Clear all activity logs?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _activityLogService.ClearLogs();
                RefreshActivityLog();
                MessageBox.Show("Activity logs cleared.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var logs = _activityLogService.GetAllLogs();
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                                               $"ActivityLog_{DateTime.Now:yyyy-MM-dd_HHmmss}.txt");
                
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("=== CyberHub Activity Log ===");
                    writer.WriteLine($"Exported: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine(new string('=', 50));
                    writer.WriteLine();

                    foreach (var log in logs)
                    {
                        writer.WriteLine(log.ToString());
                    }
                }

                MessageBox.Show($"Activity log exported to:\n{filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting log: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshActivityLog()
        {
            var logs = _activityLogService.GetRecentLogs(50);
            ActivityListBox.ItemsSource = logs;
            TotalEntriesTxt.Text = _activityLogService.GetLogCount().ToString();
        }

        public ActivityLogService GetActivityLogService()
        {
            return _activityLogService;
        }
    }
}
