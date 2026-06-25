namespace CybersecurityChatbot.Services
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectAnswerIndex { get; set; }
        public string Category { get; set; } = string.Empty;
    }

    public class QuizService
    {
        private List<QuizQuestion> _questions = new List<QuizQuestion>();
        private int _currentScore = 0;
        private int _currentQuestionIndex = 0;
        private List<QuizQuestion> _currentQuiz = new List<QuizQuestion>();

        public QuizService()
        {
            InitializeQuestions();
        }

        private void InitializeQuestions()
        {
            _questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Id = 1,
                    Question = "What is phishing?",
                    Options = new List<string>
                    {
                        "A legitimate email asking for personal info",
                        "Fraudulent attempt to collect sensitive information by deception",
                        "A type of fishing technique",
                        "A network protocol"
                    },
                    CorrectAnswerIndex = 1,
                    Category = "Phishing"
                },
                new QuizQuestion
                {
                    Id = 2,
                    Question = "True or False: Using '123456' as a password is secure?",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Category = "Passwords"
                },
                new QuizQuestion
                {
                    Id = 3,
                    Question = "What is the best practice for password length?",
                    Options = new List<string>
                    {
                        "At least 4 characters",
                        "At least 8 characters with mix of upper, lower, numbers, and symbols",
                        "Password length doesn't matter",
                        "12 characters minimum"
                    },
                    CorrectAnswerIndex = 1,
                    Category = "Passwords"
                },
                new QuizQuestion
                {
                    Id = 4,
                    Question = "True or False: You should share your password with trusted friends?",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Category = "Passwords"
                },
                new QuizQuestion
                {
                    Id = 5,
                    Question = "Which of these is safe to do on public WiFi?",
                    Options = new List<string>
                    {
                        "Check your bank account",
                        "Browse using HTTPS and a VPN",
                        "Share personal documents",
                        "Update sensitive passwords"
                    },
                    CorrectAnswerIndex = 1,
                    Category = "Browsing"
                },
                new QuizQuestion
                {
                    Id = 6,
                    Question = "What is social engineering?",
                    Options = new List<string>
                    {
                        "Building social media accounts",
                        "Manipulating people into divulging confidential info",
                        "Attending social events",
                        "Creating a social network"
                    },
                    CorrectAnswerIndex = 1,
                    Category = "Social Engineering"
                },
                new QuizQuestion
                {
                    Id = 7,
                    Question = "True or False: You should click suspicious links to see what they are?",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 1,
                    Category = "Phishing"
                },
                new QuizQuestion
                {
                    Id = 8,
                    Question = "What should you do if you receive an unsolicited phone call requesting personal information?",
                    Options = new List<string>
                    {
                        "Provide the information to be helpful",
                        "Hang up and verify through official channels",
                        "Ask for their manager",
                        "Give partial information"
                    },
                    CorrectAnswerIndex = 1,
                    Category = "Social Engineering"
                },
                new QuizQuestion
                {
                    Id = 9,
                    Question = "What does HTTPS stand for?",
                    Options = new List<string>
                    {
                        "Hypertext Transfer Protocol Secure",
                        "High Transfer Protocol System",
                        "Hypertext Transfer Protection Service",
                        "Host Transfer Process Secure"
                    },
                    CorrectAnswerIndex = 0,
                    Category = "Browsing"
                },
                new QuizQuestion
                {
                    Id = 10,
                    Question = "True or False: Two-factor authentication makes accounts more secure?",
                    Options = new List<string> { "True", "False" },
                    CorrectAnswerIndex = 0,
                    Category = "Passwords"
                }
            };
        }

        public void StartQuiz()
        {
            _currentQuiz = new List<QuizQuestion>(_questions);
            _currentQuiz = _currentQuiz.OrderBy(q => Guid.NewGuid()).ToList();
            _currentScore = 0;
            _currentQuestionIndex = 0;
        }

        public QuizQuestion? GetCurrentQuestion()
        {
            if (_currentQuestionIndex < _currentQuiz.Count)
            {
                return _currentQuiz[_currentQuestionIndex];
            }
            return null;
        }

        public bool CheckAnswer(int selectedIndex)
        {
            var currentQuestion = GetCurrentQuestion();
            if (currentQuestion == null)
                return false;

            if (selectedIndex == currentQuestion.CorrectAnswerIndex)
            {
                _currentScore++;
                return true;
            }
            return false;
        }

        public void NextQuestion()
        {
            _currentQuestionIndex++;
        }

        public bool IsQuizComplete()
        {
            return _currentQuestionIndex >= _currentQuiz.Count;
        }

        public int GetCurrentScore()
        {
            return _currentScore;
        }

        public int GetTotalQuestions()
        {
            return _currentQuiz.Count;
        }

        public int GetCurrentQuestionNumber()
        {
            return _currentQuestionIndex + 1;
        }

        public int GetCorrectAnswerIndex()
        {
            var question = GetCurrentQuestion();
            return question?.CorrectAnswerIndex ?? -1;
        }

        public string GetFinalMessage()
        {
            int percentage = (_currentScore * 100) / _currentQuiz.Count;
            
            if (percentage >= 90)
                return $"🎉 Excellent! You scored {_currentScore}/{_currentQuiz.Count} ({percentage}%)! You're a cybersecurity expert!";
            else if (percentage >= 70)
                return $"👍 Great job! You scored {_currentScore}/{_currentQuiz.Count} ({percentage}%)! Keep learning!";
            else if (percentage >= 50)
                return $"👌 Good effort! You scored {_currentScore}/{_currentQuiz.Count} ({percentage}%)! Review the topics to improve.";
            else
                return $"📚 Keep studying! You scored {_currentScore}/{_currentQuiz.Count} ({percentage}%)! Review cybersecurity basics.";
        }
    }
}
