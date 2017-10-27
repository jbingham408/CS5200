using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace WordGuessClient
{
    //Error message class
    //Tells the program what will be in the message and the order it will appear in
    public class ErrorMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string errorText { get; set; }
        private bool correctGame { get; set; }
        private WordGuessClient client { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(ErrorMessage));

        public ErrorMessage(WordGuessClient c)
        {
            messageType = 9;
            client = c;
            gameID = client.GetGameID();
            correctGame = false;
        }

        //Decodes the message
        public override Message Decode(MemoryStream stream)
        {
            logger.Info("Decoding Message Type: Error");

            ErrorMessage message = new ErrorMessage(client);
            message.messageType = DecodeShort(stream);
            message.gameID = DecodeShort(stream);
            logger.InfoFormat("Game ID: {0}", message.gameID);
            if (message.gameID == this.gameID)
                correctGame = true;
            errorText = DecodeString(stream);
            client.SetErrorText(errorText);

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
