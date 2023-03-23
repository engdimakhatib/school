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

namespace MYSCHOOLFINAL
{
    public partial class واجهة_إضافة_تعديل_الموظفين : Form
    {
        public واجهة_إضافة_تعديل_الموظفين()
        {
            InitializeComponent();

        
          if (n == null)
                n = this;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, EMP_Image.Width - 2, EMP_Image.Height - 2);
            Region rg = new Region(gp);
            EMP_Image.Region = rg;
            GraduationDate.CustomFormat = "yyyy";
            BirthdayDate.CustomFormat = "yyyy";
            DirectlyAtSchool.CustomFormat = "yyyy";
            YearStartWork.CustomFormat = "yyyy";
            DateCourses.CustomFormat = "yyyy";
        }
    private static واجهة_إضافة_تعديل_الموظفين n;
    static void cf(object sender, FormClosedEventArgs e)
    {
        n = null;
    }
    public static واجهة_إضافة_تعديل_الموظفين deleg
    {
        get
        {
            if (n == null)
            {
                n = new واجهة_إضافة_تعديل_الموظفين();
            }
            return n;
        }

    }
    public  EMP myEmp = new EMP();
        واجهة_الأعمال_المكلفة woork = new واجهة_الأعمال_المكلفة();
        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
       {

        }

        private void زر_إضافة_عمل_Click(object sender, EventArgs e)
        {
            if(EMP.IsClosingWoork==true )
            {
                woork = new واجهة_الأعمال_المكلفة();
                woork.Show();
            }
            else
            {
                woork.Show();
            }
        }

