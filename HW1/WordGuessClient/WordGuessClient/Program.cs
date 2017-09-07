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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure();
            logger.Info("Starting Client");
            logger.Debug("test");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WordGuessClient());
        }
    }
}
