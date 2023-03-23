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
    public partial class واجهة_تسجيل__الدخول : Form
    {
        public واجهة_تسجيل__الدخول()
        {
            InitializeComponent();
            loginFlag = false;
            gifImage = new GifImage(filepath);
            gifImage.ReverseAtEnd = false;//dont't reverse at end
            checkBox1.Checked = false ;
            password.PasswordChar ='*';
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox3.Width - 2, pictureBox3.Height - 2);
            Region rg = new Region(gp);
            pictureBox3.Region = rg;
            BegeinStudyYear.CustomFormat = "yyyy";
        }
        public static واجهة_الصفحة_الرئيسية Home;
        string studyyear;
        StudyYear year = new StudyYear();
        private GifImage gifImage = null;
        private string filepath = Application.StartupPath + @"\ImageStu" + "\\" + @"key" + ".gif";
        public bool loginFlag { get; set; }
        private void BegeinStudyYear_ValueChanged(object sender, EventArgs e)
        {
         
            BegeinStudyYear.CustomFormat = "yyyy";
            studyyear = BegeinStudyYear.Value.Year.ToString();
            int idStudyYear = year.SelectStudyYearID(studyyear);
            if (!(idStudyYear == -1))
            {
                StudyYear.YearID = idStudyYear;
             

                StudyYear.BeginStudyYear = studyyear;
                int StudyYearConvert = Convert.ToInt32(studyyear);
                int EndStudyYear = StudyYearConvert + 1;
                StudyYear.EndStudyYear = studyyear;

                EMP.idStudyYear = idStudyYear;
                Subject.idStudyYear = idStudyYear;
                Hall.idStudyYear = idStudyYear;
                Division.idStudyYear = idStudyYear;
                Exam.idStudyYear = idStudyYear;
            }
            //Stu.idStudyYear = idStudyYear;
            //Hall.idStudyYear = idStudyYear;
            //Subject.idStudyYear = idStudyYear;
            //DoamStu.idStudyYear = idStudyYear;
            //ClassDivisionCategory.idStudyYear = idStudyYear;
            //Boolean EnabledForm = year.EnabledForm(StudyYear, EndStudyYear.ToString());
            //if ((EnabledForm) || (StudyYearConvert > DateTime.Now.Year))
            //{

            //    واجهة_مكونات_المدرسة f = new واجهة_مكونات_المدرسة();
            //    f.Show();


            //}
            //else

            //    MessageBox.Show("غير مسموح التاعديل على بيانات السنوات السابقة و كذلك يجب إضافة العام الحالي و تحديد ثوابته و تواريخه", "خطأ إدخال");

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            pictureBox4.Image = gifImage.GetNextFrame();
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
       }

        private void واجهة_تسجيل__الدخول_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                password.PasswordChar = (char)0;
                openEye.Visible = true  ;
                closeEye.Visible = false ;

            }
            else {
                password.PasswordChar = '*';
                closeEye.Visible = true ;
                openEye.Visible = false ;
            }
               

        }

     

        private void زر_دخول_Click(object sender, EventArgs e)
        {

            /** if (txt_user_name.Text == "Dima" & txt_password.Text == "abc")
             {
                 واجهة_إضافة_مستخدم_جديد form = new واجهة_إضافة_مستخدم_جديد("AD");
                 form.Show();
                 this.Hide();
             }
             else
             
                 if (txt_user_name.Text == "EMP" & txt_password.Text == "123")
                 { }
                 else if (txt_user_name.Text == "stu" & txt_password.Text == "secret")
                 {
                 }
                 else 
                 {*/
            //واجهة_إضافة_مستخدم_جديد form = new واجهة_إضافة_مستخدم_جديد("V");
            //form.Show();



            //  }

            //رح نحّمل جدول المستخدمين و نعمل تحقق من المستهدم و كلمة المرور

            // DataTable dt = dbprovider.LoadUseTable(txt_user_name.Text, txt_password.Text );
            // if (dt.Rows.Count > 0)
            // {

            //البرامتر التالت كان الرول في جدول المستخدمين و البرمتر واحد كان اسم الرول
            //يعني رح أنقل للقورم الجاي هذه المعلومات
            //  , واجهة المشلاوع الأساسية وأضيف للباني لها البرامترات السابقة form1 لازم لواجهة
            //أيضا  form1 في واجهة  label وجعل ال  
            // Form1 form = new Form1(dt.Rows[0][3].ToString(), dt.Rows[0][1].ToString());
            //   form.Show();
            // }
            //إذاكان الدخول مسموع سنجعل امتحول البولياني صح
            //if(dt.Rows.Count)>0)
            //else 
            //loginflag=false
            loginFlag = true;
              //  Home = new واجهة_الصفحة_الرئيسية();
                //Home.Show();
            Close();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void TableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
    }

