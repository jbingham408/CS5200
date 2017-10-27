using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //hint protocol
    //Should send a GetHintMessage and receive a HintMessage
    class HintProtocol : Protocol
    {
        private Message message { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public HintProtocol(WordGuessClient c, Sender s, Receiver r)
        {
            client = c;
            sender = s;
            receiver = r;
            message = null;
        }
        public override void Send()
        {
            message = new GetHintMessage(client);
            sender.SendMessage(message);
        }

        public override void Receive()
        {
            message = new HintMessage(client);
            receiver.ReceiveMessage(message);
        }
    }
}
