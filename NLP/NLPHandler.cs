using System;

namespace CyberHub_Chatbot.NLP
{
    public enum IntentType
    {
        Unknown,
        Task,
        Reminder,
        Quiz,
        Log
    }

    public delegate string ResponseHandler(string userMessage, IntentType intent);

    public class NLPHandler
    {
        public IntentType DetectIntent(string input)
        {
            var text = (input ?? "").ToLower();

            if (text.Contains("add task") || text.Contains("new task") || text.Contains("create task"))
                return IntentType.Task;

            if (text.Contains("remind me") || text.Contains("reminder"))
                return IntentType.Reminder;

            if (text.Contains("start quiz") || text.Contains("play quiz") || text.Contains("quiz"))
                return IntentType.Quiz;

            if (text.Contains("show log") || text.Contains("show activity log") || text.Contains("what have you done"))
                return IntentType.Log;

            return IntentType.Unknown;
        }
    }
}
