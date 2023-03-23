using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace MYSCHOOLFINAL
{
   public  class Print
    {
        public static Boolean IsClosing = false;
        DataTable MyTable = new DataTable();
        StringBuilder OnWorkBld = new StringBuilder("");
  
        public static dbHelper dbhelper = new dbHelper();
        public  StringBuilder OnWorkReport_AllEMP()
        {
           
            return OnWorkBld;
        }
        public  void PrintHelpPage(string path)
        {
            WebBrowser WebBrowserForPrinting = new WebBrowser();
            WebBrowserForPrinting.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);
            WebBrowserForPrinting.Url = new Uri(path);

        }
        private  void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Print();
            ((WebBrowser)sender).Dispose();
        }


    }
}
