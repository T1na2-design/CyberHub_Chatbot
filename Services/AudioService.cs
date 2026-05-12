using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace CybersecurityChatbot.Services
{
    public class AudioService
    {
        private const string GreetingAudioPath = "Audio/greeting.wav"; //Chatbot welcome greeting audio file path

        public async Task PlayVoiceGreetingAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(GreetingAudioPath))
                    {
                        using var player = new SoundPlayer(GreetingAudioPath);
                        player.PlaySync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Audio playback failed: {ex.Message}");
                }
            });
        }
    }
}
