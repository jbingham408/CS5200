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

        private WordGuessClient client;
        private static IPEndPoint myEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private readonly UdpClient myUdpSocket;
        public IPEndPoint server { get; set; }

        public Sender(WordGuessClient c, UdpClient udpClient)
        {
            client = c;
            myUdpSocket = udpClient;
            string address = c.GetAddressText();
            string port = c.GetPortText();
            if (address != null && port != null)
                server = EndPoint.GetEndPoint(address, port);
            logger.Debug(server);
        }

        public void SendMessage(short messageType)
        {
            Message message = null;
            if (server != null)
            {
                switch (messageType)
                {
                    case (short)1:
                        message = new NewGameMessage(client);
                        logger.Info("New Game Message Sent");
                        break;
                    case (short)5:
                        message = new GetHintMessage(client);
                        logger.Info("Get Hint Message");
                        break;
                    case (short)7:
                        message = new ExitMessage(client);
                        logger.Info("Exit Message Sent");
                        break;
                    case (short)8:
                        message = new AckMessage(client);
                        logger.Info("Ack Message Sent");
                        break;
                }

                byte[] b = message.Encode();
                logger.Debug(b);

                int bytesSent = myUdpSocket.Send(b, b.Length, server);
                logger.InfoFormat("{0} bytes sent out of {1}", bytesSent, b.Length);
            }
        }
    }
}
