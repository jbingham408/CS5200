using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordGuessClient;

namespace WordGuessClientTest
{
    [TestClass]
    public class EncodeTests
    {
        [TestMethod]
        public void NewGameMessageEncodeTest()
        {
            NewGameMessage message = new NewGameMessage()
            {
                messageType = 1,
                aNum = "A01",
                lastName = "Bingham",
                firstName = "Jason",
                alias = "jb"
            };

            byte[] b = message.Encode();

            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(1, b[1]);

            Assert.AreEqual(0, b[2]);
            Assert.AreEqual(6, b[3]);
            Assert.AreEqual(0, b[4]);
            Assert.AreEqual(65, b[5]);
            Assert.AreEqual(0, b[6]);
            Assert.AreEqual(48, b[7]);
            Assert.AreEqual(0, b[8]);
            Assert.AreEqual(49, b[9]);

            Assert.AreEqual(0, b[10]);
            Assert.AreEqual(14, b[11]);
            Assert.AreEqual(0, b[12]);
            Assert.AreEqual(66, b[13]);
            Assert.AreEqual(0, b[14]);
            Assert.AreEqual(105, b[15]);
            Assert.AreEqual(0, b[16]);
            Assert.AreEqual(110, b[17]);
            Assert.AreEqual(0, b[18]);
            Assert.AreEqual(103, b[19]);
            Assert.AreEqual(0, b[20]);
            Assert.AreEqual(104, b[21]);
            Assert.AreEqual(0, b[22]);
            Assert.AreEqual(97, b[23]);
            Assert.AreEqual(0, b[24]);
            Assert.AreEqual(109, b[25]);

            Assert.AreEqual(0, b[26]);
            Assert.AreEqual(10, b[27]);
            Assert.AreEqual(0, b[28]);
            Assert.AreEqual(74, b[29]);
            Assert.AreEqual(0, b[30]);
            Assert.AreEqual(97, b[31]);
            Assert.AreEqual(0, b[32]);
            Assert.AreEqual(115, b[33]);
            Assert.AreEqual(0, b[34]);
            Assert.AreEqual(111, b[35]);
            Assert.AreEqual(0, b[36]);
            Assert.AreEqual(110, b[37]);

            Assert.AreEqual(0, b[38]);
            Assert.AreEqual(4, b[39]);
            Assert.AreEqual(0, b[40]);
            Assert.AreEqual(106, b[41]);
            Assert.AreEqual(0, b[42]);
            Assert.AreEqual(98, b[43]);
        }

        [TestMethod]
        public void AckMessageEncodeTest()
        {
            AckMessage message = new AckMessage()
            {
                messageType = 8,
                gameID = 5
            };

            byte[] b = message.Encode();

            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(8, b[1]);
            Assert.AreEqual(0, b[2]);
            Assert.AreEqual(5, b[3]);
        }

        [TestMethod]
        public void GuessMessageEncodeTest()
        {
            GuessMessage message = new GuessMessage()
            {
                messageType = 3,
                gameID = 45,
                guess = "Hello"
            };

            byte[] b = message.Encode();

            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(3, b[1]);

            Assert.AreEqual(0, b[2]);
            Assert.AreEqual(45, b[3]);

            Assert.AreEqual(0, b[4]);
            Assert.AreEqual(10, b[5]);
            Assert.AreEqual(0, b[6]);
            Assert.AreEqual(72, b[7]);
            Assert.AreEqual(0, b[8]);
            Assert.AreEqual(101, b[9]);
            Assert.AreEqual(0, b[10]);
            Assert.AreEqual(108, b[11]);
            Assert.AreEqual(0, b[12]);
            Assert.AreEqual(108, b[13]);
            Assert.AreEqual(0, b[14]);
            Assert.AreEqual(111, b[15]);
        }

        [TestMethod]
        public void ExitMessageEncodeTest()
        {
            ExitMessage message = new ExitMessage()
            {
                messageType = 7,
                gameID = 2,
            };

            byte[] b = message.Encode();

            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(7, b[1]);

            Assert.AreEqual(0, b[2]);
            Assert.AreEqual(2, b[3]);
        }

        [TestMethod]
        public void GetHintMessageEncodeTest()
        {
            GetHintMessage message = new GetHintMessage()
            {
                messageType = 5,
                gameID = 234,
            };

            byte[] b = message.Encode();

            Assert.AreEqual(0, b[0]);
            Assert.AreEqual(5, b[1]);

            Assert.AreEqual(0, b[2]);
            Assert.AreEqual(234, b[3]);
        }
    }

    
}
