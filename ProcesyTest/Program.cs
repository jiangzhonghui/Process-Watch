using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProcesyTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(LogUnhandledException);
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProcesyForm());
        }


        static void LogUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            NLog.LogManager.GetCurrentClassLogger().Error(ex.Message);
        }

        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception as Exception;
            NLog.LogManager.GetCurrentClassLogger().Error(ex.Message);
        }
    }


}
