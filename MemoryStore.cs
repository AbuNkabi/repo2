using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class MemoryStore
    {
        private Dictionary<string, string> _memory =
            new Dictionary<string, string>();

        public string UserName { get; set; }

        public string FavouriteTopic { get; set; }

        public void Store(string key, string value)
        {
            _memory[key] = value;
        }

        public string Recall(string key)
        {
            if (_memory.ContainsKey(key))
                return _memory[key];

            return "";
        }

        public string GetPersonalisedOpener()
        {
            if (!string.IsNullOrEmpty(FavouriteTopic))
            {
                return $"As someone interested in {FavouriteTopic}, ";
            }

            return "";
        }
    }
}
