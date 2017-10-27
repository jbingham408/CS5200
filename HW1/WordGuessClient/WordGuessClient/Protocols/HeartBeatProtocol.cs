using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //Heartbeat Protocol
    //Should Receive a HeartBeatMessage and send an AckMessage
    class HeartBeatProtocol : Protocol
    {
        private Message message { get; set; }
        private byte[] bytes { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public HeartBeatProtocol(WordGuessClient c, Sender s, Receiver r)
        {
            client = c;
            sender = s;
            receiver = r;
            message = null;
        }

        public void Run()
        {
            while (true)
            {
                Receive();
                if (message.GetMessageType() == 10)
                    Send();
            }
        }
        public override void Send()
        {
            message = new AckMessage(client);
            sender.SendMessage(message);
        }

        public override void Receive()
        {
            message = new HeartBeatMessage(client);
            receiver.ReceiveMessage(message);
        }
    }
}
