using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_إدارة_الموظفين : Form
    {

        واجهة_إضافة_تعديل_الموظفين add=new واجهة_إضافة_تعديل_الموظفين ();
        واجهة_الصفحة_الرئيسية Home;
        EMP myEmp = new EMP();
        int SelectRowIndex;
        public static dbHelper dbhelper = new dbHelper();
        public Print myPrint = new Print();
        public واجهة_إدارة_الموظفين()
        {
            InitializeComponent();

            if (n == null)
                n = this;
    

        }
        private static واجهة_إدارة_الموظفين n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_إدارة_الموظفين deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_إدارة_الموظفين();
                }
                return n;
            }

        }
        public void ShowRecord()
        {
            واجهة_إضافة_تعديل_الموظفين f = new واجهة_إضافة_تعديل_الموظفين();
            f.زر_إضافة_تعديل_موظف.Text = "تعديل";
            f.label21.Text = "واجهة تعديل بيانات الموظف";
            //0 id
            EMP.id = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[0].Value);
            if (!(this.DGV_EMP.CurrentRow.Cells[1].Value==null))
                f.FirstName.Text= this.DGV_EMP.CurrentRow.Cells[1].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[2].Value == null))
                f.LastName.Text = this.DGV_EMP.CurrentRow.Cells[2].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[3].Value == null))
                f.DadName.Text = this.DGV_EMP.CurrentRow.Cells[3].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[4].Value == null))
                f.MomName.Text = this.DGV_EMP.CurrentRow.Cells[4].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[5].Value == null))
                f.PhoneNumber.Text = this.DGV_EMP.CurrentRow.Cells[5].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[6].Value == null))
                f.PlaceAndNumQaid.Text = this.DGV_EMP.CurrentRow.Cells[6].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[7].Value == null))
                f.SelfNum.Text = this.DGV_EMP.CurrentRow.Cells[7].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[8].Value == null))
                f.FinancialNum.Text = this.DGV_EMP.CurrentRow.Cells[8].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[9].Value == null))
                f.ReverseNum.Text = this.DGV_EMP.CurrentRow.Cells[9].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[10].Value == null))
                f.DeletionNum.Text = this.DGV_EMP.CurrentRow.Cells[10].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[11].Value == null))
                f.NationalNum.Text = this.DGV_EMP.CurrentRow.Cells[11].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[12].Value == null))
                f.NumBackIdentity.Text = this.DGV_EMP.CurrentRow.Cells[12].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[13].Value == null))
                f.Email.Text = this.DGV_EMP.CurrentRow.Cells[13].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[14].Value == null))
                f.maritialState.Text = this.DGV_EMP.CurrentRow.Cells[14].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[15].Value == null))
                f.NumChildren.Text = this.DGV_EMP.CurrentRow.Cells[15].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[16].Value == null))
                f.Qualification.Text = this.DGV_EMP.CurrentRow.Cells[16].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[17].Value == null))
                f.certificate.Text = this.DGV_EMP.CurrentRow.Cells[17].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[19].Value == null))
                f.Category.Text = this.DGV_EMP.CurrentRow.Cells[19].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[20].Value == null))
                f.ApprovedName.Text = this.DGV_EMP.CurrentRow.Cells[20].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[21].Value == null))
                f.Salary.Text = this.DGV_EMP.CurrentRow.Cells[21].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[22].Value == null))
                f.OriginalSchool.Text = this.DGV_EMP.CurrentRow.Cells[22].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[23].Value == null))
                f.TempSchool.Text = this.DGV_EMP.CurrentRow.Cells[23].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[24].Value == null))
                f.NumHour.Text = this.DGV_EMP.CurrentRow.Cells[24].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[30].Value == null))
                f.situation.Text = this.DGV_EMP.CurrentRow.Cells[30].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[31].Value == null))
                f.NumPresident.Text = this.DGV_EMP.CurrentRow.Cells[31].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[32].Value == null))
                f.NumTrustWorthy.Text = this.DGV_EMP.CurrentRow.Cells[32].Value.ToString();

            //38-remainingNumHour
            if (!(this.DGV_EMP.CurrentRow.Cells[34].Value == null))
                f.RecruitmentDivison.Text = this.DGV_EMP.CurrentRow.Cells[34].Value.ToString();
            //43 emp_img
            if (!(this.DGV_EMP.CurrentRow.Cells[35].Value == null))
                f.Notes.Text = this.DGV_EMP.CurrentRow.Cells[35].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[36].Value == null))
                f.address.Text = this.DGV_EMP.CurrentRow.Cells[36].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[37].Value == null))
                f.Courses.Text = this.DGV_EMP.CurrentRow.Cells[37].Value.ToString();
            //40 id_studySYear
            //41 functionalityOldText
            //42 AssignedWorkOldText
            if (!(this.DGV_EMP.CurrentRow.Cells[42].Value == null))
                EMP.AssignedWorkOldText= this.DGV_EMP.CurrentRow.Cells[42].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[41].Value == null))
                EMP.functionalityOldText= this.DGV_EMP.CurrentRow.Cells[41].Value.ToString();
            if (!(this.DGV_EMP.CurrentRow.Cells[18].Value == null))
            {
                int GraduationDate1 = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[18].Value);
                f.GraduationDate.CustomFormat = "yyyy";
                f.GraduationDate.Value = new DateTime(GraduationDate1, 1, 1);
            }
            if (!(this.DGV_EMP.CurrentRow.Cells[25].Value == null))
            {
                int BirthdayDate1 = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[25].Value);
                f.BirthdayDate.CustomFormat = "yyyy";
                f.BirthdayDate.Value = new DateTime(BirthdayDate1, 1, 1);
            }
            if (!(this.DGV_EMP.CurrentRow.Cells[26].Value == null))
            {
                int DirectlyAtSchool1 = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[26].Value);
                f.DirectlyAtSchool.CustomFormat = "yyyy";
                f.DirectlyAtSchool.Value = new DateTime(DirectlyAtSchool1, 1, 1);
            }
            if (!(this.DGV_EMP.CurrentRow.Cells[27].Value == null))
            {
                int YearStartWork1 = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[27].Value);
                f.YearStartWork.CustomFormat = "yyyy";
                f.YearStartWork.Value = new DateTime(YearStartWork1, 1, 1);
            }
            if (!(this.DGV_EMP.CurrentRow.Cells[33].Value == null))
            {
                int DateCourses1 = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[33].Value);
                f.DateCourses.CustomFormat = "yyyy";
                f.DateCourses.Value = new DateTime(DateCourses1, 1, 1);
            }






            if (!(this.DGV_EMP.CurrentRow.Cells[28].Value == null))
            {
               //   f.functionalityID.SelectedIndex = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[28].Value);
                  EMP.functionalityIDIndex= Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[28].Value);

            }

            if (!(this.DGV_EMP.CurrentRow.Cells[29].Value == null))
            {
               // f.AssignedWorkID.SelectedIndex = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[29].Value);
                EMP.AssignedWorkIDIndex = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[29].Value);
            }



            byte[] EMP_Image = null;
            if (!(this.DGV_EMP.CurrentRow.Cells[43].Value == DBNull.Value))
            {
               EMP_Image = (byte[])myEmp.selectEMPimg(Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[0].Value)).Rows[0][0];
                MemoryStream ms = new MemoryStream(EMP_Image);
                f.EMP_Image.Image = Image.FromStream(ms);
               f.EMP_Image.BackgroundImageLayout= ImageLayout.Stretch;
            }
            f.ShowDialog();
        }
        public void Colorfull()
        {
            if (!(DGV_EMP.Rows.Count == 0))
            {

                this.DGV_EMP.ClearSelection();
                this.DGV_EMP.CurrentCell = this.DGV_EMP.Rows[EMP.i].Cells[1];
                this.DGV_EMP.CurrentRow.Selected = true;
                this.DGV_EMP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.DGV_EMP.Refresh();
                this.DGV_EMP.Rows[EMP.i].Selected = true;
                this.DGV_EMP.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Maroon;
                this.DGV_EMP.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.White ;
            }
        }
        public void rename()
        {
           this.DGV_EMP.Columns[1].HeaderText = "الاسم";
           this.DGV_EMP.Columns[2].HeaderText = "الكنية";
           this.DGV_EMP.Columns[3].HeaderText = "اسم الأب";
           this.DGV_EMP.Columns[4].HeaderText = "اسم الأم";
           this.DGV_EMP.Columns[5].HeaderText = "رقم الهاتف";
           this.DGV_EMP.Columns[6].HeaderText = "محل و رقم القيد";
           this.DGV_EMP.Columns[7].HeaderText = "الرقم الذاتي";
           this.DGV_EMP.Columns[8].HeaderText = "الرقم المالي";
           this.DGV_EMP.Columns[9].HeaderText = "رقم الاحتياط";
           this.DGV_EMP.Columns[10].HeaderText = "رقم الشطب";
           this.DGV_EMP.Columns[11].HeaderText = "الرقم الوطني";
           this.DGV_EMP.Columns[12].HeaderText = "رقم خلف الهوية";
           this.DGV_EMP.Columns[13].HeaderText = "الإيميل";
           this.DGV_EMP.Columns[14].HeaderText = "الحالة الاجتماعية";
            this.DGV_EMP.Columns[15].HeaderText = "عدد الأولاد";
            this.DGV_EMP.Columns[16].HeaderText = "المؤهلات العلمية";
           this.DGV_EMP.Columns[17].HeaderText = "الشهادة";
           this.DGV_EMP.Columns[18].HeaderText = "تاريخ التخرج";
           this.DGV_EMP.Columns[19].HeaderText = "الفئة";
           this.DGV_EMP.Columns[20].HeaderText = "اسم المعتمد";
           this.DGV_EMP.Columns[21].HeaderText = "الراتب الشهري";
            DGV_EMP.Columns[21].DefaultCellStyle.Format = "c";
           this.DGV_EMP.Columns[22].HeaderText = "المدرسة الأصلية";
           this.DGV_EMP.Columns[23].HeaderText = "المدرسة المؤقتة";
           this.DGV_EMP.Columns[24].HeaderText = "النصاب";
           this.DGV_EMP.Columns[25].HeaderText = "تاريخ الميلاد";
           this.DGV_EMP.Columns[26].HeaderText = "تاريخ المباشرة بالمدرسة";
           this.DGV_EMP.Columns[27].HeaderText = "تاريخ التعيين";
           this.DGV_EMP.Columns[30].HeaderText = "الوضع في الملاك";
           this.DGV_EMP.Columns[31].HeaderText = "عددمرات تكليف رئيس مركز";
           this.DGV_EMP.Columns[32].HeaderText = "عدد مرات تكليف أمين سر";
           this.DGV_EMP.Columns[33].HeaderText = "تاريخ الدورة";
           this.DGV_EMP.Columns[34].HeaderText = "شعبة التجنيد";     
            this.DGV_EMP.Columns[35].HeaderText = "ملاحظات";
            this.DGV_EMP.Columns[36].HeaderText = "العنوان";
            this.DGV_EMP.Columns[37].HeaderText = "الدورات"; 
            this.DGV_EMP.Columns[41].HeaderText = "الصففة الوظيفية";
            this.DGV_EMP.Columns[42].HeaderText = "العمل المكلّف به";
           
            //id
            this.DGV_EMP.Columns[0].Visible = false;
            //AssignedWorkID  
            this.DGV_EMP.Columns[28].Visible = false;
            //functionalityID
            this.DGV_EMP.Columns[29].Visible = false;
            //[RemainingNumHour]
            this.DGV_EMP.Columns[38].Visible = false;
            //[IsMove]
            this.DGV_EMP.Columns[39].Visible = false;
            //emp_image
            this.DGV_EMP.Columns[37].Visible = false;
            //idStudyYear
           this.DGV_EMP.Columns[40].Visible = false;
            //صورة الموظف
            this.DGV_EMP.Columns[43].Visible = false;
            EMP.functionalityOldText = this.DGV_EMP.Columns[41].ToString();

            EMP.AssignedWorkOldText = this.DGV_EMP.Columns[42].ToString();
          
           
        }
   
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void زر_جهات_الاتصال_Click(object sender, EventArgs e)
        {
            if (panelContact.Visible == false)
            {
                panelContact.Visible = true;
            }
            else
            {
                panelContact.Visible = false;
            }
        }

        private void زر_الطباعة_Click(object sender, EventArgs e)
        {


            //if (panelPrint.Visible == false)
            //{
            //    panelPrint.Visible = true;
            //}
            //else
            //{
            //    panelPrint.Visible = false;
            //}
        }
        private void واجهة_إدارة_الموظفين_Load(object sender, EventArgs e)
        {
            if (!(EMP.idStudyYear == -1))
            {
                this.DGV_EMP.DataSource = myEmp.SelectEMP(EMP.idStudyYear);
                rename();
                if (!(DGV_EMP.Rows.Count == 0))
                {
                    EMP.i = 0;
                    // Colorfull();
                }
            }
            else
            {
                MessageBox.Show("يجب إدخال هذا العام الدراسي و تحديد تواريخه", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void زر_واجهة_رسائل_Click(object sender, EventArgs e)
        {
            try {
                panelContact.Visible = false;
                string fullname = this.DGV_EMP.CurrentRow.Cells[1].Value.ToString().Trim()+" " + this.DGV_EMP.CurrentRow.Cells[2].Value.ToString().Trim();
                واجهة_sms.deleg.txt_name.Text = fullname;
                واجهة_sms.deleg.txt_Tel.Text = this.DGV_EMP.CurrentRow.Cells[5].Value.ToString();
                واجهة_sms.deleg.txt_from.Text = "إدارة مدرسة تقنيات الحاسوب بنات";
                واجهة_sms.deleg.ShowDialog();
            }
            catch
            {
                MessageBox.Show("الرجاء اختيار موظف","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
            }
        //private void TableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void عرضصورةالموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        private void DGV_EMP_DoubleClick(object sender, EventArgs e)
        {
           
             SelectRowIndex = DGV_EMP.SelectedCells[0].RowIndex;
            DataGridViewRow SelectedRow = DGV_EMP.Rows[SelectRowIndex];
            EMP.i = SelectRowIndex;
            EMP.id = Convert.ToInt32(SelectedRow.Cells[0].Value);
            Colorfull();
       //     ShowRecord();

        }
        private void زر_الأخير_Click(object sender, EventArgs e)
        {
        
            EMP.i = DGV_EMP.Rows.Count - 1;
            this.DGV_EMP.Rows[EMP.i].Selected = true;
            Colorfull();
        }
        private void زر_الأول_Click(object sender, EventArgs e)
        {

            EMP.i = 0;

            Colorfull();
        }
        private void زر_التالي_Click(object sender, EventArgs e)
        {
    
            if (EMP.i < DGV_EMP.Rows.Count - 1)
            {

                EMP.i++;
          
                Colorfull();
            }
     
        }
        private void زر_السابق_Click(object sender, EventArgs e)
        {
           
            if (EMP.i != 0)
            {

                EMP.i--;
           
        
                Colorfull();
            }
         
        }

        private void واجهة_إدارة_الموظفين_FormClosing(object sender, FormClosingEventArgs e)
        {
            EMP.IsClosing  = true;
        }

        private void زر_تعديل_Click(object sender, EventArgs e)
        {
            try
            {
                ShowRecord();
                واجهة_إضافة_تعديل_الموظفين.deleg.IsMove.Visible = true;
                واجهة_إضافة_تعديل_الموظفين.deleg.زر_إضافة_تعديل_موظف.Text = "تعديل";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("الرجاء اختيار موظف", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return;
            }
        }

        private void زر_إضافة_Click(object sender, EventArgs e)
        {
            واجهة_إضافة_تعديل_الموظفين.deleg.IsMove.Visible=false;
            واجهة_إضافة_تعديل_الموظفين.deleg.زر_إضافة_تعديل_موظف.Text = "إضافة";
            if (EMP.IsClosingAddEMP == true)
            {
                add = new  واجهة_إضافة_تعديل_الموظفين();
                add.Show();
            }
            else
            {
                add.Show();
            }
        }

        private void زر_جذف_Click(object sender, EventArgs e)
        {
            try
            {
                myEmp.deleteAdjWorkEMP(EMP.id, EMP.idStudyYear);
                myEmp.DeleteEMP(EMP.id, EMP.idStudyYear);
                EMP.i = 0;
                واجهة_إدارة_الموظفين.deleg.DGV_EMP.DataSource = myEmp.SelectEMP(EMP.idStudyYear);
                واجهة_إدارة_الموظفين.deleg.rename();
                واجهة_إدارة_الموظفين.deleg.Colorfull();
                MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("الرجاء اختيار موظف", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   return;
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                this.DGV_EMP.DataSource = myEmp.SelectEMP(EMP.idStudyYear);
                rename();
            }
            else
            {
                this.DGV_EMP.DataSource = myEmp.SeachEmpInfo(textBox1.Text, EMP.idStudyYear);
                rename();
            }
        }

        private void زر_عودة_للواجهة_الرئيسية_Click(object sender, EventArgs e)
        {
            if (واجهة_الصفحة_الرئيسية.IsClosing == false )
            {
                Home = new واجهة_الصفحة_الرئيسية();
                Home.Show();
            }
            else
            {

                Home = new واجهة_الصفحة_الرئيسية();
                Home.Show();
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
           
        }

        private void TableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem showpicture = contextMenuStrip1.Items[0];
            ToolStripItem refresh = contextMenuStrip1.Items[1];
            ToolStripItem onwotk = contextMenuStrip1.Items[2];
            if (e.ClickedItem == showpicture)
            {
                if (!(DGV_EMP.Rows.Count == 0))
                {
                   // EMP.i = 0;
                    // Colorfull();
                   try {
                        byte[] emp_img =
                (byte[])myEmp.selectEMPimg(Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[0].Value)).Rows[0][0];
                        MemoryStream ms = new MemoryStream(emp_img);
                        واجهة_عرض_صورة_الموظف.deleg.pictureBox1.Image = Image.FromStream(ms);
                        واجهة_عرض_صورة_الموظف.deleg.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("لا يوجد صورة شخصية", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     //   return;
                    }
                   
                }
            }
            else if (e.ClickedItem == refresh)
            {
                if (!(EMP.idStudyYear == -1))
                {
                    this.DGV_EMP.DataSource = myEmp.SelectEMP(EMP.idStudyYear);
                    rename();
                    if (!(DGV_EMP.Rows.Count == 0))
                    {
                        EMP.i = 0;
                        // Colorfull();
                    }
                }
                else
                {
                    MessageBox.Show("يجب إدخال هذا العام الدراسي و تحديد تواريخه", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (e.ClickedItem == onwotk)
            {
                if (!(DGV_EMP.Rows.Count == 0))
                {
                    EMP.i = 0;
                    // Colorfull();
                    string Qualification = "", DeletionNum = "", maritialState = "", address = "", FirstName = "", LastName = "", PhoneNumber = "", PlaceAndNumQaid = "", DadName = "", Category = "", NationalNum = "", certificate = "", SelfNum = "", BirthdayDate = "", functionality = "", MomName = "";
                    EMP.id = Convert.ToInt32(this.DGV_EMP.CurrentRow.Cells[0].Value);
                    if (!(this.DGV_EMP.CurrentRow.Cells[1].Value == null))
                        FirstName = this.DGV_EMP.CurrentRow.Cells[1].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[2].Value == null))
                        LastName = this.DGV_EMP.CurrentRow.Cells[2].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[3].Value == null))
                        DadName = this.DGV_EMP.CurrentRow.Cells[3].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[4].Value == null))
                        MomName = this.DGV_EMP.CurrentRow.Cells[4].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[5].Value == null))
                        PhoneNumber = this.DGV_EMP.CurrentRow.Cells[5].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[6].Value == null))
                        PlaceAndNumQaid = this.DGV_EMP.CurrentRow.Cells[6].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[7].Value == null))
                        SelfNum = this.DGV_EMP.CurrentRow.Cells[7].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[10].Value == null))
                        DeletionNum = this.DGV_EMP.CurrentRow.Cells[10].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[11].Value == null))
                        NationalNum = this.DGV_EMP.CurrentRow.Cells[11].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[16].Value == null))
                        Qualification = this.DGV_EMP.CurrentRow.Cells[16].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[17].Value == null))
                        certificate = this.DGV_EMP.CurrentRow.Cells[17].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[19].Value == null))
                        Category = this.DGV_EMP.CurrentRow.Cells[19].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[25].Value == null))
                        BirthdayDate = this.DGV_EMP.CurrentRow.Cells[25].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[36].Value == null))
                        address = this.DGV_EMP.CurrentRow.Cells[36].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[14].Value == null))
                        maritialState = this.DGV_EMP.CurrentRow.Cells[14].Value.ToString();
                    if (!(this.DGV_EMP.CurrentRow.Cells[41].Value == null))
                        functionality = this.DGV_EMP.CurrentRow.Cells[41].Value.ToString();
  
                    var newDirPath = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "SchoolPrint");
                    Directory.CreateDirectory(newDirPath);
                    var newFilePath = Path.Combine(newDirPath, "OnWork.html");
                    var filestream = File.Create(newFilePath);
                    var sw = new StreamWriter(filestream);
                    Image EaglePic = Image.FromFile (@"..\..\img\" + "eagle" + ".png");
                    EaglePic.Save(Path.Combine(newDirPath, "EaglePic.png") );


                    sw.WriteLine("<!DOCTYPE html>");
                    sw.WriteLine("<html>");
                    sw.WriteLine("<head>");
             
                    sw.WriteLine("<meta charset=\"utf-8\" />");
                    sw.WriteLine("<meta http-equiv =\"Content-Type\" content =\"text/html;charset=utf-8\" />");
                    sw.WriteLine("<title>تقرير موظف بتاريخ </title>");

                    sw.WriteLine("<style>");
                    sw.WriteLine(" body");
                    sw.WriteLine("{");
                    sw.WriteLine(" font-family:Arial, Helvetica, sans-serif;");
                    sw.WriteLine(" font-size: 16px;");
                    sw.WriteLine("    font-weight: bold;");
                    sw.WriteLine("}");
                    sw.WriteLine("#mainHolder");
                    sw.WriteLine(" {");
                    sw.WriteLine(" float: right; ");
                    sw.WriteLine("}");
                    sw.WriteLine("table");
                    sw.WriteLine("{");
                    sw.WriteLine("border-collapse:collapse; ");
                    sw.WriteLine(" }");
                    sw.WriteLine("td");
                    sw.WriteLine("{");
                    sw.WriteLine("    border:2px solid black;");
                    sw.WriteLine("   padding:4px;");
                    sw.WriteLine(" direction: rtl; ");
                    sw.WriteLine("  text-align: center;");
                    sw.WriteLine("   width: 25%;");
                    sw.WriteLine("}");
                    sw.WriteLine("h3 ");
                    sw.WriteLine(" {");
                    sw.WriteLine("    float: right;");
                    sw.WriteLine("display: block;");
                    sw.WriteLine("}");
                    sw.WriteLine(".space_col ");
                    sw.WriteLine(" {");
                    sw.WriteLine("border: none;");
                    sw.WriteLine("}");
                    sw.WriteLine(".sing");
                    sw.WriteLine("{ ");
                    sw.WriteLine(" float: right;");
                    sw.WriteLine(" margin-right: 2cm;");
                    sw.WriteLine("}");
                    sw.WriteLine(".color_dark");
                    sw.WriteLine(" {");
                    sw.WriteLine(" background-color: rgb(202, 197, 197); ");
                    sw.WriteLine("}");
                    sw.WriteLine(".header_font");
                    sw.WriteLine("{");
                    sw.WriteLine("text-align:center;");
                    sw.WriteLine("font-size:20px;");
                    sw.WriteLine("}");
                    sw.WriteLine("</style> ");
                    sw.WriteLine(" </head>");

                    sw.WriteLine("<body>");
                    sw.WriteLine("<div id=\"mainHolder\">");
                    sw.WriteLine("<div id=\"receivedTable\" style=\"margin-top:15px; width: 100% \">");

                    sw.WriteLine("<table style = \"width:100%\" >");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"\" class=\"space_col\">قائم على رأس العمل </td>");
                    sw.WriteLine("<td class=\"space_col\"></td>");
                    sw.WriteLine("<td style=\"text-align: right\" class=\"space_col\">مديرية التربية في حلب</td></tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td style=\"\" class=\"space_col\">خاص للعاملين في المدارس</td>");
                    sw.WriteLine("<td class=\"space_col\"><img src=\"EaglePic.png\" width=\"100px\" height=\"80\" /></td>");
                    sw.WriteLine("<td style=\"text-align: right\"class=\"space_col\">الثانوية المهنية لتقنيات الحاسوب بنات </td></tr>");
                    sw.WriteLine("</table>");

                    sw.WriteLine("<table style=\"margin-top:10px; width: 100%; float: center\">");
                    sw.WriteLine("<tr class=\"color_dark\"><td class=\"header_font\" colspan=\"4\">بيانات العامل</td></tr>");
     
                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(Qualification);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">المؤهل العلمي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(FirstName);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الاسم</td></tr>");

                    sw.WriteLine("<tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(PhoneNumber);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">رقم الهاتف</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(LastName);
                    sw.WriteLine("</td>");
                    sw.WriteLine("  <td class=\"color_dark\" >النسبة</td></tr>");

                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(SelfNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\" >الرقم الذاتي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(DadName);
                    sw.WriteLine("</td>");
                    sw.WriteLine("  <td class=\"color_dark\">الأب</td></tr>");

                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(functionality);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الصفة الوظيفية</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(MomName);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">اسم الأم ونسبتها</td></tr>");

                    sw.WriteLine(" <tr>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(certificate);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الاختصاص</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(BirthdayDate);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">مكان و تاريخ الولادة</td></tr>");

                    sw.WriteLine("<tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(Category);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الفئة</td>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(NationalNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الرقم الوطني</td></tr>");

                    sw.WriteLine("<tr>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(DeletionNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">رقم الشطب</td>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(PlaceAndNumQaid);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">محل ورقم القيد</td></tr>");

                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td>");
                    sw.WriteLine(maritialState);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الوضع العائلي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(address);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">مكان الإقامة</td></tr> ");


                    sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"4\">معلومات خاصة بطبيعة العمل</td></tr>");
                    sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"2\"></td>");
                    sw.WriteLine("<td style=\"text-align: center\" colspan=\"2\">(داخل الصف أو خارج الصف وصفته)</td></tr>");
                    sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"4\">ملاحظة : جميع المعلومات المدونة بالنسبة لطبيعة العمل تقع على عائق مدير المدرسة</td></tr>");

                    sw.WriteLine("</table>");
                    sw.WriteLine("</div>");

                    sw.WriteLine("<p class=\"sing\" style=\"float: left; margin - left: 1cm\">اسم وتوقيع صاحب العلاقة</p>");
                    sw.WriteLine("</div>");


                    sw.WriteLine("<table style=\"width:100% \">");
                    sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"4\">إلى دائرة المحاسبة :</td></tr>");
                    sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"4\"> لا يزال العامل المذكور أعلاه قائماً على رأس عمله حتى تاريخ ...............</td></tr>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\">الموجه المشرف</td>");
                    sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\">مدير الثانوية</td></tr>");

                    sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"2\"> الخاتم والتوقيع </td>");
                    sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\"> الخاتم والتوقيع </td></tr>");
                    sw.WriteLine("</table>");
                    sw.WriteLine("</br>");
                    sw.WriteLine("</br>");
                    sw.WriteLine("</br>");
                    sw.WriteLine("</br>");
                    sw.WriteLine("</br>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");
                    sw.Close();
                    myPrint.PrintHelpPage(newFilePath);
                }
            }
        }
    }
}
