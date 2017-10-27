using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace WordGuessClient
{
    public partial class WordGuessClient : Form
    {
        public static Receiver receiveMessage { get; set; }
        public Thread heartBeatThread { get; set; }
        private readonly UdpClient myUdpClient;
        private ManualResetEvent threadReset = new ManualResetEvent(false);
        private Sender sendMessage { get; set; }
        private Protocol protocol { get; set; }
        HeartBeatProtocol heartBeat { get; set; }

        //Initalizes the application and creates the UdpClient
        public WordGuessClient()
        {
            InitializeComponent();
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 0);
            myUdpClient = new UdpClient(clientEndPoint);
            sendMessage = new Sender(this, myUdpClient);
            receiveMessage = new Receiver(this, myUdpClient);
            heartBeat = new HeartBeatProtocol(this, sendMessage, receiveMessage);
            heartBeatThread = new Thread(new ThreadStart(heartBeat.Run));
        }

        public string GetAddressText()
        {
            return addressTextBox.Text;
        }

        public string GetPortText()
        {
            return portTextBox.Text;
        }

        public string GetANumText()
        {
            return aNumTextBox.Text;
        }

        public string GetLastNameText()
        {
            return lastNameTextBox.Text;
        }

        public string GetFirstNameText()
        {
            return firstNameTextBox.Text;
        }

        public string GetAliasText()
        {
            return aliasTextBox.Text;
        }
        public short GetGameID()
        {
              return Convert.ToInt16(gameIdLabel.Text);
        }

        public string GetGuessText()
        {
            return guessTextbox.Text;
        }

        public void SetHintText(string hint)
        {
            hintTextBox.Text = hint;
        }

        public void SetDefTextBox(string definition)
        {
            definitionTextBox.Text = definition;
        }

        public void SetGameIdLabel(short id)
        {
            gameIdLabel.Text = id.ToString();
        }

        public void SetGuessTextBox(string hint)
        {
            guessTextbox.Text = hint;
        }

        public void SetNumCharLabel(short num)
        {
            numOfCharLabel.Text = num.ToString();
        }

        public void SetIncorrectText(string incorrectText)
        {
            incorrectLabel.Text = incorrectText;
        }

        public void ShowPlayerScore(short score)
        {
            scoreLabel.Visible = true;
            playerScoreLabel.Text = score.ToString();
            playerScoreLabel.Visible = true;
        }

        public void SetErrorText(string error)
        {
            errorTextBox.Text = error;
        }

        //starts a new game
        //if a game is already going to clears out all information about the current game
        //then starts the heartbeatThread to listen for the heartbeat
        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            if (heartBeatThread.IsAlive)
            {
                protocol = new ExitProtocol(this, sendMessage, receiveMessage);
                protocol.Send();
                protocol.Receive();
                heartBeatThread.Abort();
                heartBeatThread.Join();
            }

            receiveMessage.ClearQueue();
            guessTextbox.Text = "";
            incorrectLabel.Text = "";
            scoreLabel.Visible = false;
            playerScoreLabel.Visible = false;
            protocol = new NewGameProtocol(this, sendMessage, receiveMessage);
            protocol.Send();
            protocol.Receive();

            heartBeatThread = new Thread(new ThreadStart(heartBeat.Run));
            heartBeatThread.Start();
        }

        //stops the heartbeat thread and sends the exit message
        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (heartBeatThread.IsAlive)
            {
                heartBeatThread.Abort();
                heartBeatThread.Join();
            }

            protocol = new ExitProtocol(this, sendMessage, receiveMessage);
            protocol.Send();
            protocol.Receive();

            Application.Exit();
        }

        //sends the gethint message when the hint button is pressed
        private void hintBtn_Click(object sender, EventArgs e)
        {
            if (heartBeatThread.IsAlive)
            {
                heartBeatThread.Abort();
                heartBeatThread.Join();
            }

            protocol = new HintProtocol(this, sendMessage, receiveMessage);
            protocol.Send();
            protocol.Receive();

            heartBeatThread = new Thread(new ThreadStart(heartBeat.Run));
            heartBeatThread.Start();
        }

        //sends the guess message when the guess button is pressed
        private void guessBtn_Click(object sender, EventArgs e)
        {
            if (heartBeatThread.IsAlive)
            {
                heartBeatThread.Abort();
                heartBeatThread.Join();
            }

            protocol = new GuessProtocol(this, sendMessage, receiveMessage);
            protocol.Send();
            protocol.Receive();

            heartBeatThread = new Thread(new ThreadStart(heartBeat.Run));
            heartBeatThread.Start();
        }

        private void guessTextbox_Enter(object sender, EventArgs e)
        {
            incorrectLabel.Text = "";
        }
    }
}
