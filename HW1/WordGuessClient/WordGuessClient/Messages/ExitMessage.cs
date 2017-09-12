﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using log4net;
using System.IO;

namespace WordGuessClient
{
    class ExitMessage : Message
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private WordGuessClient client;
        private static readonly ILog logger = LogManager.GetLogger(typeof(ExitMessage));

        public ExitMessage(WordGuessClient c)
        {
            messageType = 7;
            client = c;
            gameID = client.GetGameID();
        }
        public override byte[] Encode()
        {
            logger.Debug("Encoding message");

            MemoryStream stream = new MemoryStream();

            EncodeShort(stream, messageType);
            EncodeShort(stream, gameID);

            logger.Info("Exiting game");
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
