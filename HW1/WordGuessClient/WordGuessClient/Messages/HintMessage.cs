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
    //Hint Message class that tells the program what is going to be decoded and in what order
    class HintMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string hint { get; set; }
        private bool correctGame { get; set; }
        private WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(HintMessage));

        public HintMessage(WordGuessClient c)
        {
            messageType = 6;
            client = c;
            gameID = client.GetGameID();
            correctGame = false;
        }

        //decodes the message
        public override Message Decode(MemoryStream stream)
        {
            logger.Info("Decoding Message Type: Hint");

            HintMessage message = new HintMessage(client);
            message.messageType = DecodeShort(stream);
            message.gameID = DecodeShort(stream);
            logger.InfoFormat("Game Id: {0}", message.gameID);
            message.hint = DecodeString(stream);
            logger.InfoFormat("Hint: {0}", message.hint);
            if (message.gameID == this.gameID)
            {
                correctGame = true;
                hint = message.hint;
            }

            fillInHintInformation();
            return message;
        }

        public override short DecodeShort(MemoryStream stream)
        {
            byte[] b = new byte[2];
            int numOfBytes = stream.Read(b, 0, b.Length);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Short Failed");
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));
        }

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

        public override bool GetCorrectGame()
        {
            return correctGame;
        }

        private void fillInHintInformation()
        {
            logger.Info("Fill hint");
            client.SetHintText(hint);
            client.SetGuessTextBox(hint);
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