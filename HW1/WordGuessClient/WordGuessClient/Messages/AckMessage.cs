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
    class AckMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private WordGuessClient client;
        private static readonly ILog logger = LogManager.GetLogger(typeof(AckMessage));

        public AckMessage(WordGuessClient c, short id)
        {
            client = c;
            gameID = id;
            messageType = 8;
        }
        public override byte[] Encode()
        {
            logger.Debug("Encoding Message Type: Ack");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            EncodeShort(stream, gameID);

            return stream.ToArray();
        }

        public override Message Decode(MemoryStream stream)
        {
            logger.Debug("Decoding message");
            short id = 0;

            AckMessage message = null;
           // if (b != null)
           // {
                //MemoryStream stream = new MemoryStream(b);
                id = DecodeShort(stream);
                message = new AckMessage(client, id);
                logger.Info("Message Type: Ack");
           // }

            return message;
        }

        private static void EncodeShort(MemoryStream stream, short s)
        {
            byte[] b = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(s));
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
    }
}
