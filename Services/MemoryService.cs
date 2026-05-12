using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class MemoryService
    {
        public UserProfile Profile { get; } = new UserProfile();
        public ConversationContext Context { get; } = new ConversationContext();
    }
}