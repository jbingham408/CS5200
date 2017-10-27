using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace WordGuessClient
{
    public class Receiver
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Receiver));
        private readonly UdpClient myUdpClient;
        private WordGuessClient client { get; set; }
        private List<byte[]> messageQueue { get; set; }

        public Receiver(WordGuessClient c, UdpClient udpClient)
        {
            client = c;
            myUdpClient = udpClient;
            myUdpClient.Client.ReceiveTimeout = 1000;
            messageQueue = new List<byte[]>();
        }

        //listens for a message from the server
        //it will loop until it receives a message unless it is a heartbeat, then it will continue listening
        public void ReceiveMessage(Message message)
        {
            bool endReceive = false;
            while (!endReceive)
            {
                logger.Info("---Checking for message---");
                IPEndPoint serverEndPoint = EndPoint.GetEndPoint(client.GetAddressText(), client.GetPortText());

                byte[] b = null;

                try
                {
                    b = myUdpClient.Receive(ref serverEndPoint);
                }
                catch(SocketException e)
                {
                    if (e.SocketErrorCode != SocketError.TimedOut)
                        throw;
                }

                if (b != null)
                {
                    messageQueue.Add(b);
                }
                else
                    logger.Debug("No message received");

                if (messageQueue.Count > 0)
                {
                    MemoryStream stream = new MemoryStream(messageQueue.First());
                    MemoryStream tempStream = new MemoryStream(messageQueue.First());
                    short temp = GetMessageType(tempStream);

                    if (temp == 9)
                        message = new ErrorMessage(client);
                    message.Decode(stream);
                    if (message.GetMessageType() == 10 || message.GetCorrectGame())
                        endReceive = true;
                    //messageQueue.Remove(messageQueue.First());
                }
            }
        }

        //returns the message type of the received message
        private static short GetMessageType(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

        public void ClearQueue()
        {
            messageQueue.Clear();
        }
    }
}
