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
    public partial class واجهة_النسخ_الاحتياطي_و_الاستعادة : Form
    {
        public واجهة_النسخ_الاحتياطي_و_الاستعادة()
        {
            InitializeComponent();
        }
        واجهة_استعادة_نسخة_احتياطية restore = new واجهة_استعادة_نسخة_احتياطية();
        واجهة_إنشاء_نسخة_احتياطية backup = new واجهة_إنشاء_نسخة_احتياطية();
        private void واجهة_النسخ_الاحتياطي_و_الاستعادة_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingRestoreBackup = true;
        }
        //Restore
        private void زر_إنشاء_نسخة_احتياطية_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingRestore == true)
            {
                restore = new واجهة_استعادة_نسخة_احتياطية();
                restore.Show();
            }
            else
            {
                restore.Show();
            
            }
        }
        //Backup
        private void زر_استعادة_نسخة_احتياطية_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingBackUp == true)
            {
                backup = new واجهة_إنشاء_نسخة_احتياطية();
                backup.Show();
            }
            else
            {
                backup.Show();
            
            }
        }

        private void واجهة_النسخ_الاحتياطي_و_الاستعادة_Load(object sender, EventArgs e)
        {

        }
    }
}
