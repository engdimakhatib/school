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
    public partial class واجهة_الصفحة_الرئيسية : Form
    {
        public static Boolean  IsClosing=false;
        public static واجهة_إدارة_الموظفين emp=new واجهة_إدارة_الموظفين();
        public static واجهة_العام_الدراسي_و_العطل studyyear=new واجهة_العام_الدراسي_و_العطل();
        public static واجهة_توزيع_درجات_المواد subjDist = new واجهة_توزيع_درجات_المواد();
        public static واجهة_إدارة_المعدات_في_كل_قاعة HallEquip = new واجهة_إدارة_المعدات_في_كل_قاعة();
        public static واجهة_إعدادات_البرنامج setting = new واجهة_إعدادات_البرنامج();
        public static واجهة_إدارة_اللطلاب stu = new واجهة_إدارة_اللطلاب();
        public static واجهة_تسجيل__الدخول LoginFrm;
        public static واجهة_الدوام doam = new واجهة_الدوام();
        public static واجهة_الطباعة print = new واجهة_الطباعة();
      

        //خاصية بمجرد الدخول الصحيح تختفي واجهة تسجيل الدخول 
        //activated  لأنه بحدث 
        //للصفحة الرئيسية ستبقى تظهر 
        public int loggedIn { get; set; }
        public واجهة_الصفحة_الرئيسية()
        {
            InitializeComponent();
            label9.Text = DateTime.Now.ToShortTimeString();
            label10.Text = DateTime.Now.ToLongDateString();
            loggedIn = 0;
        }

        private void TableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void واجهة_الصفحة_الرئيسية_Load(object sender, EventArgs e)
        {
          
        }

        private void واجهة_العام_الدراسي_Click(object sender, EventArgs e)
        {
            if (StudyYear.IsClosingYear == true )
            {
                studyyear = new واجهة_العام_الدراسي_و_العطل();
                studyyear.Show();
            }
            else
            {
                studyyear.Show();
            }

        }

        private void واجهة_الموظفين_Click(object sender, EventArgs e)
        {
            if (EMP.IsClosing  == true)
            {
                emp = new واجهة_إدارة_الموظفين();
                emp.Show();
            }
            else
            {
                emp.Show();
            }
        }

        private void واجهة_المواد_Click(object sender, EventArgs e)
        {
            if (Subject.IsClosingSubjectDistirution== true)
            {
                subjDist = new واجهة_توزيع_درجات_المواد();
                subjDist.Show();
            }
            else
            {
                subjDist.Show();
            }
        }

        private void واجهة_القاعات_و_الحصص_Click(object sender, EventArgs e)
        {
            if (Hall.IsClosingHallEquipment == true)
            {
                HallEquip = new واجهة_إدارة_المعدات_في_كل_قاعة();
                HallEquip.Show();
            }
            else
            {
                HallEquip.Show();
            }
        }

        private void واجهة_إعدادات_البرنامج_Click(object sender, EventArgs e)
        {
            if (Setting.IsClosingSettingForm == true)
            {
                setting = new واجهة_إعدادات_البرنامج();
                setting.Show();
            }
            else
            {
                setting.Show();
            }
        }

        private void واجهة_الطلاب_Click(object sender, EventArgs e)
        {
            if (STU.IsClosing == true)
            {
                stu = new واجهة_إدارة_اللطلاب();
                stu.Show();
            }
            else
            {
                stu.Show();
            }
        }

        private void واجهة_الصفحة_الرئيسية_Activated(object sender, EventArgs e)
        {
            if(loggedIn==0)
            {

                LoginFrm = new واجهة_تسجيل__الدخول();
                LoginFrm.ShowDialog();
                if (LoginFrm.loginFlag == false)
                {
                    Close();
                }
                else
                {
                    loggedIn = 1;
                }
            }
            
        }

        private void واجهة_الصفحة_الرئيسية_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void واجهة_الصفحة_الرئيسية_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void واجهة_الدوام_Click(object sender, EventArgs e)
        {
            if (DoamSub.IsClosing == true)
            {
                doam = new واجهة_الدوام();
                doam.Show();
            }
            else
            {
                doam.Show();
            }
        }

        private void واجهة_الطباعة_Click(object sender, EventArgs e)
        {
            if (Print.IsClosing == true)
            {
                print = new واجهة_الطباعة();
                print.Show();
            }
            else
            {
                print.Show();
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }
    }
}
