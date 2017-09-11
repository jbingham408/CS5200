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
            receiveMessage = new Receiver(myUdpClient);
            receiveThread = new Thread(new ThreadStart(receiveMessage.ReceiveMessage));
            receiveThread.Start();
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
            //if (!receiveThread.IsAlive)
            //    receiveThread.Start();

            Sender sendMessage = new Sender(this, myUdpClient);
            sendMessage.SendMessage();
            //receiveMessage.ReceiveMessage();
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
