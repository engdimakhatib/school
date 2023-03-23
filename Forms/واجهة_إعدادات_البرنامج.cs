using MYSCHOOLFINAL.Forms;
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
    public partial class واجهة_إعدادات_البرنامج : Form
    {
        public واجهة_إعدادات_البرنامج()
        {
            InitializeComponent();
        }
     public static   string s = "hi";
        public static  واجهة_إضافة_منصب_جديد role = new واجهة_إضافة_منصب_جديد();

        public static  واجهة_إضافة_مستخدم_جديد user = new واجهة_إضافة_مستخدم_جديد( s);
        public static واجهة_صلاحية_كل_منصب UserRole = new واجهة_صلاحية_كل_منصب();
        public static واجهة_النسخ_الاحتياطي_و_الاستعادة backup_restore = new واجهة_النسخ_الاحتياطي_و_الاستعادة();
        public static واجهة_إضافة_اللغات_و_العملات langCurrency = new واجهة_إضافة_اللغات_و_العملات();
 
        واجهة_استعادة_نسخة_احتياطية restore = new واجهة_استعادة_نسخة_احتياطية();
        واجهة_إنشاء_نسخة_احتياطية backup = new واجهة_إنشاء_نسخة_احتياطية();
    
        private void إضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingUsers == true)
            {
                user = new واجهة_إضافة_مستخدم_جديد(s);
                user.Show();
            }
            else
            {
                user.Show();
            }
        }

        private void إدارةالمناصب_و_الوظائفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingUserPer == true)
            {
                UserRole = new واجهة_صلاحية_كل_منصب();
                UserRole.Show();
            }
            else
            {
                UserRole.Show();
            }
        }

        private void إدارة_السماحياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingRole == true)
            {
                role = new واجهة_إضافة_منصب_جديد();
                role.Show();
            }
            else
            {
                role.Show();
            }
        }

        private void واجهة_المستخدمين_و_السماحيات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingSettingForm = false;
        }

        private void واجهة_المستخدمين_و_السماحيات_Load(object sender, EventArgs e)
        {
           
        }

        private void إنشاءنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void استعادةنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void تغييراللغةوالعملةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingLanguage_CurrencyForm == true)
            {
                langCurrency = new واجهة_إضافة_اللغات_و_العملات();
                langCurrency.Show();
            }
            else
            {
                langCurrency.Show();
            }
        }
    }
}
