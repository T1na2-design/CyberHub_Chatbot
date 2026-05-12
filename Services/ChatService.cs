using System;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class ChatService
    {
        private readonly MemoryService _memoryService;
        private readonly KeywordRecognizer _keywordRecognizer;
        private readonly RandomResponseManager _responseManager;
        private readonly SentimentAnalyzer _sentimentAnalyzer;

        public ChatService(MemoryService memoryService)
        {
            _memoryService = memoryService;
            _keywordRecognizer = new KeywordRecognizer();
            _responseManager = new RandomResponseManager();
            _sentimentAnalyzer = new SentimentAnalyzer();
        }

        public string GetResponse(string query)
        {
            // Sentiment prefix
            string prefix = _sentimentAnalyzer.GetSentimentPrefix(query);

            // Check for follow up
            if (_memoryService.Context.IsFollowUp(query) && !string.IsNullOrEmpty(_memoryService.Context.LastTopic))
            {
                return prefix + "Here is another tip on " + _memoryService.Context.LastTopic + ":\n" + 
                       _responseManager.GetRandomResponse(_memoryService.Context.LastTopic);
            }

            // Identify topic
            string topic = _keywordRecognizer.IdentifyTopic(query);
            if (!string.IsNullOrEmpty(topic))
            {
                _memoryService.Context.LastTopic = topic;
                _memoryService.Profile.FavoriteTopic = topic; // Simple interest tracking
                return prefix + "Let's talk about " + topic + ".\n" + _responseManager.GetRandomResponse(topic);
            }

            // Fallback
            return prefix + "I'm not sure I understand. Try asking about passwords, phishing, privacy, scanning, or browsing.";
        }
    }
}
