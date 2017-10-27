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
    //New Message class
    //Controls what information sent and the order it should appear in the message
    public class NewGameMessage : Message
    {
        public short messageType { get; set; }
        public string aNum { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string alias { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(NewGameMessage));
        private static WordGuessClient client { get; set; }

        public NewGameMessage() { }
        public NewGameMessage(WordGuessClient c)
        {
            client = c;
            messageType = 1;
            aNum = c.GetANumText();
            if (aNum == "")
                aNum = "Junk";
            lastName = c.GetLastNameText();
            if (lastName == "")
                lastName = "Junk";
            firstName = c.GetFirstNameText();
            if (firstName == "")
                firstName = "Junk";
            alias = c.GetAliasText();
            if (alias == "")
                alias = "Junk";
        }

        //Encodes the message
        public override byte[] Encode()
        {
            logger.Info("Encoding Message Type: New Game");

            MemoryStream stream = new MemoryStream();
            EncodeShort(stream, messageType);
            logger.InfoFormat("A#: {0}", this.aNum);
            EncodeString(stream, aNum);
            logger.InfoFormat("Last Name: {0}", lastName);
            EncodeString(stream, lastName);
            logger.InfoFormat("First Name: {0}", firstName);
            EncodeString(stream, firstName);
            logger.InfoFormat("Alias: {0}", alias);
            EncodeString(stream, alias);

            return stream.ToArray();
        }

        public override void EncodeShort(MemoryStream stream, short s)
        {
            byte[] b = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(s));
            stream.Write(b, 0, b.Length);
        }

        public override void EncodeString(MemoryStream stream, string s)
        {
            byte[] b = Encoding.BigEndianUnicode.GetBytes(s);
            EncodeShort(stream, (short)b.Length);
            stream.Write(b, 0, b.Length);
        }

        public override Message Decode(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override short DecodeShort(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override string DecodeString(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override bool GetCorrectGame()
        {
            throw new NotImplementedException();
        }

        public override byte DecodeByte(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override short GetMessageType()
        {
            throw new NotImplementedException();
        }
    }
}
