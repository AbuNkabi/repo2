using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private ChatBot _chatBot;

        public MainWindow()
        {
            InitializeComponent();

            _chatBot = new ChatBot();

            PlayVoiceGreeting();

            LoadAsciiArt();

            AppendBotMessage(_chatBot.GetGreeting());
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string input = UserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
                return;

            AppendUserMessage(input);

            string response = _chatBot.ProcessInput(input);

            AppendBotMessage(response);

            UserInput.Clear();
        }

        private void AppendUserMessage(string message)
        {
            ChatDisplay.Text += $"You: {message}\n\n";

            ChatScrollViewer.ScrollToBottom();
        }

        private void AppendBotMessage(string message)
        {
            ChatDisplay.Text += $"Bot: {message}\n\n";

            ChatScrollViewer.ScrollToBottom();
        }

        private void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("greeting.wav");

            player.Play();
        }

        private void LoadAsciiArt()
        {
            AsciiArtBlock.Text =
@"  _____       _               
 / ____|     | |              
| |     _   _| |__   ___ _ __ 
| |    | | | | '_ \ / _ \ '__|
| |____| |_| | |_) |  __/ |   
 \_____|\__, |_.__/ \___|_|   
         __/ |                
        |___/ ";
        }
    }
}