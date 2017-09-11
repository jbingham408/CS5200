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
    class GameDefMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string hint { get; set; }
        private string definition { get; set; }
        private WordGuessClient client;
        private static readonly ILog logger = LogManager.GetLogger(typeof(GameDefMessage));

        public GameDefMessage(WordGuessClient c)
        {
            client = c;
            messageType = 2;
        }
        public override byte[] Encode()
        {
            logger.Debug("Encoding Message Type: Game Def");

            MemoryStream stream = new MemoryStream();

            return stream.ToArray();
        }

        public override Message Decode(MemoryStream stream)
        {
            logger.Debug("Decoding message");

            GameDefMessage message = null;

                message = new GameDefMessage(client);
                //MemoryStream stream = new MemoryStream(b);
                gameID = DecodeShort(stream);
            logger.InfoFormat("Game Id: {0}", gameID);
                hint = DecodeString(stream);
            logger.InfoFormat("Hint: {0}", hint);
            definition = DecodeString(stream);
            logger.InfoFormat("Definition: {0}", definition);
            logger.InfoFormat("Message Type: Game Def");

            fillInGameInformation();
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

        private void fillInGameInformation()
        {
            logger.Info("Fill text");
            client.SetHintText(hint);
            client.SetDefTextBox(definition);
            client.SetGameIdLabel(gameID);
            client.Update();
        }
    }
}
