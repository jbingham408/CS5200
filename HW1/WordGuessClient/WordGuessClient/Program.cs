using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;


namespace WordGuessClient
{
    class Program
    {
        /// Jason Bingham
        /// CS5200 HW1
        /// Word Game Client
        /// Guess the word given to the client by the server

        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            logger.Info("Starting Client");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WordGuessClient());
        }
    }
}
