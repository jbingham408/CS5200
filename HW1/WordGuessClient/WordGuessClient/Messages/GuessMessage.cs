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
    //Guess message class
    //Tells the program what needs to go in the message and the order it should appear
    public class GuessMessage : Message
    {
        public short messageType { get; set; }
        public short gameID { get; set; }
        public string guess { get; set; }
        public WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(GuessMessage));

        public GuessMessage() { }
        public GuessMessage(WordGuessClient c)
        {
            messageType = 3;
            client = c;
            gameID = client.GetGameID();
            guess = client.GetGuessText();
        }

        //Encodes the message in the correct order
        public override byte[] Encode()
        {
            logger.Info("Encoding Message Type: Guess");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            logger.InfoFormat("Game Id: {0}", this.gameID);
            EncodeShort(stream, gameID);
            logger.InfoFormat("Guess: {0}", this.guess);
            EncodeString(stream, guess);

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
