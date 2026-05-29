
using System;
using System.Media;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder _keywords;
        private SentimentDetector _sentiment;
        private MemoryStore _memory;

        private bool _awaitingName = true;

        private string _lastTopic = "";

        private Random _random = new Random();

        public ChatBot()
        {
            _keywords = new KeywordResponder();
            _sentiment = new SentimentDetector();
            _memory = new MemoryStore();
        }

        // METHOD TO PLAY AUDIO
        private void PlayAudio(string audioPath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(audioPath);
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio error: " + ex.Message);
            }
        }

        public string GetGreeting()
        {
            // PLAY GREETING AUDIO
            PlayAudio("greeting.wav");

            return "Hello! What is your name?";
        }

        public string ProcessInput(string input)
        {
            input = input.Trim();

            // STEP 1 - CAPTURE NAME
            if (_awaitingName)
            {
                _memory.UserName = input;

                _awaitingName = false;

                // PLAY WELCOME AUDIO
                PlayAudio("welcome.wav");

                return $"Welcome {_memory.UserName}! Ask me anything about cybersecurity.";
            }

            // STEP 2 - FOLLOW-UP
            if (input.ToLower().Contains("tell me more") ||
                input.ToLower().Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                {
                    PlayAudio("info.wav");

                    return $"Here is more information about {_lastTopic}: always stay informed and practice safe online habits.";
                }

                return "Please mention a topic first.";
            }

            // STEP 3 - SENTIMENT
            Sentiment detected = _sentiment.Detect(input);

            string sentimentResponse =
                _sentiment.GetSentimentResponse(detected);

            // STEP 4 - KEYWORDS
            string matchedKeyword;

            string keywordResponse =
                _keywords.GetResponse(input, out matchedKeyword);

            if (!string.IsNullOrEmpty(keywordResponse))
            {
                _lastTopic = matchedKeyword;

                if (input.ToLower().Contains("interested in"))
                {
                    _memory.FavouriteTopic = matchedKeyword;
                }

                // PLAY RESPONSE AUDIO
                PlayAudio("response.wav");

                return sentimentResponse +
                       _memory.GetPersonalisedOpener() +
                       keywordResponse;
            }

            // STEP 5 - SPECIAL PHRASES
            if (input.ToLower().Contains("how are you"))
            {
                PlayAudio("status.wav");

                return "I am functioning perfectly and ready to help.";
            }

            if (input.ToLower().Contains("what can you do"))
            {
                PlayAudio("abilities.wav");

                return "I can help with passwords, phishing, scams, malware, privacy, VPNs and firewalls.";
            }

            if (input.ToLower().Contains("purpose"))
            {
                PlayAudio("purpose.wav");

                return "My purpose is to improve cybersecurity awareness.";
            }

            // STEP 6 - FALLBACK
            string[] fallbackResponses =
            {
                "Can you tell me more about that?",
                "Interesting. Ask me something cybersecurity related.",
                "I am still learning. Try asking about online safety."
            };

            PlayAudio("fallback.wav");

            return fallbackResponses[
                _random.Next(fallbackResponses.Length)];
        }
    }
}
