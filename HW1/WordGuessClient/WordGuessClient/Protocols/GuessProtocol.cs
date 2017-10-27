using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //Guess protocol
    //Should send a GuessMessage and recieve an AnswerMessage
    class GuessProtocol : Protocol
    {
        private Message message { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public GuessProtocol(WordGuessClient c, Sender s, Receiver r)
        {
            client = c;
            sender = s;
            receiver = r;
            message = null;
        }
        public override void Send()
        {
            message = new GuessMessage(client);
            sender.SendMessage(message);
        }

        public override void Receive()
        {
            message = new AnswerMessage(client);
            receiver.ReceiveMessage(message);
        }
    }
}