        private void زر_استعراض_صورة_Click(object sender, EventArgs e)
        {
            EMP_Image.Image = null; 
            openFileDialog1.Filter = "Image Files:|*.jpg;*.gif;*.Bmp;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                EMP_Image.BackgroundImageLayout = ImageLayout.Stretch;
                EMP_Image.Image = Image.FromFile(openFileDialog1.FileName);

            }
                
        }
        //زر الإضافة
        private void Button1_Click(object sender, EventArgs e)
        {
        
            try
            {
                myEmp.FirstName = FirstName.Text.Trim().ToString();
            }
            catch
            {
                MessageBox.Show("يرجى إدخال أحرف فقط", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            try
            {
                myEmp.LastName = LastName.Text.Trim().ToString();
            }
            catch
            {
                MessageBox.Show("يرجى إدخال أحرف فقط", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                myEmp.DadName = DadName.Text.Trim().ToString();
            }
            catch
            {
                MessageBox.Show("يرجى إدخال أحرف فقط", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                myEmp.MomName = MomName.Text.Trim().ToString();
            }
            catch
            {
                MessageBox.Show("يرجى إدخال أحرف فقط", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            myEmp.PhoneNumber =PhoneNumber.Value.ToString();
            myEmp.PlaceAndNumQaid = PlaceAndNumQaid.Text.Trim().ToString();
            myEmp.SelfNum = Convert.ToInt32(SelfNum.Value);
            myEmp.FinancialNum = FinancialNum.Text.Trim().ToString();
            myEmp.ReverseNum = ReverseNum.Text.Trim().ToString();
            myEmp.DeletionNum = DeletionNum.Text.Trim().ToString();
            myEmp.NationalNum = (NationalNum.Value.ToString());
            myEmp.NumBackIdentity = NumBackIdentity.Value.ToString();
            myEmp.Email = Email.Text.Trim().ToString();
            myEmp.maritialState = maritialState.SelectedItem.ToString();
            myEmp.NumChildren = Convert.ToInt32(NumChildren.Value);
            myEmp.Qualification = Qualification.Text.Trim().ToString();
            myEmp.certificate = certificate.Text.Trim().ToString();
            myEmp.GraduationDate = GraduationDate.Value.Year.ToString();

            try {
            myEmp.Category = Category.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("يرجى تحديد الفئة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myEmp.ApprovedName = ApprovedName.Text.Trim().ToString();
            try
            {
                myEmp.Salary = Convert.ToSingle(Salary.Text);
            }
            catch
            {
                MessageBox.Show("يرجى إدخال الراتب كرقم", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   return;
            }
            myEmp.OriginalSchool = OriginalSchool.Text.Trim().ToString();
            myEmp.TempSchool = TempSchool.Text.Trim().ToString();
            myEmp.NumHour = Convert.ToInt32(NumHour.Value);
            myEmp.BirthdayDate = BirthdayDate.Value.Year.ToString();
            myEmp.DirectlyAtSchool = DirectlyAtSchool.Value.Year.ToString();
            myEmp.YearStartWork = YearStartWork.Value.Year.ToString();
            myEmp.situation = situation.Text.Trim().ToString();
            myEmp.NumPresident = Convert.ToInt32(NumPresident.Value);
            myEmp.NumTrustWorthy = Convert.ToInt32(NumTrustWorthy.Value);
            myEmp.DateCourses = DateCourses.Value.Year.ToString();
            myEmp.RecruitmentDivison = RecruitmentDivison.Text.Trim().ToString();
            myEmp.Notes = Notes.Text.Trim().ToString();
            myEmp.address = address.Text.Trim().ToString();
            myEmp.Courses = Courses.Text.Trim().ToString();
          //نقوم بتحويل الصورة لمصفوفة بايتات
            byte[] img = null;

            if (!(EMP_Image.Image == null))
            {
                MemoryStream ms = new MemoryStream();
                EMP_Image.Image.Save(ms, EMP_Image.Image.RawFormat);
                img = ms.ToArray();
            }
            try { 
            if (زر_إضافة_تعديل_موظف.Text == "إضافة")
            {
                if (Check())
                {
                       
                        EMP.id = myEmp.InsertEMP(myEmp.FirstName, myEmp.LastName, myEmp.DadName, myEmp.MomName, myEmp.PhoneNumber, myEmp.PlaceAndNumQaid, myEmp.SelfNum, myEmp.FinancialNum, myEmp.ReverseNum, myEmp.DeletionNum, myEmp.NationalNum, myEmp.NumBackIdentity, myEmp.Email, myEmp.maritialState, myEmp.NumChildren, myEmp.Qualification, myEmp.certificate, myEmp.GraduationDate, myEmp.Category, myEmp.ApprovedName, myEmp.Salary, myEmp.OriginalSchool, myEmp.TempSchool, myEmp.NumHour, myEmp.BirthdayDate, myEmp.DirectlyAtSchool, myEmp.YearStartWork, myEmp.situation, myEmp.NumPresident, myEmp.NumTrustWorthy, myEmp.NumHour, myEmp.DateCourses, myEmp.RecruitmentDivison, img, myEmp.Notes, myEmp.address, myEmp.Courses, AssignedWorkID.Text.Trim().ToString(), functionalityID.Text.Trim().ToString(),EMP.idStudyYear);
                        myEmp.InsertJob(EMP.id, EMP.idStudyYear, Convert.ToInt32(AssignedWorkID.SelectedValue), Convert.ToInt32(functionalityID.SelectedValue), EMP.AssignedWorNewText, EMP.functionalityNewText);
                        MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                }
            }
            //عملية تعديل
            else if (زر_إضافة_تعديل_موظف.Text == "تعديل")
            {
                

                if (Check())
                {
                    myEmp.UpdateEMP(myEmp.FirstName, myEmp.LastName, myEmp.DadName, myEmp.MomName, myEmp.PhoneNumber, myEmp.PlaceAndNumQaid, myEmp.SelfNum, myEmp.FinancialNum, myEmp.ReverseNum, myEmp.DeletionNum, myEmp.NationalNum, myEmp.NumBackIdentity, myEmp.Email, myEmp.maritialState, myEmp.NumChildren, myEmp.Qualification, myEmp.certificate, myEmp.GraduationDate, myEmp.Category, myEmp.ApprovedName, myEmp.Salary, myEmp.OriginalSchool, myEmp.TempSchool, myEmp.NumHour, myEmp.BirthdayDate, myEmp.DirectlyAtSchool, myEmp.YearStartWork, myEmp.situation, myEmp.NumPresident, myEmp.NumTrustWorthy, myEmp.NumHour, myEmp.DateCourses, myEmp.IsMove, myEmp.RecruitmentDivison, img, myEmp.Notes, myEmp.address, myEmp.Courses, AssignedWorkID.Text.Trim().ToString(), functionalityID.Text.Trim().ToString(), EMP.idStudyYear, EMP.id);

                    if (IsScangeWoork(EMP.AssignedWorkOldText,EMP.functionalityOldText,EMP.functionalityNewText,EMP.AssignedWorNewText))
                    {
                        myEmp.UpdateJob(EMP.id, EMP.idStudyYear);
                        myEmp.InsertJob(EMP.id, EMP.idStudyYear, Convert.ToInt32(AssignedWorkID.SelectedValue), Convert.ToInt32(functionalityID.SelectedValue), AssignedWorkID.Text.Trim().ToString(), functionalityID.Text.Trim().ToString());
                    }
                    MessageBox.Show("تم التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
             catch(Exception ex) {
                    MessageBox.Show(ex.Message ,"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // return;
            }
             ClearTextBox();
            واجهة_إدارة_الموظفين.deleg.DGV_EMP.DataSource = myEmp.SelectEMP(EMP.idStudyYear);
            واجهة_إدارة_الموظفين.deleg.rename();   
            int j;
            DataGridViewRow Row;
            for (j = 0; j <= myEmp.MyTable.Rows.Count - 1; j++)
            {
                Row = واجهة_إدارة_الموظفين.deleg.DGV_EMP.Rows[j];
                if (EMP.id == Convert.ToInt32(Row.Cells[0].Value))
                    break;
            }
            EMP.i = j;
            واجهة_إدارة_الموظفين.deleg.Colorfull();        
        }
        public void ClearTextBox()
        {
       
            FirstName.Text ="";
            LastName.Text = "";
            DadName.Text ="";
            MomName.Text ="";
            PhoneNumber.Value =0;
            PlaceAndNumQaid.Text = "";
            SelfNum.Value = 0;
            FinancialNum.Text = "";
            ReverseNum.Text = "";
            DeletionNum.Text ="";
            NationalNum.Value =0;
            NumBackIdentity.Value =0;
            Email.Text ="";
            maritialState.SelectedItem =null;
            NumChildren.Value = 0;
            Qualification.Text ="";
            certificate.Text ="";
            Category.SelectedItem =null;
            ApprovedName.Text = "";
            Salary.Text = "";
            OriginalSchool.Text = "";
            TempSchool.Text ="";
            NumHour.Value = 0;
            situation.Text ="";
            NumPresident.Value=0 ;
            NumTrustWorthy.Value = 0;
            RecruitmentDivison.Text = "";
            Notes.Text = "";
            address.Text ="";
            Courses.Text = "";         
            AssignedWorkID.SelectedItem = null;
            functionalityID.SelectedItem = null;
            AssignedWorkID.Text = "";
            functionalityID.Text = "";
         
            EMP_Image.Image = null;
            GraduationDate.CustomFormat = "yyyy";
            BirthdayDate.CustomFormat = "yyyy";
            DirectlyAtSchool.CustomFormat = "yyyy";
            YearStartWork.CustomFormat = "yyyy";
            DateCourses.CustomFormat = "yyyy";

        }
        
        public Boolean Check()
        {

            Boolean check = true;
            if ((FirstName.Text == "") || (LastName.Text == "")||(DadName.Text=="")||(MomName.Text=="")||(PhoneNumber.Text=="")||(PlaceAndNumQaid.Text=="")||(NationalNum.Text=="")||(NumBackIdentity.Text=="")||(maritialState.Text=="")||(Qualification.Text=="")||(certificate.Text=="")||(GraduationDate.Text=="")||(Category.Text=="")||(Salary.Text=="")||(OriginalSchool.Text=="")||(NumHour.Value==0)||(DirectlyAtSchool.Text=="")||(YearStartWork.Text=="")||(functionalityID.SelectedItem==null)||(AssignedWorkID.SelectedItem==null)||(situation.Text==""))
                check = false;
            return check;
        }
        public Boolean IsScangeWoork(string AssignedWorkOldText, string functionalityOldText, string functionalityNewText, string AssignedWorNewText)
        {
            Boolean IsScangeWoork = true;
            if( (AssignedWorkOldText== AssignedWorNewText)||(functionalityOldText== functionalityNewText))
                IsScangeWoork = false;
            return IsScangeWoork;
        }
        private void واجهة_إضافة_تعديل_الموظفين_Load(object sender, EventArgs e)
        {

            AssignedWorkID.DataSource = myEmp.SelectAssignedWork(EMP.idStudyYear);
           AssignedWorkID.ValueMember = "id";
           AssignedWorkID.DisplayMember = "NameWork";


            if (!(EMP.AssignedWorkIDIndex == -1))
             AssignedWorkID.SelectedValue = EMP.AssignedWorkIDIndex;

            functionalityID.DataSource = myEmp.SelectFunctionality();
            functionalityID.ValueMember = "id";
            functionalityID.DisplayMember = "NameAdj";
            if (!(EMP.functionalityIDIndex == -1))
               functionalityID.SelectedValue = EMP.functionalityIDIndex;
            GraduationDate.CustomFormat = "yyyy";
            BirthdayDate.CustomFormat = "yyyy";
            DirectlyAtSchool.CustomFormat = "yyyy";
            YearStartWork.CustomFormat = "yyyy";
            DateCourses.CustomFormat = "yyyy";
        }

        private void واجهة_إضافة_تعديل_الموظفين_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(زر_إضافة_تعديل_موظف.Text== "إضافة")
            {
                EMP.IsClosingAddEMP = true;
            }
            else
            {
                EMP.IsClosingUpdateEmp = true;
            }
        }

        private void FunctionalityID_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        private void AssignedWorkID_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void MaritialState_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FinancialNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void GraduationDate_ValueChanged(object sender, EventArgs e)
        {
            GraduationDate.CustomFormat = "yyyy";
        }

        private void BirthdayDate_ValueChanged(object sender, EventArgs e)
        {
            BirthdayDate.CustomFormat = "yyyy";
        }

        private void DirectlyAtSchool_ValueChanged(object sender, EventArgs e)
        {
            DirectlyAtSchool.CustomFormat = "yyyy";
        }

        private void YearStartWork_ValueChanged(object sender, EventArgs e)
        {
            YearStartWork.CustomFormat = "yyyy";
        }

        private void DateCourses_ValueChanged(object sender, EventArgs e)
        {
            DateCourses.CustomFormat = "yyyy";
        }

        private void Salary_TextChanged(object sender, EventArgs e)
        {
        }

        private void IsMove_CheckedChanged(object sender, EventArgs e)
        {
            if (IsMove.Checked)
                myEmp.IsMove = 1;
            else
                myEmp.IsMove = 0;
        }

        private void BirthdayDate_ValueChanged_1(object sender, EventArgs e)
        {
            BirthdayDate.CustomFormat = "yyyy";
        }

        private void DirectlyAtSchool_ValueChanged_1(object sender, EventArgs e)
        {
            DirectlyAtSchool.CustomFormat = "yyyy";
        }

        private void YearStartWork_ValueChanged_1(object sender, EventArgs e)
        {
            YearStartWork.CustomFormat = "yyyy";
        }

        private void DateCourses_ValueChanged_1(object sender, EventArgs e)
        {
            DateCourses.CustomFormat = "yyyy";
        }

        private void GraduationDate_ValueChanged_1(object sender, EventArgs e)
        {
            GraduationDate.CustomFormat = "yyyy";
        }

        private void EMP_Image_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel4_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Column%2==0)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.CellBounds);
            }
           
        }

        private void FunctionalityID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            EMP.functionalityNewText = functionalityID.Text.ToString();

        }

        private void AssignedWorkID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            EMP.AssignedWorNewText = AssignedWorkID.Text.ToString();
        }

        private void TableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label25_Click(object sender, EventArgs e)
        {

        }
    }
}
