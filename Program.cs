using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MYSCHOOLFINAL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string Lang = Properties.Settings.Default.Lang;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Lang); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new واجهة_الصفحة_الرئيسية());
        
        }
    }
}
