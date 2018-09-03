using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleTestingSystem
{
    static class Program
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            logger.Info("Application start");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthenticationForm());
            logger.Info("Application close");
        }
    }
}
