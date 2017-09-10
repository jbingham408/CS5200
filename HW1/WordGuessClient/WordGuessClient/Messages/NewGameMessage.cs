using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    class NewGameMessage
    {
        private short messageType { get; set; }
        private string aNum { get; set; }
        private string lastName { get; set; }
        private string firstName { get; set; }
        private string alias { get; set; }
    }
}
