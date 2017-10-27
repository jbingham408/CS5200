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
    //Answer Message class
    //Whats what will be in the message it receives and the order it will appear in
    public class AnswerMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private byte result { get; set; }
        private short score { get; set; }
        private string hint { get; set; }
        private WordGuessClient client { get; set; }
        private bool correctGame { get; set; }
        private static readonly ILog logger = LogManager.GetLogger(typeof(AnswerMessage));

        public AnswerMessage(WordGuessClient c)
        {
            messageType = 4;
            client = c;
            gameID = client.GetGameID();
            correctGame = false;
        }

        //decodes the message
        public override Message Decode(MemoryStream stream)
        {
            logger.Info("Decoding Message Type: Answer");

            AnswerMessage message = new AnswerMessage(client);
            message.messageType = DecodeShort(stream);
            message.gameID = DecodeShort(stream);
            logger.InfoFormat("GameID: {0}", message.gameID);
            message.result = DecodeByte(stream);
            logger.InfoFormat("Result: {0}", message.result);
            message.score = DecodeShort(stream);
            logger.InfoFormat("Score: {0}", message.score);
            message.hint = DecodeString(stream);
            logger.InfoFormat("Hint: {0}", message.hint);
            if (message.gameID == this.gameID)
                correctGame = true;

            UpdateClient(message.hint, message.result, message.score);

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

        public override byte DecodeByte(MemoryStream stream)
        {
            byte[] b = new byte[1];
            byte result;
            int numOfBytes = stream.Read(b, 0, 1);
            if (numOfBytes != b.Length)
                throw new ApplicationException("Decode Byte Failed");
            result = b[0];

            return result;
        }

        public override bool GetCorrectGame()
        {
            return correctGame;
        }

        private void UpdateClient(string hint, byte correct, short playerScore)
        {
            if (correct == 0)
                client.SetIncorrectText("Incorrect");
            else
                client.ShowPlayerScore(playerScore);
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

        public override short GetMessageType()
        {
            return messageType;
        }
    }
}
