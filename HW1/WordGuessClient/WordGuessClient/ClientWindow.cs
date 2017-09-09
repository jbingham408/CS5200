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

namespace WordGuessClient
{
    public partial class WordGuessClient : Form
    {
        public static Receiver receiveMessage = new Receiver();
        public Thread receiveThread = new Thread(new ThreadStart(receiveMessage.ReceiveMessage));

        public WordGuessClient()
        {
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

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            if (!receiveThread.IsAlive)
                receiveThread.Start();

            Sender sendMessage = new Sender(this);
            sendMessage.SendMessage();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (receiveThread.IsAlive)
            {
                receiveThread.Abort();
                receiveThread.Join();
            }
            Application.Exit();
        }
    }
}
