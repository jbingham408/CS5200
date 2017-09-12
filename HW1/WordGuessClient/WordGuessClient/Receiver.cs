using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WordGuessClient
{
    public class Receiver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Receiver));
        private readonly UdpClient myUdpClient;
        //public Message newMessage = null;
        private WordGuessClient client;

        public Receiver(UdpClient udpClient, WordGuessClient c)
        {
            client = c;
            myUdpClient = udpClient;
            myUdpClient.Client.ReceiveTimeout = 1000;
        }

        public IPEndPoint ClientEndPoint
        {
            get
            {
                IPEndPoint address = null;
                if (myUdpClient != null)
                    address = myUdpClient.Client.LocalEndPoint as IPEndPoint;
                return address;
            }
        }

        public void ReceiveMessage()
        {
            bool endReceive = false;
            while (!endReceive)
            {
                logger.Info("---Checking for message---");
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] b = null;

                try
                {
                    b = myUdpClient.Receive(ref serverEndPoint);
                }
                catch(SocketException e)
                {
                    logger.Debug("catch");
                    if (e.SocketErrorCode != SocketError.TimedOut)
                        throw;
                }

                if (b != null)
                {
                    MemoryStream stream = new MemoryStream(b);
                    short messageType = GetMessageType(stream);

                    switch (messageType)
                    {
                        case (short)2:
                            GameDefMessage gameDefMessage = new GameDefMessage(client);
                            gameDefMessage.Decode(stream);
                            endReceive = true;
                            break;
                        case (short)8:
                            AckMessage ackMessage = new AckMessage(client);
                            ackMessage.Decode(stream);
                            if (ackMessage.GetCorrectGame())
                                endReceive = true;
                            break;
                        case (short)10:
                            HeartBeatMessage heartBeat = new HeartBeatMessage(client);
                            heartBeat.Decode(stream);
                            if(heartBeat.GetCorrectGame())
                            {
                                Sender sender = new Sender(client, myUdpClient);
                                sender.SendMessage(8);
                            }
                            break;
                    }
                }
                else
                    logger.Debug("No message received");
            }
        }

        private static short GetMessageType(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }
    }
}
