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
    //Exit Message class
    //Tells the program what needs to be in the message and the order
    public class ExitMessage : Message
    {
        public short messageType { get; set; }
        public short gameID { get; set; }
        public WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(ExitMessage));

        public ExitMessage() { }
        public ExitMessage(WordGuessClient c)
        {
            messageType = 7;
            client = c;
            gameID = client.GetGameID();
        }

        //Encodes the message
        public override byte[] Encode()
        {
            logger.Info("Encoding Message Type: Exit");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            logger.InfoFormat("Game Id: {0}", gameID);
            EncodeShort(stream, gameID);

            logger.Info("Exiting game");
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
