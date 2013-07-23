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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProcesyForm());
        }


        static void LogUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {           
            // here you can log the exception ...
        }

    }


}
