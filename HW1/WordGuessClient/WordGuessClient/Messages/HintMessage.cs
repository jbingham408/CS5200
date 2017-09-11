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
    class HintMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string hint { get; set; }

        private static readonly ILog logger = LogManager.GetLogger(typeof(NewGameMessage));
        public override byte[] Encode()
        {
            logger.Debug("Encoding message");

            MemoryStream stream = new MemoryStream();

            return stream.ToArray();
        }

        public override Message Decode(MemoryStream stream)
        {
            logger.Debug("Decoding message");

            NewGameMessage message = null;
            //if (b != null)
            //{
            //    message = new NewGameMessage(client);
            //    MemoryStream stream = new MemoryStream(b);
            //    messageType = DecodeShort(stream);
            //    logger.InfoFormat("Message Type: {0}", message.messageType);
            //}

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
    }
}
