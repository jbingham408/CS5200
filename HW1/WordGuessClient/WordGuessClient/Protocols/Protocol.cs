using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    //basic protocol class
    public abstract class Protocol
    {
        private Message message { get; set; }
        private Sender sender { get; set; }
        private Receiver receiver { get; set; }
        private WordGuessClient client { get; set; }

        public abstract void Send();

        public abstract void Receive();
    }
}
