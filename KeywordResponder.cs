using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public class KeywordResponder
    {
        private Dictionary<string, List<string>> _responses;

        private Random _random = new Random();

        public KeywordResponder()
        {
            _responses = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>()
                    {
                        "Use long passwords with symbols and numbers.",
                        "Avoid using the same password everywhere.",
                        "Password managers help keep accounts secure."
                    }
                },

                {
                    "phishing",
                    new List<string>()
                    {
                        "Never click suspicious email links.",
                        "Check the sender carefully before opening attachments.",
                        "Phishing emails often create panic or urgency."
                    }
                },

                {
                    "privacy",
                    new List<string>()
                    {
                        "Review your privacy settings regularly.",
                        "Avoid sharing personal information publicly.",
                        "Use strong privacy controls on social media."
                    }
                },

                {
                    "scam",
                    new List<string>()
                    {
                        "Scammers often pretend to be trusted companies.",
                        "Never send money to strangers online.",
                        "Be cautious of offers that seem too good to be true."
                    }
                },

                {
                    "malware",
                    new List<string>()
                    {
                        "Keep antivirus software updated.",
                        "Avoid downloading files from unknown websites.",
                        "Malware can steal personal information."
                    }
                },

                {
                    "vpn",
                    new List<string>()
                    {
                        "VPNs help protect your internet traffic.",
                        "A VPN is useful on public Wi-Fi.",
                        "VPNs improve online privacy."
                    }
                },

                {
                    "firewall",
                    new List<string>()
                    {
                        "Firewalls help block unauthorised access.",
                        "Always keep your firewall enabled.",
                        "Firewalls add an extra security layer."
                    }
                }
            };
        }

        public string GetResponse(string input, out string matchedKeyword)
        {
            input = input.ToLower();

            foreach (var keyword in _responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    matchedKeyword = keyword;

                    List<string> responses = _responses[keyword];

                    int index = _random.Next(responses.Count);

                    return responses[index];
                }
            }

            matchedKeyword = "";

            return "";
        }

        public List<string> GetAllKeywords()
        {
            return _responses.Keys.ToList();
        }
    }
}
