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
        public static Receiver receiveMessage;
        public Thread receiveThread;
        private readonly UdpClient myUdpClient;

        public WordGuessClient()
        {
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            myUdpClient = new UdpClient(clientEndPoint);
            receiveMessage = new Receiver(myUdpClient, this);
            receiveThread = new Thread(new ThreadStart(receiveMessage.ReceiveMessage));
            //receiveThread.Start();
            InitializeComponent();
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

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            Sender sendMessage = new Sender(this, myUdpClient);
            sendMessage.SendMessage(1);
            receiveMessage.ReceiveMessage();
            receiveThread.Start();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (receiveThread.IsAlive)
            {
                receiveThread.Abort();
                receiveThread.Join();
            }

            Sender sendMessage = new Sender(this, myUdpClient);
            sendMessage.SendMessage(7);
            receiveMessage.ReceiveMessage();

            Application.Exit();
        }
    }
}
