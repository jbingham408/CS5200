using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    class GuessMessage
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string guess { get; set; }
    }
}
