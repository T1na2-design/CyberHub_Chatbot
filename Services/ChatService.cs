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
            // Sentiment analysis
            var (prefix, sentiment) = _sentimentAnalyzer.Analyze(query);

            // Topic Identification
            string topic = _keywordRecognizer.IdentifyTopic(query);

            // Check for follow up
            if (_memoryService.Context.IsFollowUp(query) && !string.IsNullOrEmpty(_memoryService.Context.LastTopic))
            {
                topic = _memoryService.Context.LastTopic;
                _memoryService.RecordInteraction(topic, sentiment);
                string memoryImprint = _memoryService.GetMemoryImprint();

                return prefix + "Here is another tip on " + topic + ":\n" + 
                       _responseManager.GetRandomResponse(topic) + memoryImprint;
            }

            if (!string.IsNullOrEmpty(topic))
            {
                _memoryService.RecordInteraction(topic, sentiment);
                string memoryImprint = _memoryService.GetMemoryImprint();

                return prefix + "Let's talk about " + topic + ".\n" + _responseManager.GetRandomResponse(topic) + memoryImprint;
            }

            // Fallback
            _memoryService.RecordInteraction(string.Empty, sentiment);
            return prefix + "I'm not sure I understand. Try asking about passwords, phishing, privacy, scanning, or browsing.";
        }
    }
}
