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
    //class for the game def message
    class GameDefMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string hint { get; set; }
        private string definition { get; set; }
        private WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(GameDefMessage));

        public GameDefMessage(WordGuessClient c)
        {
            client = c;
            messageType = 2;
        }

        //decodes all the information
        public override Message Decode(MemoryStream stream)
        {
            logger.Info("Decoding Message Type: Game Def");

            GameDefMessage message = new GameDefMessage(client);
            message.messageType = DecodeShort(stream);
            gameID = DecodeShort(stream);
            logger.InfoFormat("Game Id: {0}", gameID);
            hint = DecodeString(stream);
            logger.InfoFormat("Hint: {0}", hint);
            definition = DecodeString(stream);
            logger.InfoFormat("Definition: {0}", definition);

            fillInGameInformation();
            return message;
        }

        //decodes a short variable
        public override short DecodeShort(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

        //decodes a string variable
        public override string DecodeString(MemoryStream stream)
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

        //updates the information in the client application
        private void fillInGameInformation()
        {
            logger.Info("Fill text");
            client.SetHintText(hint);
            client.SetDefTextBox(definition);
            client.SetGameIdLabel(gameID);
            client.SetNumCharLabel((short)hint.Length);
            client.Update();
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
        public override void EncodeShort(MemoryStream stream, short s)
        {
            throw new NotImplementedException();
        }

        public override void EncodeString(MemoryStream stream, string s)
        {
            throw new NotImplementedException();
        }
        public override bool GetCorrectGame()
        {
            return true;
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
