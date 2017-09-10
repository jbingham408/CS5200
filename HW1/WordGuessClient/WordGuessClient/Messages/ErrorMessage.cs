using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuessClient
{
    class ErrorMessage
    {
        private short messageType { get; set; }
        private short gameID { get; set; }
        private string errorText { get; set; }
    }
}
