using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated,
        Happy
    }

    public class SentimentDetector
    {
        private Dictionary<Sentiment, List<string>> _triggers;

        public SentimentDetector()
        {
            _triggers = new Dictionary<Sentiment, List<string>>()
            {
                {
                    Sentiment.Worried,
                    new List<string>()
                    {
                        "worried",
                        "scared",
                        "afraid",
                        "unsafe"
                    }
                },

                {
                    Sentiment.Curious,
                    new List<string>()
                    {
                        "curious",
                        "wondering",
                        "how does",
                        "interested"
                    }
                },

                {
                    Sentiment.Frustrated,
                    new List<string>()
                    {
                        "confused",
                        "annoyed",
                        "frustrated"
                    }
                },

                {
                    Sentiment.Happy,
                    new List<string>()
                    {
                        "great",
                        "awesome",
                        "thanks",
                        "helpful"
                    }
                }
            };
        }

        public Sentiment Detect(string input)
        {
            input = input.ToLower();

            foreach (var pair in _triggers)
            {
                foreach (string word in pair.Value)
                {
                    if (input.Contains(word))
                    {
                        return pair.Key;
                    }
                }
            }

            return Sentiment.Neutral;
        }

        public string GetSentimentResponse(Sentiment sentiment)
        {
            switch (sentiment)
            {
                case Sentiment.Worried:
                    return "I understand your concern. ";

                case Sentiment.Curious:
                    return "That's a great question. ";

                case Sentiment.Frustrated:
                    return "Cybersecurity can definitely feel confusing sometimes. ";

                case Sentiment.Happy:
                    return "I'm glad this is helping you. ";

                default:
                    return "";
            }
        }
    }
}