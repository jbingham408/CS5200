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
    //sends a message to the server
    public class Sender
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Sender));

        private WordGuessClient client { get; set; }
        private static IPEndPoint myEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private readonly UdpClient myUdpClient;
        public IPEndPoint server { get; set; }

        //sets up the server endpoint
        public Sender(WordGuessClient c, UdpClient udpClient)
        {
            client = c;
            myUdpClient = udpClient;
            string address = client.GetAddressText();
            string port = client.GetPortText();
            if (address != null && port != null)
                server = EndPoint.GetEndPoint(address, port);
            logger.Debug(server);
        }

        //sends the message
        public void SendMessage(Message message)
        {
            if (server != null)
            { 
                byte[] b = message.Encode();
                logger.Debug(b);

                int bytesSent = myUdpClient.Send(b, b.Length, server);
                logger.InfoFormat("{0} bytes sent out of {1}", bytesSent, b.Length);
            }
        }
    }
}
