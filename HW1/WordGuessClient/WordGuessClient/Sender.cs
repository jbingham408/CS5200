using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Net;
using System.Net.Sockets;

namespace WordGuessClient
{
    public class Sender
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Sender));

        private readonly UdpClient myUdpSocket;

        private WordGuessClient clientForm;

        public IPEndPoint server { get; set; }

        public Sender(WordGuessClient c)
        {
            clientForm = c;
            string address = c.GetAddressText();
            string port = c.GetPortText();
            if (address != null && port != null)
                server = EndPoint.GetEndPoint(address, port);
            logger.Debug(server);
            myUdpSocket = new UdpClient(server);
        }

        public void SendMessage()
        {
            if (server != null)
            {
                Message message = new Message()
                {
                    messageType = 1,
                    aNum = "A001",
                    lastName = "Bingham",
                    firstName = "Jason",
                    alias = "Test"
                };

                byte[] b = message.Encode();

                int bytesSent = myUdpSocket.Send(b, b.Length, server);
                logger.Info("Sending Message");
            }
        }
    }
}
