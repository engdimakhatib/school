using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_عرض_صورة_الموظف : Form
    {
        public واجهة_عرض_صورة_الموظف()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }
        private static واجهة_عرض_صورة_الموظف n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_عرض_صورة_الموظف deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_عرض_صورة_الموظف();
                }
                return n;
            }

        }
       
        private void واجهة_عرض_صورة_الموظف_Load(object sender, EventArgs e)
        {
           
        }
    }
}
