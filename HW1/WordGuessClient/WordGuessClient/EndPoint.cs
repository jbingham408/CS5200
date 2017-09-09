using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WordGuessClient
{
    class EndPoint
    {
        public static IPEndPoint GetEndPoint(string address, string port)
        {
            IPEndPoint endPoint = null;
            IPAddress serverAddress = null;
            int serverPort = 0;

            if (!string.IsNullOrWhiteSpace(address))
            {
                IPAddress[] serverAddressList = Dns.GetHostAddresses(address);
                for (int i = 0; i < serverAddressList.Length && serverAddress == null; i++)
                    if (serverAddressList[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        serverAddress = serverAddressList[i];
            }

            if (!string.IsNullOrWhiteSpace(port))
                Int32.TryParse(port, out serverPort);

            endPoint = new IPEndPoint(serverAddress, serverPort);

            return endPoint;
        }
    }
}
