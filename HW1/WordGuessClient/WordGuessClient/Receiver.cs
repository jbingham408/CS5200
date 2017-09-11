﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Net;
using System.Net.Sockets;

namespace WordGuessClient
{
    public class Receiver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Receiver));
        private readonly UdpClient myUdpClient;
        public Message message = null;

        public Receiver(UdpClient udpClient)
        {
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
                logger.Debug("Entering Receive");
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
                    //endReceive = true;
                    message = Message.Decode(b);
                    if (message != null)
                        logger.Info("Message Successfully Received");
                    else
                        logger.Info("Message Failed to Receive");
                }
                else
                    logger.Debug("No message received");
                logger.Debug("Leaving Receive");
            }
        }
    }
}
