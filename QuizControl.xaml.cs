using System.Windows;
using System.Windows.Controls;
using CybersecurityChatbot.Services;

namespace CybersecurityChatbot
{
    public partial class QuizControl : UserControl
    {
        private readonly QuizService _quizService;
        private readonly ActivityLogService _activityLogService;
        private bool _isQuizActive = false;

        public QuizControl()
        {
            InitializeComponent();
            _quizService = new QuizService();
            _activityLogService = new ActivityLogService();
        }

        private void StartQuizBtn_Click(object sender, RoutedEventArgs e)
        {
            _quizService.StartQuiz();
            _isQuizActive = true;
            _activityLogService.LogActivity("Quiz Started", "User started the cybersecurity quiz", "Quiz");
            
            StartBtn.Visibility = Visibility.Collapsed;
            NextBtn.Visibility = Visibility.Visible;
            RestartBtn.Visibility = Visibility.Visible;
            
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            var question = _quizService.GetCurrentQuestion();
            if (question == null)
            {
                ShowResults();
                return;
            }

            QuestionTxt.Text = question.Question;
            QuestionNumTxt.Text = $"{_quizService.GetCurrentQuestionNumber()}/{_quizService.GetTotalQuestions()}";
            ScoreTxt.Text = _quizService.GetCurrentScore().ToString();

            var buttons = new[] { OptionBtn1, OptionBtn2, OptionBtn3, OptionBtn4 };
            for (int i = 0; i < question.Options.Count && i < buttons.Length; i++)
            {
                buttons[i].Content = question.Options[i];
                buttons[i].Visibility = Visibility.Visible;
                buttons[i].Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#44475A");
                buttons[i].IsEnabled = true;
            }

            for (int i = question.Options.Count; i < buttons.Length; i++)
            {
                buttons[i].Visibility = Visibility.Collapsed;
            }

            NextBtn.IsEnabled = false;
        }

        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && int.TryParse(btn.Tag.ToString(), out int selectedIndex))
            {
                bool isCorrect = _quizService.CheckAnswer(selectedIndex);
                
                // Highlight correct answer
                var buttons = new[] { OptionBtn1, OptionBtn2, OptionBtn3, OptionBtn4 };
                int correctIndex = _quizService.GetCorrectAnswerIndex();
                
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                }

                if (isCorrect)
                {
                    btn.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#50FA7B");
                    QuestionTxt.Text += "\n✅ Correct!";
                }
                else
                {
                    btn.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#FF5555");
                    if (correctIndex >= 0 && correctIndex < buttons.Length)
                    {
                        buttons[correctIndex].Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#50FA7B");
                    }
                    QuestionTxt.Text += "\n❌ Incorrect!";
                }

                ScoreTxt.Text = _quizService.GetCurrentScore().ToString();
                NextBtn.IsEnabled = true;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            _quizService.NextQuestion();
            if (_quizService.IsQuizComplete())
            {
                ShowResults();
            }
            else
            {
                DisplayQuestion();
            }
        }

        private void ShowResults()
        {
            _isQuizActive = false;
            string finalMessage = _quizService.GetFinalMessage();
            _activityLogService.LogActivity("Quiz Finished", $"Score: {_quizService.GetCurrentScore()}/{_quizService.GetTotalQuestions()}", "Quiz");
            
            QuestionTxt.Text = finalMessage;
            QuestionNumTxt.Text = "Quiz Complete!";
            
            var buttons = new[] { OptionBtn1, OptionBtn2, OptionBtn3, OptionBtn4 };
            foreach (var btn in buttons)
            {
                btn.Visibility = Visibility.Collapsed;
            }

            NextBtn.Visibility = Visibility.Collapsed;
            RestartBtn.Visibility = Visibility.Visible;
        }

        private void RestartBtn_Click(object sender, RoutedEventArgs e)
        {
            QuestionTxt.Text = "Click 'Start Quiz' to begin";
            QuestionNumTxt.Text = "0/10";
            ScoreTxt.Text = "0";
            
            var buttons = new[] { OptionBtn1, OptionBtn2, OptionBtn3, OptionBtn4 };
            foreach (var btn in buttons)
            {
                btn.Visibility = Visibility.Collapsed;
            }

            StartBtn.Visibility = Visibility.Visible;
            NextBtn.Visibility = Visibility.Collapsed;
            RestartBtn.Visibility = Visibility.Collapsed;
            _isQuizActive = false;
        }

        public ActivityLogService GetActivityLogService()
        {
            return _activityLogService;
        }
    }
}
