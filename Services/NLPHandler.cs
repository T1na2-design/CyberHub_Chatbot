namespace CybersecurityChatbot.Services
{
    public delegate void ResponseHandler(string response);

    public class NLPHandler
    {
        public enum Intent
        {
            Unknown,
            AddTask,
            StartQuiz,
            ShowLog,
            Chat
        }

        public event ResponseHandler? OnIntentDetected;

        public Intent DetectIntent(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Intent.Unknown;

            string lowerInput = input.ToLower().Trim();

            // Task Intent
            if (lowerInput.Contains("add task") || 
                lowerInput.Contains("new task") || 
                lowerInput.Contains("create task") ||
                lowerInput.Contains("remind me"))
            {
                return Intent.AddTask;
            }

            // Quiz Intent
            if (lowerInput.Contains("start quiz") || 
                lowerInput.Contains("play quiz") ||
                lowerInput.Contains("take quiz") ||
                lowerInput.Contains("begin quiz"))
            {
                return Intent.StartQuiz;
            }

            // Activity Log Intent
            if (lowerInput.Contains("show log") || 
                lowerInput.Contains("show activity") ||
                lowerInput.Contains("what have you done") ||
                lowerInput.Contains("activity log") ||
                lowerInput.Contains("show history"))
            {
                return Intent.ShowLog;
            }

            return Intent.Unknown;
        }

        public List<string> ExtractKeywords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<string>();

            var keywords = input.Split(new[] { ' ', ',', '.', '!', '?' }, 
                                      StringSplitOptions.RemoveEmptyEntries);
            return keywords.ToList();
        }

        public string GetIntentDescription(Intent intent)
        {
            return intent switch
            {
                Intent.AddTask => "Task Management",
                Intent.StartQuiz => "Cybersecurity Quiz",
                Intent.ShowLog => "Activity Log",
                Intent.Unknown => "General Chat",
                _ => "Unknown"
            };
        }

        public void TriggerResponse(string response)
        {
            OnIntentDetected?.Invoke(response);
        }
    }
}
