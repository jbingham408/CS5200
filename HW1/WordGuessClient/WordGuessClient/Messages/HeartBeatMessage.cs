using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using log4net;
using System.IO;

namespace WordGuessClient
{
    class HeartBeatMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private WordGuessClient client;
        private bool correctGame;

        private static readonly ILog logger = LogManager.GetLogger(typeof(HeartBeatMessage));

        public HeartBeatMessage(WordGuessClient c)
        {
            messageType = 10;
            client = c;
            gameID = client.GetGameID();
        }
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override Message Decode(MemoryStream stream)
        {
            logger.Debug("Decoding message");

            HeartBeatMessage message = new HeartBeatMessage(client);
            message.gameID = DecodeShort(stream);
            if (message.gameID == this.gameID)
                correctGame = true;
            logger.Info("Message Type: HeartBeat");

            return message;
        }

        private static void EncodeShort(MemoryStream stream, short s)
        {
            byte[] b = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(s));
            stream.Write(b, 0, b.Length);
        }

        private static void EncodeString(MemoryStream stream, string s)
        {
            byte[] b = Encoding.BigEndianUnicode.GetBytes(s);
            EncodeShort(stream, (short)b.Length);
            stream.Write(b, 0, b.Length);
        }

        private static short DecodeShort(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

        private static string DecodeString(MemoryStream stream)
        {
            string message = String.Empty;
            int messageLength = DecodeShort(stream);
            if (messageLength > 0)
            {
                byte[] b = new byte[messageLength];
                int numOfBytes = stream.Read(b, 0, b.Length);
                if (numOfBytes != messageLength)
                    throw new ApplicationException("Decode String Failed");
                message = Encoding.BigEndianUnicode.GetString(b, 0, b.Length);
            }
            return message;
        }
        public bool GetCorrectGame()
        {
            return correctGame;
        }
    }
}
