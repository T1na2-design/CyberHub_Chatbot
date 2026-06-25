using System.Windows;

namespace CybersecurityChatbot
{
    public partial class AddTaskDialog : Window
    {
        public string TaskTitle { get; private set; } = string.Empty;
        public string TaskDescription { get; private set; } = string.Empty;
        public DateTime ReminderDate { get; private set; }

        public AddTaskDialog()
        {
            InitializeComponent();
            ReminderDatePicker.SelectedDate = DateTime.Now;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Please enter a task title.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TaskTitle = TitleBox.Text;
            TaskDescription = DescriptionBox.Text;
            ReminderDate = ReminderDatePicker.SelectedDate ?? DateTime.Now;

            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
