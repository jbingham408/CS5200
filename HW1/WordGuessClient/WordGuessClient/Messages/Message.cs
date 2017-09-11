using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using log4net;

namespace WordGuessClient
{
    public class Message
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Message));

        public short messageType { get; set; }
        public string aNum { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string alias { get; set; }
        public short gameID { get; set; }
        public string hint { get; set; }
        public string definition { get; set; }

        public byte[] Encode()
        {
            logger.Debug("Encoding message");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            EncodeString(stream, aNum);
            EncodeString(stream, lastName);
            EncodeString(stream, firstName);
            EncodeString(stream, alias);

            return stream.ToArray();
        }

        public static Message Decode(byte[] b)
        {
            logger.Debug("Decoding message");

            Message message = null;
            if(b != null)
            {
                message = new Message();
                MemoryStream stream = new MemoryStream(b);
                message.messageType = DecodeShort(stream);
                logger.InfoFormat("Message Type: {0}", message.messageType);
                //message.gameID = DecodeShort(stream);
                //message.hint = DecodeString(stream);
                //message.definition = DecodeString(stream);
            }

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
            if(numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

        private static string DecodeString(MemoryStream stream)
        {
            string message =  String.Empty;
            int messageLength = DecodeShort(stream);
            if (messageLength > 0)
            {
                byte[] b = new byte[messageLength];
                int numOfBytes = stream.Read(b, 0, b.Length);
                if(numOfBytes != messageLength)
                    throw new ApplicationException("Decode String Failed");
                message = Encoding.BigEndianUnicode.GetString(b, 0, b.Length);
            }
            return message;
        }
    }
}
