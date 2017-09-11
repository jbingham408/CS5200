using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    public class NewGameMessage : Message
    {
        private short messageType { get; set; }
        private string aNum { get; set; }
        private string lastName { get; set; }
        private string firstName { get; set; }
        private string alias { get; set; }

        private static readonly ILog logger = LogManager.GetLogger(typeof(NewGameMessage));
        private static WordGuessClient client;

        public NewGameMessage(WordGuessClient c)
        {
            client = c;
            messageType = 1;
            aNum = c.GetANumText();
            lastName = c.GetLastNameText();
            firstName = c.GetFirstNameText();
            alias = c.GetAliasText();
        }

        public override byte[] Encode()
        {
            logger.Debug("Encoding Message Type: New Game");

            MemoryStream stream = new MemoryStream();
            EncodeShort(stream, messageType);
            EncodeString(stream, aNum);
            EncodeString(stream, lastName);
            EncodeString(stream, firstName);
            EncodeString(stream, alias);

            return stream.ToArray();
        }

        public override Message Decode(MemoryStream stream)
        {
            throw new NotImplementedException();
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
