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
    //Ack Message Class
    //Tells the program how to decode and encode these types of messages and the order the information will appear in
    public class AckMessage : Message
    {
        public short messageType { get; set; }
        public short gameID { get; set; }
        public bool correctGame { get; set; }
        public WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(AckMessage));

        public AckMessage() { }
        public AckMessage(WordGuessClient c)
        {
            client = c;
            gameID = client.GetGameID();
            messageType = 8;
            correctGame = false;
        }

        //Encodes the message
        public override byte[] Encode()
        {
            logger.Info("Encoding Message Type: Ack");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            logger.InfoFormat("Game Id: {0}", gameID);
            EncodeShort(stream, gameID);

            return stream.ToArray();
        }

        //Decodes the message
        public override Message Decode(MemoryStream stream)
        {
            logger.Info("Decoding Message Type: Ack");

            AckMessage message = new AckMessage(client);
            message.messageType = DecodeShort(stream);
            message.gameID = DecodeShort(stream);
            logger.InfoFormat("Game ID: {0}", message.gameID);
            if (message.gameID == this.gameID)
                correctGame = true;

            return message;
        }

        public override void EncodeShort(MemoryStream stream, short s)
        {
            byte[] b = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(s));
            stream.Write(b, 0, b.Length);
        }

        public override short DecodeShort(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

        public override bool GetCorrectGame()
        {
            return correctGame;
        }

        public override void EncodeString(MemoryStream stream, string s)
        {
            throw new NotImplementedException();
        }

        public override string DecodeString(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override byte DecodeByte(MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public override short GetMessageType()
        {
            return messageType;
        }
    }
}
