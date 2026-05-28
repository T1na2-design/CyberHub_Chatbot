using System.Linq;
using CybersecurityChatbot.Models;

namespace CybersecurityChatbot.Services
{
    public class MemoryService
    {
        public UserProfile Profile { get; } = new UserProfile();
        public ConversationContext Context { get; } = new ConversationContext();

        public void RecordInteraction(string topic, string sentiment)
        {
            Profile.InteractionCount++;

            if (!string.IsNullOrEmpty(sentiment) && sentiment != "Neutral")
            {
                Profile.LastSentiment = sentiment;
            }

            if (!string.IsNullOrEmpty(topic))
            {
                Context.LastTopic = topic;
                if (!Profile.DiscussedTopics.Contains(topic))
                {
                    Profile.DiscussedTopics.Add(topic);
                }

                Profile.FavoriteTopic = topic;
            }
        }

        public string GetMemoryImprint()
        {
            // Occasionally bring up a previous topic
            if (Profile.InteractionCount % 4 == 0 && Profile.DiscussedTopics.Count > 1)
            {
                var previousTopic = Profile.DiscussedTopics.First();
                return $"\n\n(By the way, I remember we talked about {previousTopic} earlier. Let me know if you need more help with that!)";
            }

            // Reassure if they were previously anxious
            if (Profile.InteractionCount % 3 == 0 && Profile.LastSentiment == "Anxious")
            {
                return "\n\n(I know you were feeling a bit worried earlier. I hope this information is helping you feel more in control of your digital safety!)";
            }

            return string.Empty;
        }
    }
}