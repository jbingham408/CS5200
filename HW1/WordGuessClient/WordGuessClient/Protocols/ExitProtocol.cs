using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //Exit protocol
    //Should send an ExitMessage and receive an AckMessage
    class ExitProtocol : Protocol
    {
        private Message message { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public ExitProtocol(WordGuessClient c, Sender s, Receiver r)
        {
            client = c;
            sender = s;
            receiver = r;
            message = null;
        }
        public override void Send()
        {
            message = new ExitMessage(client);
            sender.SendMessage(message);
        }

        public override void Receive()
        {
            message = new AckMessage(client);
            receiver.ReceiveMessage(message);
        }
    }
}
