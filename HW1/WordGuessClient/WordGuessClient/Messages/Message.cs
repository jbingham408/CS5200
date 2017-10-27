using System.IO;


namespace WordGuessClient
{
    //Basic message class
    public abstract class Message
    {
        private string errorText { get; set; }

        private short messageType { get; set; }
        private short gameID { get; set; }

        public abstract byte[] Encode();
        public abstract Message Decode(MemoryStream stream);
        public abstract void EncodeShort(MemoryStream stream, short s);
        public abstract void EncodeString(MemoryStream stream, string s);
        public abstract short DecodeShort(MemoryStream stream);
        public abstract string DecodeString(MemoryStream stream);
        public abstract byte DecodeByte(MemoryStream stream);
        public abstract bool GetCorrectGame();
        public abstract short GetMessageType();
    }
}
