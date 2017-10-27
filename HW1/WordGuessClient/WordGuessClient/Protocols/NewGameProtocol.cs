using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //New Game Protocol
    //Controls which message it should send and what it should receive in the exchange
    //Should send a NewGameMessage and receive a GameDefMessage
    class NewGameProtocol : Protocol
    {
        private Message message { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public NewGameProtocol(WordGuessClient c, Sender s, Receiver r)
        {
            client = c;
            sender = s;
            receiver = r;
            message = null;
        }
        //sends the message
        public override void Send()
        {
            message = new NewGameMessage(client);
            sender.SendMessage(message);
        }
        //recevies the message
        public override void Receive()
        {
            message = new GameDefMessage(client);
            receiver.ReceiveMessage(message);
        }
    }
}
