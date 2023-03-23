using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.IO;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_إدارة_اللطلاب : Form
    {

        public static واجهة_إدارة_الشعب division = new واجهة_إدارة_الشعب();
        public static واجهة_إدارة_الفئات category = new واجهة_إدارة_الفئات();
        public static واجهة_إدارة_الاختبارات exam = new واجهة_إدارة_الاختبارات();
        private static واجهة_إدارة_اللطلاب n;
        public DataSet1TableAdapters.MessStuTableAdapter adMessStu = new DataSet1TableAdapters.MessStuTableAdapter();

        public DataSet1TableAdapters.SortDivisionTableAdapter adSortDivision = new DataSet1TableAdapters.SortDivisionTableAdapter();
        public DataSet1TableAdapters.SortCategoryTableAdapter asSortCategory = new  DataSet1TableAdapters.SortCategoryTableAdapter();
        public DataTable MessStu;
        public DataTable MessStuCheck;
        STU myStu = new STU();
        MessStu myMessStu = new MessStu();
        PL.StuMark myStuMark = new PL.StuMark();
        Exam myExam = new Exam();
        ClassDivisionCategory MyClassDivisionCategory = new ClassDivisionCategory();
        HeaderCheckBox myHeaderCheckBoxClass1 = new HeaderCheckBox();
        HeaderCheckBox myHeaderCheckBoxDivision1 = new HeaderCheckBox();
        HeaderCheckBox MyHeaderCheckBoxSortDivision = new HeaderCheckBox();

        HeaderCheckBox myHeaderCheckBoxClass2 = new HeaderCheckBox();
        HeaderCheckBox myHeaderCheckBoxDivision2 = new HeaderCheckBox();
        HeaderCheckBox myHeaderCheckBoxCategory2 = new HeaderCheckBox();
        HeaderCheckBox MyHeaderCheckBoxSortCategory = new HeaderCheckBox();
        public string TotalNumStudent;
        public string TypeSubject;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_إدارة_اللطلاب deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_إدارة_اللطلاب();
                }
                return n;
            }

        }
        public واجهة_إدارة_اللطلاب()
        {
            InitializeComponent();
            if (n == null)
                n = this;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, STU_Image.Width - 2, STU_Image.Height - 2);
            Region rg = new Region(gp);
            STU_Image.Region = rg;
        }
        public void ShowDivisionOrCareoryByTypeSubject()
        {

            TypeSubject = myStuMark.SelectTypeSubject(myStuMark.SubjectId);
            //  myStuMark.SubjectEMP = myStuMark.ShowEmpSubject(myStuMark.SubjectId);
            //هذا الجزء يجب إضافته بعد إسناد المواد للمدرسين
            //if (myStuMark.SubjectEMP.Count  == 0)
            //{
            //    MessageBox.Show("الرجاء تحديد المدرسين لهذها لمادة من واجهة إسناد المدرسين لمادة", "لا يوجد مدرس مكلّف بهذه المادة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            {
                //   ClassDivisionCategory.ShowEmpSubject(NameEmps, myStuMark.SubjectId);
                for (int i = 0; i < myStuMark.SubjectEMP.Count; i++)
                {
                    NameEmps.Lines[i] = myStuMark.SubjectEMP[i];
                }
                idStu_DGV.DataSource = null;
                //إذا كان الطالب موجود أو السجل موجود سنحمله للتعديل و إلا سننشأ سجل له
                if (TypeSubject == "عملي")
                {
                   CategoryID.Enabled = true;
                    ClassDivisionCategory.ShowCustomCategory(CategoryID, Division.idStudyYear);
                    myStuMark.ThisClicked = false;
                    if (!(CategoryID.Items.Count == 0))
                    {                      
                            CategoryID.SelectedIndex = 0;
                    }         
                    DataTable MarkStuSortCategory = asSortCategory.GetDataByShowSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId);
                    DataTable MarkStuCheckSortCategory = asSortCategory.GetDataByShowCheckSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId,myStuMark.idExam);
                    if (MarkStuCheckSortCategory.Rows.Count == 0)
                        idStu_DGV.DataSource = MarkStuSortCategory;
                    else
                        idStu_DGV.DataSource = MarkStuCheckSortCategory;
                    rename_idStu_DGV();
                }
                else if (TypeSubject == "نظري")
                {
                    //التمرين غير موجود و بالتالي سنضيفه لجدول العلامات
                    DataTable MarkStuSortDivision = adSortDivision.GetDataByShowSortDivision(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                    //التمرين موجود و بالتالي سنعدّل و سنجلبه من جدول العلامات
                    DataTable MarkStuCheckSortDivision = adSortDivision.GetDataByShowCheckSortDivision(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.idExam);
                     
                    CategoryID.Enabled = false;
                   if(MarkStuCheckSortDivision.Rows.Count==0)
                        idStu_DGV.DataSource = MarkStuSortDivision;
                   else
                        idStu_DGV.DataSource = MarkStuCheckSortDivision;
                    rename_idStu_DGV();
                }
               
            }
        }
      
        //uncheck all other items in itemcheck event
        private void IdExam_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //    for (int i = 0; i < idExam.Items.Count; i++)
            //        if (i != e.Index) idExam.SetItemChecked(i, false);
            //الطريقة الأفضل
            if (myStuMark.IsLoad)
            {
                if (myStuMark.ThisClicked) {
                    myStuMark.ThisClicked = false;
                    if (e.NewValue == CheckState.Checked && idExam.CheckedItems.Count > 0)
                    {
                        idExam.ItemCheck -= IdExam_ItemCheck;
                        idExam.SetItemChecked(idExam.CheckedIndices[0], false);
                        idExam.ItemCheck += IdExam_ItemCheck;
                        myStuMark.idExam = (int)idExam.SelectedValue;
                                          
                    }
                    ShowDivisionOrCareoryByTypeSubject();
                    myStuMark.ThisClicked = true;
                }
            }
           
        }
        private void SubjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myStuMark.IsLoad)
            {
                if (myStuMark.ThisClicked)
                {
                    myStuMark.ThisClicked = false;
                    myStuMark.SubjectId = ClassDivisionCategory.IdSubjects[SubjectID.SelectedIndex];
                    ShowDivisionOrCareoryByTypeSubject();
                    myStuMark.ThisClicked = true;
                }
                

           
                                        
    

                }
          
                 
        }
        private void ClassID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myStuMark.IsLoad)
            {
             if (myStuMark.ThisClicked) {
                    myStuMark.ThisClicked = false;

                    myStuMark.IdClass = ClassDivisionCategory.IdClasses[ClassID.SelectedIndex];
                    ClassDivisionCategory.ShowCustomHall(HallID, STU.idStudyYear, myStuMark.IdClass);
                    if (!(HallID.Items.Count == 0))
                    {
                        HallID.SelectedIndex = 0;
                        myStuMark.idHall = ClassDivisionCategory.IdHalls[0];
                    }
                    ClassDivisionCategory.ShowCustomSubject(SubjectID, Division.idStudyYear, myStuMark.IdClass);
                    if (!(SubjectID.Items.Count == 0))
                    {
                        SubjectID.SelectedIndex = 0;
                        myStuMark.SubjectId = ClassDivisionCategory.IdSubjects[0];

                    }
                    ClassDivisionCategory.ShowCustomSelectDivisionForThisClass(DivisionID, Division.idStudyYear, myStuMark.IdClass);
                    if (!(DivisionID.Items.Count == 0))
                    {
                        DivisionID.SelectedIndex = 0;
                        myStuMark.DivisionId = ClassDivisionCategory.IdDivisiones[0];
                    }
                    ClassDivisionCategory.SelectCategoryForThisClass(CategoryID, Division.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                    if (!(CategoryID.Items.Count == 0))
                    {
                        CategoryID.SelectedIndex = 0;
                        myStuMark.CategoryId = ClassDivisionCategory.IdCategories[0];
                    }
                

                    ShowDivisionOrCareoryByTypeSubject();
                    myStuMark.ThisClicked = true;
                }
            }                   
        }
        private void IDSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            myStuMark.idSeason = ClassDivisionCategory.IdSeasons[IDSeason.SelectedIndex];
        }
        private void DivisionID_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (myStuMark.IsLoad)
            {
                if (myStuMark.ThisClicked) { 
                myStuMark.ThisClicked = false;
                myStuMark.DivisionId = ClassDivisionCategory.IdDivisiones[DivisionID.SelectedIndex];               
                ShowDivisionOrCareoryByTypeSubject();
                myStuMark.ThisClicked = true;
            }           
        }
        }
        private void CategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myStuMark.IsLoad)
            {
                if (myStuMark.ThisClicked)
                {
                    myStuMark.ThisClicked = false;
                    myStuMark.CategoryId = ClassDivisionCategory.IdCategories[CategoryID.SelectedIndex];
                    ShowDivisionOrCareoryByTypeSubject();
                    myStuMark.ThisClicked = true;
                }
            }
        }

        public void rename_idStu_DGV()
        {

            idStu_DGV.Columns[0].Visible = false;
            idStu_DGV.Columns[3].Visible = false;
            idStu_DGV.Columns[4].Visible = false;
            idStu_DGV.Columns[5].Visible = false;
        }

        private void BeginExam_ValueChanged(object sender, EventArgs e)
        {
            myStuMark.BeginExam = BeginExam.Value;
        }
        private void EndExam_ValueChanged(object sender, EventArgs e)
        {
            myStuMark.EndExam = EndExam.Value;

        }
        private void HallID_SelectedIndexChanged(object sender, EventArgs e)
        {
            myStuMark.idHall = ClassDivisionCategory.IdHalls[HallID.SelectedIndex];
        }


        public void ShowSortDivisionMess()
        {

            MessStu = adMessStu.GetDataShowMess(STU.idStudyYear, myMessStu.IdClass, myMessStu.idDivision);
            MessStuCheck = adMessStu.GetDataByShowCheckMess(STU.idStudyYear, myMessStu.IdClass, myMessStu.idDivision,myMessStu.DateDay);
            if(MessStuCheck.Rows.Count==0)
            this.idStuMess_DGV.DataSource = MessStu;
            else
                this.idStuMess_DGV.DataSource = MessStuCheck;
            rename_idStuMess_DGV();

        }
        public void rename()
        {
            this.DGV_STU.Columns[2].HeaderText = "الاسم";
            this.DGV_STU.Columns[3].HeaderText = "الكنية";
            this.DGV_STU.Columns[4].HeaderText = "اسم الأب";
            this.DGV_STU.Columns[5].HeaderText = "اسم الأم";
            this.DGV_STU.Columns[6].HeaderText = "تاريخ الميلاد";
            this.DGV_STU.Columns[7].HeaderText = "مكان الولادة";
            this.DGV_STU.Columns[8].HeaderText = "تاريخ التسجيل";
            this.DGV_STU.Columns[9].HeaderText = "مجموع التاسع";
            this.DGV_STU.Columns[10].HeaderText = "العنوان";
            this.DGV_STU.Columns[11].HeaderText = "رقم الهاتف";
            this.DGV_STU.Columns[12].HeaderText = "رقم الاكتتاب";
            this.DGV_STU.Columns[13].HeaderText = "اسم الصف";
            this.DGV_STU.Columns[14].HeaderText = "ملاحظات";
            //id
            this.DGV_STU.Columns[0].Visible = false;
            //idClass
            this.DGV_STU.Columns[1].Visible = false;
            //Stu_img
            this.DGV_STU.Columns[15].Visible = false;

        }
        public void ShowRecord()
        {

            if (STU.MyTable.Rows.Count == 0)
            {
                ClearTextBoxes();
            }
            else
            {
                myStu.isShowRecord = true;
                // STU.x = STU.i;
                myStu.id = Convert.ToInt32(STU.MyTable.Rows[STU.i]["id"]);
                FirstName.Text = STU.MyTable.Rows[STU.i]["FirstName"].ToString();
                LastName.Text = STU.MyTable.Rows[STU.i]["LastName"].ToString();
                DadName.Text = STU.MyTable.Rows[STU.i]["DadName"].ToString();
                MomName.Text = STU.MyTable.Rows[STU.i]["MomName"].ToString();
                DateRegistration.CustomFormat = "yyyy";
                int year1 = Convert.ToInt32(STU.MyTable.Rows[STU.i]["DateRegistration"]);
                DateTime d1 = new DateTime(year1, 1, 1);
                DateRegistration.Value = d1;
                DateBirthday.CustomFormat = "dd/MM/yyyy";
                DateTime year2 = Convert.ToDateTime(STU.MyTable.Rows[STU.i]["DateBirthday"]);
                DateBirthday.Value = year2;
                PlaceBirthday.Text = STU.MyTable.Rows[STU.i]["PlaceBirthday"].ToString();
                Sum.Value = Convert.ToDecimal(STU.MyTable.Rows[STU.i]["Sum"]);
                Address.Text = STU.MyTable.Rows[STU.i]["Address"].ToString();
                PhoneNum.Value = Convert.ToDecimal(STU.MyTable.Rows[STU.i]["PhoneNum"]);
                NumExam.Value = Convert.ToDecimal(STU.MyTable.Rows[STU.i]["NumExam"]);
                Notes.Text = STU.MyTable.Rows[STU.i]["Notes"].ToString();
                myStu.IdClass = ClassDivisionCategory.IdClasses[IdClassShow.SelectedIndex];
                myStu.NameClass = IdClassShow.SelectedItem.ToString();

                byte[] stu_img =
             (byte[])myStu.selectSTUimg(Convert.ToInt32(this.DGV_STU.CurrentRow.Cells[0].Value)).Rows[0][0];

                MemoryStream ms = new MemoryStream(stu_img);
                if (!(ms == null))
                {
                    STU_Image.SizeMode = PictureBoxSizeMode.Zoom;
                    STU_Image.BackgroundImageLayout = ImageLayout.Zoom;

                    // STU_Image.BackgroundImage.Dispose();
                    STU_Image.BackgroundImage = null;
                    //  STU_Image.Image = null;
                    STU_Image.Invalidate();
                    STU_Image.Image = Image.FromStream(ms);
                    //   STU_Image.Update();

                }
                this.Refresh();
                myStu.isShowRecord = false;

            }
        }
        public void ClearTextBoxes()
        {
            FirstName.Text = "";
            LastName.Text = "";
            DadName.Text = "";
            MomName.Text = "";
            IdClass.SelectedItem = null;
            DateBirthday.CustomFormat = " ";
            Address.Text = "";
            Notes.Text = "";
            PlaceBirthday.Text = "";
            DateRegistration.CustomFormat = " ";
            Sum.Value = 0;
            PhoneNum.Value = 0;
            NumExam.Value = 0;
            if (!(STU_Image.Image == null))
                STU_Image.Image = null;
        }
        public Boolean check()
        {
            Boolean ischeck = true;
            if ((myStu.FirstName == "") || (myStu.LastName == "") || (myStu.DadName == "") || (myStu.MomName == "") || (myStu.PlaceBirthday == "") || (myStu.DateBirthday == "") || (myStu.DateRegistration == "") || (myStu.Sum == "0"))
                ischeck = false;
            return ischeck;
        }
        public void Colorfull()
        {
            if (!(DGV_STU.Rows.Count == 0))
            {

                this.DGV_STU.ClearSelection();
                this.DGV_STU.CurrentCell = this.DGV_STU.Rows[STU.i].Cells[4];
                this.DGV_STU.CurrentRow.Selected = true;
                this.DGV_STU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.DGV_STU.Refresh();
                this.DGV_STU.Rows[STU.i].Selected = true;
                //  this.DGV_STU.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.;
                //   this.DGV_STU.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.White;
            }
        }
        //public void colorfull(int j, int i)
        //{
        //    if (DGV_STU.Rows.Count != 0)
        //    {
        //       // this.DGV_STU.ClearSelection();
        //    //    this.DGV_STU.CurrentCell = this.DGV_STU.Rows[STU.i].Cells[3];
        //   //     this.DGV_STU.CurrentRow.Selected = true;
        //     //   this.DGV_STU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //       // this.DGV_STU.Rows[STU.i].Selected = true;
        //      //  this.DGV_STU.Refresh();
        //        DGV_STU.Rows[j].DefaultCellStyle.BackColor = Color.White;
        //        DGV_STU.Rows[j].DefaultCellStyle.ForeColor = Color.Black;

        //        DGV_STU.Rows[i].DefaultCellStyle.BackColor = Color.Maroon;
        //        DGV_STU.Rows[i].DefaultCellStyle.ForeColor = Color.White;

        //    }
        //}
        private void TableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void TableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            if (e.Column % 2 == 0)
            {
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.CellBounds);
            }

        }

        public void LoadDivisionSortInfoMethod()
        {
            DataTable LoadDivisionSortInfo = MyClassDivisionCategory.LoadSortDivisionDetailsInfo(ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentDivision, MyClassDivisionCategory.DivisionDivisionID);
            if (!(LoadDivisionSortInfo.Rows.Count == 0))
            {
                NumTotalDivision.Text = LoadDivisionSortInfo.Rows[0]["NumTotalDivision"].ToString();
                NumDivisionClass.Text = LoadDivisionSortInfo.Rows[0]["NumDivisionforClass"].ToString(); ;
                NumStuInDivision.Text = LoadDivisionSortInfo.Rows[0]["NumStuInThisDivision"].ToString();
            }
        }
        public void LoadSTUInfoMethod()
        {
            DataTable LoadSTUInfo = myStu.LoadSTUInfoMethod(STU.idStudyYear, myStu.IdClass);
            if (!(LoadSTUInfo.Rows.Count == 0))
            {
                NumTotalSTU.Text = LoadSTUInfo.Rows[0]["NumTotalSTU"].ToString();
                NumStuClass.Text = LoadSTUInfo.Rows[0]["NumStuClass"].ToString();
            }
        }

       
        public void rename_idStuMess_DGV()
        {
            idStuMess_DGV.Columns[0].Visible = false;

        }
        public void RenamedataGridCategoryStudent()
        {
            dataGridStudentCategory.Columns[1].HeaderText = " ";
            dataGridStudentCategory.Columns[2].HeaderText = " ";
            dataGridStudentCategory.Columns[3].HeaderText = " ";
            dataGridStudentCategory.Columns[1].Visible = false;
        }
        public void LoaddataGridDivisionStudent()
        {
            dataGridDivisionStudent.DataSource = null;
            dataGridDivisionStudent.DataSource = MyClassDivisionCategory.SelectStuClassDivision(MyClassDivisionCategory.StudentDivision, ClassDivisionCategory.idStudyYear);
            dataGridDivisionStudent.Columns[1].HeaderText = " ";
            dataGridDivisionStudent.Columns[2].HeaderText = " ";
            dataGridDivisionStudent.Columns[3].HeaderText = " ";
            dataGridDivisionStudent.Columns[1].Visible = false;
        }
        public void LoaddataGridSortDivision()
        {
            dataGridSortDivision.DataSource = null;
            dataGridSortDivision.DataSource = MyClassDivisionCategory.ShowSortDivision(ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentDivision, MyClassDivisionCategory.DivisionDivisionID);

            dataGridSortDivision.Columns[1].Visible = false;
            dataGridSortDivision.Columns[1].HeaderText = " ";
            dataGridSortDivision.Columns[2].HeaderText = " ";
            dataGridSortDivision.Columns[3].HeaderText = " ";
            dataGridSortDivision.Columns[4].HeaderText = " ";
            dataGridSortDivision.Columns[5].HeaderText = " ";

        }
        public void loaddataGridCategoryStudent()
        {
            dataGridStudentCategory.DataSource = MyClassDivisionCategory.SelectStuClassCategory(MyClassDivisionCategory.StudentCategoryID, ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.DivisionCategoryID);
            dataGridStudentCategory.Columns[1].HeaderText = " ";
            dataGridStudentCategory.Columns[2].HeaderText = " ";
            dataGridStudentCategory.Columns[3].HeaderText = " ";
            dataGridStudentCategory.Columns[1].Visible = false;
        }
        public void loaddataGridSortCategory()
        {
            واجهة_إدارة_اللطلاب.deleg.dataGridSortCategory.DataSource = MyClassDivisionCategory.ShowSortCategory(ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentCategoryID, MyClassDivisionCategory.DivisionCategoryID, MyClassDivisionCategory.CategoryCategoryID);
            dataGridSortCategory.Columns[1].Visible = false;
            dataGridSortCategory.Columns[1].HeaderText = " ";
            dataGridSortCategory.Columns[2].HeaderText = " ";
            dataGridSortCategory.Columns[3].HeaderText = " ";
            dataGridSortCategory.Columns[4].HeaderText = " ";
            dataGridSortCategory.Columns[5].HeaderText = " ";
            dataGridSortCategory.Columns[6].HeaderText = " ";
        }

        private void زر_حذف_طالب_Click(object sender, EventArgs e)
        {
            DateBirthday.CustomFormat = "dd/MM/yyyy";
            DateRegistration.CustomFormat = "yyyy";

            try
            {
                myStu.IdClass = ClassDivisionCategory.IdClasses[IdClass.SelectedIndex];
                myStu.NameClass = IdClass.SelectedItem.ToString().Trim();
                LoadSTUInfoMethod();
                myStu.FirstName = FirstName.Text.Trim().ToString();
                myStu.LastName = LastName.Text.Trim().ToString();
                myStu.DadName = DadName.Text.Trim().ToString();
                myStu.MomName = MomName.Text.Trim().ToString();
                myStu.DateBirthday = DateBirthday.Value.ToString();
                myStu.DateRegistration = DateRegistration.Value.Year.ToString();
                myStu.PlaceBirthday = PlaceBirthday.Text;
                myStu.Sum = Sum.Value.ToString();
                myStu.Address = Address.Text;
                myStu.PhoneNum = PhoneNum.Value.ToString();
                myStu.NumExam = NumExam.Value.ToString();
                myStu.Notes = Notes.Text;

                byte[] img = null;
                if (!(STU_Image.Image == null))
                {
                    MemoryStream ms = new MemoryStream();
                    STU_Image.Image.Save(ms, STU_Image.Image.RawFormat);
                    img = ms.ToArray();
                    myStu.img = img;
                }
                else
                {
                    STU_Image.Image = Image.FromFile(@"..\..\img\" + "تنزيل" + ".png");
                    MemoryStream ms = new MemoryStream();
                    STU_Image.Image.Save(ms, STU_Image.Image.RawFormat);
                    img = ms.ToArray();
                    myStu.img = img;

                }
              
             
            }

            catch
            {
                MessageBox.Show("رجى إدخال معلومات صحيحة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (check())
            {
                myStu.StuInfo = myStu.InsertSTU(myStu.FirstName, myStu.LastName, myStu.DadName, myStu.MomName, myStu.DateBirthday, myStu.PlaceBirthday, myStu.DateRegistration, myStu.Sum, myStu.Notes, STU.idStudyYear, myStu.Address, myStu.IdClass, myStu.NameClass, myStu.PhoneNum, myStu.NumExam, myStu.img);
                myStu.id = Convert.ToInt32(myStu.StuInfo[0]);
                DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                rename();
                ClearTextBoxes();
                MessageBox.Show("تمت العملية بنجاح", "معلومات عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                LoadSTUInfoMethod();
                dataGridDivisionStudent.DataSource = null;
       LoaddataGridDivisionStudent();

            }
            else
                MessageBox.Show("يرجى إدخال المعلومات الأساسية المطلوبة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void SelectTab()
        {
            if (findTabPage == 1)
            {
                DateBirthday.CustomFormat = "dd/MM/yyyy";
                DateRegistration.CustomFormat = "yyyy";
                DateBirthday.CustomFormat = "dd/MM/yyyy";
                DateRegistration.CustomFormat = "yyyy";
                #region 
                //جزء خاص طلاب
                ClearTextBoxes();
                ClassDivisionCategory.ShowCustomClass(IdClass);
                ClassDivisionCategory.ShowCustomClass(IdClassShow);
                IdClass.Text = myStu.NameClass = IdClassShow.Text = " الأول الثانوي";
                myStu.IdClass = 1;
                IdClass.SelectedIndex = 0;
                IdClassShow.SelectedIndex = 0;
                myStu.isLoad = true;
                DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                rename();
                STU.i = 0;
                Colorfull();
                ShowRecord();
                try
                {
                    byte[] stu_img =
            (byte[])myStu.selectSTUimg(Convert.ToInt32(this.DGV_STU.CurrentRow.Cells[0].Value)).Rows[0][0];
                    MemoryStream ms = new MemoryStream(stu_img);
                    if (!(ms == null))
                    {
                        STU_Image.Image = null;
                        STU_Image.BackgroundImage = null;
                        STU_Image.SizeMode = PictureBoxSizeMode.Zoom;
                        STU_Image.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    //  return;
                }
                myStu.isLoad = false;
                this.Refresh();
                LoadSTUInfoMethod();
                // NumTotalSTU.Text = myStu.StuInfo[0].ToString();
                //  NumStuClass.Text = myStu.StuInfo[1].ToString();
                #endregion
            }
            if (findTabPage == 2)
            {
                #region
                //جزء خاص بفرز الشعب
                ClassDivisionCategory.ShowCustomDivision(DivisionDivision, Division.idStudyYear);
                ClassDivisionCategory.ShowCustomClass(StudentDivision);
                MyHeaderCheckBoxSortDivision.G = dataGridSortDivision;
                MyHeaderCheckBoxSortDivision.AddHeaderCheckBox(MyHeaderCheckBoxSortDivision.G);
                MyHeaderCheckBoxSortDivision.Header.MouseClick += new MouseEventHandler(MyHeaderCheckBoxSortDivision.HeaderCheckBox_MouseClick);
                myHeaderCheckBoxClass1.G = dataGridDivisionStudent;
                myHeaderCheckBoxClass1.AddHeaderCheckBox(myHeaderCheckBoxClass1.G);
                myHeaderCheckBoxClass1.Header.MouseClick += new MouseEventHandler(myHeaderCheckBoxClass1.HeaderCheckBox_MouseClick);
                StudentDivision.SelectedIndex = 0;
                MyClassDivisionCategory.StudentDivision = ClassDivisionCategory.IdClasses[0];
                ClassDivisionCategory.IsLoadClassForDivision = true;
                if (!(DivisionDivision.Items.Count == 0))
                {
                    DivisionDivision.SelectedIndex = 0;
                    MyClassDivisionCategory.DivisionDivisionID = ClassDivisionCategory.IdDivisiones[0];
                    ClassDivisionCategory.IsLoadDivisionForDivision = true;
                }
                LoaddataGridDivisionStudent();
                LoaddataGridSortDivision();
                #endregion
            }
            if (findTabPage == 3)
            {
                #region
                //جزء خاص بفرز الفئات
                ClassDivisionCategory.ShowCustomClass(StudentCategory);
                ClassDivisionCategory.ShowCustomDivision(DivisionCategory, ClassDivisionCategory.idStudyYear);
                ClassDivisionCategory.ShowCustomCategory(CategoryCategory, ClassDivisionCategory.idStudyYear);

                if (!(DivisionCategory.Items.Count == 0))
                {
                    DivisionCategory.SelectedIndex = 0;
                    MyClassDivisionCategory.DivisionCategoryID = ClassDivisionCategory.IdDivisiones[0];
                    ClassDivisionCategory.IsLoadDivisionForCategory = true;
                }

                MyClassDivisionCategory.StudentCategoryID = ClassDivisionCategory.IdClasses[0];
                StudentCategory.SelectedIndex = 0;
                ClassDivisionCategory.IsLoadClassForCategory = true;

                if (!(CategoryCategory.Items.Count == 0))
                {
                    CategoryCategory.SelectedIndex = 0;
                    MyClassDivisionCategory.CategoryCategoryID = ClassDivisionCategory.IdCategories[0];
                }

                loaddataGridCategoryStudent();
                loaddataGridSortCategory();

                myHeaderCheckBoxClass2.G = dataGridStudentCategory;
                myHeaderCheckBoxClass2.AddHeaderCheckBox(myHeaderCheckBoxClass2.G);
                myHeaderCheckBoxClass2.Header.MouseClick += new MouseEventHandler(myHeaderCheckBoxClass2.HeaderCheckBox_MouseClick);

                MyHeaderCheckBoxSortCategory.G = dataGridSortCategory;
                MyHeaderCheckBoxSortCategory.AddHeaderCheckBox(MyHeaderCheckBoxSortCategory.G);
                MyHeaderCheckBoxSortCategory.Header.MouseClick += new MouseEventHandler(MyHeaderCheckBoxSortCategory.HeaderCheckBox_MouseClick);
                #endregion
            }
            if (findTabPage == 5)
            {
                #region
                //جزء خاص بالعلامات
                ClassDivisionCategory.ShowCustomClass(ClassID);
                ClassID.SelectedIndex = 0;
                myStuMark.IdClass = 1;
                myStuMark.NameClass = "الأول الثانوي";
                ClassDivisionCategory.ShowCustomSelectDivisionForThisClass(DivisionID, Division.idStudyYear, myStuMark.IdClass);
                if (!(DivisionID.Items.Count == 0))
                {
                    DivisionID.SelectedIndex = 0;
                    myStuMark.DivisionId = ClassDivisionCategory.IdDivisiones[0];
                }
           
                ClassDivisionCategory.SelectCategoryForThisClass(CategoryID, Division.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                if (!(CategoryID.Items.Count == 0))
                {
                    CategoryID.SelectedIndex = 0;
                    myStuMark.CategoryId = ClassDivisionCategory.IdCategories[0];
                }

                ClassDivisionCategory.ShowCustomSeason(IDSeason);
                IDSeason.SelectedIndex = 0;
                myStuMark.idSeason = ClassDivisionCategory.IdSeasons[0];



                ClassDivisionCategory.ShowCustomHall(HallID, STU.idStudyYear, myStuMark.IdClass);
                if (!(HallID.Items.Count == 0))
                {
                    HallID.SelectedIndex = 0;
                    myStuMark.idHall = ClassDivisionCategory.IdHalls[0];
                }
                ClassDivisionCategory.ShowCustomSubject(SubjectID, Division.idStudyYear, myStuMark.IdClass);
                if (!(SubjectID.Items.Count == 0))
                {
                    SubjectID.SelectedIndex = 0;
                    myStuMark.SubjectId = ClassDivisionCategory.IdSubjects[0];

                }
                //باسماء التمارين checkedListBox  تعبئة
                DataTable dt = myExam.SelectExam();
                ((ListBox)idExam).DataSource = dt;
                ((ListBox)idExam).DisplayMember = "NameExam";
                ((ListBox)idExam).ValueMember = "id";

                //التمرين المختار , يجب اختيار تمرين واحد فقط
                //الحصول رقمه
                myStuMark.idExam = (int)idExam.SelectedValue;

                myStuMark.BeginExam = BeginExam.Value;
                myStuMark.EndExam = EndExam.Value;
           
                myStuMark.IsLoad = true;
                                                              
                #endregion
            }
            if (findTabPage == 4)
            {
                try
                {
                    #region
                    //جزء خاص بحضور الطلاب
                    ClassDivisionCategory.ShowCustomClass(classMessID);
                    classMessID.SelectedIndex = 0;
                    myMessStu.IdClass = 1;
                    myMessStu.NameClass = "الأول الثانوي";

                    ClassDivisionCategory.ShowCustomSelectDivisionForThisClass(divisionMessID, Division.idStudyYear, myMessStu.IdClass);
                    if (!(DivisionID.Items.Count == 0))
                    {
                        divisionMessID.SelectedIndex = 0;
                        myMessStu.idDivision = ClassDivisionCategory.IdDivisiones[0];
                    }
                    ClassDivisionCategory.ShowCustomSeason(seasonMessID);
                    seasonMessID.SelectedIndex = 0;
                    myMessStu.idSeason = seasonMessID.SelectedIndex;
                    //إذا كان الطالب موجود أو السجل موجود سنحمله للتعديل و إلا سننشأ سجل له        
                    //   ShowSortDivisionMess();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                #endregion
            }
        }
        private void واجهة_إدارة_اللطلاب_Load(object sender, EventArgs e)
        {
            findTabPage = 1;
            if (findTabPage == 1)
            {
                DateBirthday.CustomFormat = "dd/MM/yyyy";
                DateRegistration.CustomFormat = "yyyy";
                DateBirthday.CustomFormat = "dd/MM/yyyy";
                DateRegistration.CustomFormat = "yyyy";
                #region 
                //جزء خاص طلاب
                ClearTextBoxes();
                ClassDivisionCategory.ShowCustomClass(IdClass);
                ClassDivisionCategory.ShowCustomClass(IdClassShow);
                IdClass.Text = myStu.NameClass = IdClassShow.Text = " الأول الثانوي";
                myStu.IdClass = 1;
                IdClass.SelectedIndex = 0;
                IdClassShow.SelectedIndex = 0;
                myStu.isLoad = true;
                DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                rename();
                STU.i = 0;
                Colorfull();
                ShowRecord();
                if (!(DGV_STU.Rows.Count == 0))
                {
                    try
                    {
                        byte[] stu_img =
                           (byte[])myStu.selectSTUimg(Convert.ToInt32(this.DGV_STU.CurrentRow.Cells[0].Value)).Rows[0][0];
                        MemoryStream ms = new MemoryStream(stu_img);
                        if (!(ms == null))
                        {
                            STU_Image.Image = null;
                            STU_Image.BackgroundImage = null;
                            STU_Image.SizeMode = PictureBoxSizeMode.Zoom;
                            STU_Image.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        //  return;
                    }
                }
                myStu.isLoad = false;
                this.Refresh();
                LoadSTUInfoMethod();
             
                #endregion
            }
            findTabPage1=false;
        }

        //  private void TableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        //  {

        // }

        // private void Label14_Click(object sender, EventArgs e)
        // {

        // }

        //  private void DGV_STU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //  {

        //   }

        // private void TextBox1_TextChanged(object sender, EventArgs e)
        // {

        //  }

        //  private void Button1_Click(object sender, EventArgs e)
        //  {

        //  }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            DGV_STU.DataSource = myStu.SearchStu(STU.idStudyYear, textBox1.Text);
            rename();
        }

        private void زر_طباعة_معلوامات_طلاب_Click(object sender, EventArgs e)
        {
            STU.x = STU.i;
            STU.i = 0;
            Colorfull();
            ShowRecord();
        }

        private void DGV_STU_DoubleClick(object sender, EventArgs e)
        {
            int year;
            if (DGV_STU.Rows.Count > 0)
            {
                myStu.isDoubleClick = true;
                int SelectRowIndex = DGV_STU.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_STU.Rows[SelectRowIndex];
                STU.x = STU.i;
                STU.i = SelectRowIndex;
                myStu.id = Convert.ToInt32(SelectedRow.Cells[0].Value);
                IdClass.SelectedIndex = Convert.ToInt32(this.DGV_STU.CurrentRow.Cells[1].Value) - 1;
                if (!(this.DGV_STU.CurrentRow.Cells[2].Value == null))
                    FirstName.Text = SelectedRow.Cells[2].Value.ToString();

                if (!(this.DGV_STU.CurrentRow.Cells[3].Value == null))
                    LastName.Text = SelectedRow.Cells[3].Value.ToString();

                if (!(this.DGV_STU.CurrentRow.Cells[4].Value == null))
                    DadName.Text = SelectedRow.Cells[4].Value.ToString();

                if (!(this.DGV_STU.CurrentRow.Cells[5].Value == null))
                    MomName.Text = SelectedRow.Cells[5].Value.ToString();


                DateBirthday.CustomFormat = "dd/MM/yyyy";
                if (!(this.DGV_STU.CurrentRow.Cells[6].Value == null))
                {
                    string DateBirthday1 = SelectedRow.Cells[6].Value.ToString();
                    DateBirthday.Value = Convert.ToDateTime(DateBirthday1);
                }
                if (!(this.DGV_STU.CurrentRow.Cells[7].Value == null))
                    PlaceBirthday.Text = SelectedRow.Cells[7].Value.ToString();


                DateRegistration.CustomFormat = "yyyy";
                if (!(this.DGV_STU.CurrentRow.Cells[8].Value == null))
                {
                    year = Convert.ToInt32(SelectedRow.Cells[8].Value);
                    DateTime d = new DateTime(year, 1, 1);
                    DateRegistration.Value = d;
                }
                if (!(this.DGV_STU.CurrentRow.Cells[9].Value == null))
                    Sum.Value = Convert.ToDecimal(SelectedRow.Cells[9].Value);

                if (!(this.DGV_STU.CurrentRow.Cells[10].Value == null))
                    Address.Text = SelectedRow.Cells[10].Value.ToString();

                if (!(this.DGV_STU.CurrentRow.Cells[11].Value == null))
                    PhoneNum.Value = Convert.ToDecimal(SelectedRow.Cells[11].Value);

                if (!(this.DGV_STU.CurrentRow.Cells[12].Value == null))
                    NumExam.Value = Convert.ToDecimal(SelectedRow.Cells[12].Value);

                if (!(this.DGV_STU.CurrentRow.Cells[14].Value == null))
                    Notes.Text = SelectedRow.Cells[14].Value.ToString();

                byte[] stu_img =
             (byte[])myStu.selectSTUimg(Convert.ToInt32(this.DGV_STU.CurrentRow.Cells[0].Value)).Rows[0][0];

                MemoryStream ms = new MemoryStream(stu_img);
                if (!(ms == null))
                {
                    STU_Image.SizeMode = PictureBoxSizeMode.Zoom;
                    STU_Image.BackgroundImageLayout = ImageLayout.Zoom;

                    // STU_Image.BackgroundImage.Dispose();
                    STU_Image.BackgroundImage = null;
                    //  STU_Image.Image = null;
                    STU_Image.Invalidate();
                    STU_Image.Image = Image.FromStream(ms);
                    //   STU_Image.Update();
                }
                this.Refresh();
                rename();
                Colorfull();
                myStu.isDoubleClick = false;
            }
        }

        private void زر_التعديل_Click(object sender, EventArgs e)
        {
            try
            {
                myStu.IdClass = ClassDivisionCategory.IdClasses[IdClass.SelectedIndex];
                myStu.NameClass = IdClass.SelectedItem.ToString().Trim();
                LoadSTUInfoMethod();
                myStu.FirstName = FirstName.Text.Trim().ToString();
                myStu.LastName = LastName.Text.Trim().ToString();
                myStu.DadName = DadName.Text.Trim().ToString();
                myStu.MomName = MomName.Text.Trim().ToString();
                myStu.DateBirthday = DateBirthday.Value.ToString();
                myStu.DateBirthday = DateBirthday.Value.ToString();
                myStu.DateRegistration = DateRegistration.Value.Year.ToString();
                myStu.PlaceBirthday = PlaceBirthday.Text;
                myStu.Sum = Sum.Value.ToString();
                myStu.Address = Address.Text;
                myStu.PhoneNum = PhoneNum.Value.ToString();
                myStu.NumExam = NumExam.Value.ToString();
                myStu.Notes = Notes.Text;
                byte[] img = null;
                if (!(STU_Image.Image == null))
                {
                    MemoryStream ms = new MemoryStream();
                    STU_Image.Image.Save(ms, STU_Image.Image.RawFormat);
                    img = ms.ToArray();
                    myStu.img = img;
                }
                LoadSTUInfoMethod();
             
            }
            catch
            {
                MessageBox.Show("]رجى إدخال معلومات صحيحة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (check())
            {
                myStu.UpdateSTU(myStu.FirstName, myStu.LastName, myStu.DadName, myStu.MomName, myStu.DateBirthday, myStu.PlaceBirthday, myStu.DateRegistration, myStu.Sum, myStu.Notes, STU.idStudyYear, myStu.Address, myStu.IdClass, myStu.IsMove, myStu.NameClass, myStu.PhoneNum, myStu.NumExam, myStu.img, myStu.id);
                DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                rename();
                MessageBox.Show("تمت العملية بنجاح", "معلومات عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridDivisionStudent.DataSource = null;
                myHeaderCheckBoxClass1.G = dataGridDivisionStudent;
                myHeaderCheckBoxClass1.AddHeaderCheckBox(myHeaderCheckBoxClass1.G);
                myHeaderCheckBoxClass1.Header.MouseClick += new MouseEventHandler(myHeaderCheckBoxClass1.HeaderCheckBox_MouseClick);
            }
            else
                MessageBox.Show("يرجى إدخال المعلومات الأساسية المطلوبة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void زر_استعراض_صورة_الطالب_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files:|*.jpg;*.gif;*.Bmp;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                STU_Image.Image = null;
                STU_Image.BackgroundImageLayout = ImageLayout.Zoom;
                STU_Image.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void DateBirthday_ValueChanged(object sender, EventArgs e)
        {
            DateBirthday.CustomFormat = "dd/MM/yyyy";
        }

        private void DateRegistration_ValueChanged(object sender, EventArgs e)
        {
            DateRegistration.CustomFormat = "yyyy";
        }

        private void IdClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        
            if (!(IdClass.SelectedIndex == -1))
            {
                myStu.IdClass = ClassDivisionCategory.IdClasses[IdClass.SelectedIndex];
                myStu.NameClass = IdClass.SelectedItem.ToString().Trim();
            }

     

        }

        private void زر_الحذف_Click(object sender, EventArgs e)
        {
            try
            {
                myStu.IdClass = ClassDivisionCategory.IdClasses[IdClass.SelectedIndex];
                myStu.NameClass = IdClass.SelectedItem.ToString().Trim();
                LoadSTUInfoMethod();
                if (STU.MyTable.Rows.Count > 0)
                {
                    myStu.StuInfo = myStu.DeleteStu(myStu.id, STU.idStudyYear, myStu.IdClass);
                    myStu.DeleteStuForSortCategory(myStu.id);
                    myStu.DeleteStuForSortDivision(myStu.id);
                    DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                    rename();
                    ClearTextBoxes();
                    MessageBox.Show("تمت العملية بنجاح", "معلومات عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaddataGridDivisionStudent();
              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void زر_الأخير_Click(object sender, EventArgs e)
        {
            STU.x = STU.i;
            STU.i = STU.MyTable.Rows.Count - 1;
            Colorfull();


            ShowRecord();

        }

        private void زر_التالي_Click(object sender, EventArgs e)
        {
            STU.x = STU.i;


            if (STU.i < STU.MyTable.Rows.Count - 1)
            {
                STU.i++;
                Colorfull();

                ShowRecord();

            }
        }

        private void زر_السابق_Click(object sender, EventArgs e)
        {
            STU.x = STU.i;


            if (STU.i != 0)
            {
                STU.i--;
                Colorfull();

                ShowRecord();

            }
        }

        private void IsMove_CheckedChanged(object sender, EventArgs e)
        {
            if (IsMove.Checked)
                myStu.IsMove = 1;
            else
                myStu.IsMove = 0;
        }


        //سيأخذ لائحة بطلاب الصف المختارين و يضيفهم لشعبة ما 

        private void زر_إضافة_الطلاب_لشعبة_Click(object sender, EventArgs e)
        {
            //لائحة تحوي أرقام الطلاب المختارين لإضافتهم لشعبة ما 
            MyClassDivisionCategory.StudentClassDivisionID = HeaderCheckBox.GetNum(dataGridDivisionStudent);
            if (DivisionDivision.SelectedItem == null)
                MessageBox.Show("يجب اختيار شعبة لوضع الطلاب فيها", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (MyClassDivisionCategory.StudentClassDivisionID == null)
                MessageBox.Show("يجب اختيار طلاب لوضعهم في شعبة   ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                try
                {
                    //عملية إضافة طالب لشعبة : تتم بإضافة طالب طالب , يجب التعديل مستقبلاً لنضيف بكبسة زر واحدة  طلاب الشعبة الواحدة أو الفئة الواحدة
                      // for (int i = 0; i < MyClassDivisionCategory.StudentClassDivisionID.Count; i++)
                    // ClassDivisionCategory.SotrDivisionInfo = MyClassDivisionCategory.InsertSortDivision(MyClassDivisionCategory.StudentClassDivisionID[i], MyClassDivisionCategory.StudentDivision, ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.DivisionDivisionID);
                      ClassDivisionCategory.SotrDivisionInfo = MyClassDivisionCategory.InsertSortDivisionInOneClick (MyClassDivisionCategory );

                    NumTotalDivision.Text = ClassDivisionCategory.SotrDivisionInfo[2].ToString();
                    NumDivisionClass.Text = ClassDivisionCategory.SotrDivisionInfo[1].ToString();
                    NumStuInDivision.Text = ClassDivisionCategory.SotrDivisionInfo[0].ToString();

                    dataGridSortDivision.DataSource = MyClassDivisionCategory.ShowSortDivision(ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentDivision, MyClassDivisionCategory.DivisionDivisionID);
                    MyClassDivisionCategory.StudentClassDivisionID.Clear();
                    MyClassDivisionCategory.StudentSortDivisionID.Clear();
                    LoaddataGridSortDivision();
                    واجهة_إدارة_اللطلاب.deleg.dataGridDivisionStudent.DataSource = null;

                    LoaddataGridDivisionStudent();
                    ShowSortDivisionMess();
                    MessageBox.Show("تم إضافة الطلاب للشعبة بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   // return;
                }
            }
        }
        private void StudentDivision_SelectedIndexChanged(object sender, EventArgs e)
        {

            int IdClass = StudentDivision.SelectedIndex;
            MyClassDivisionCategory.StudentDivision = ClassDivisionCategory.IdClasses[IdClass];
            if (ClassDivisionCategory.IsLoadClassForDivision)
            {
                LoaddataGridDivisionStudent();
            }
            if ((ClassDivisionCategory.IsLoadDivisionForDivision) && (ClassDivisionCategory.IsLoadDivisionForCategory))
            {
                LoaddataGridDivisionStudent();
                LoadDivisionSortInfoMethod();
            }
        }



        private void زر_حذف_طلاب_من_شعبة_Click(object sender, EventArgs e)
        {
            try
            {

                //int IdClass = StudentDivision.SelectedIndex;
                //MyClassDivisionCategory.StudentDivision = ClassDivisionCategory.IdClasses[IdClass];
                MyClassDivisionCategory.StudentSortDivisionID = HeaderCheckBox.GetNum(dataGridSortDivision);
                if (MyClassDivisionCategory.StudentSortDivisionID == null)
                    MessageBox.Show("يجب اختيار طلاب لحذهم من الشعبة   ", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                  //  for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)                  
                     //   MyClassDivisionCategory.DeleteSortCategoryForDeleteDivision(MyClassDivisionCategory.StudentSortDivisionID[i], ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentDivision, MyClassDivisionCategory.DivisionDivisionID);
                    MyClassDivisionCategory.DeleteSortCategoryForDeleteDivisionInOneClick(MyClassDivisionCategory);
                 //   for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)
                 // ClassDivisionCategory.SotrDivisionInfo = MyClassDivisionCategory.DeleteSortDivision(MyClassDivisionCategory.StudentSortDivisionID[i], ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentDivision, MyClassDivisionCategory.DivisionDivisionID);
                    ClassDivisionCategory.SotrDivisionInfo = MyClassDivisionCategory.DeleteSortDivisionInOneClick(MyClassDivisionCategory);

                    NumTotalDivision.Text = ClassDivisionCategory.SotrDivisionInfo[2].ToString();
                    NumDivisionClass.Text = ClassDivisionCategory.SotrDivisionInfo[1].ToString();
                    NumStuInDivision.Text = ClassDivisionCategory.SotrDivisionInfo[0].ToString();
                    MyClassDivisionCategory.StudentSortDivisionID.Clear();

                    LoaddataGridSortDivision();
                    واجهة_إدارة_اللطلاب.deleg.dataGridDivisionStudent.DataSource = null;

                    LoaddataGridDivisionStudent();
                    ShowSortDivisionMess();
                    MessageBox.Show("تمت عملية حذف الطلاب من الشعبة بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
               // MessageBox.Show("فشلت عملية حذف الطلاب من الشعبة ", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void زر_واجهة_الشعب_Click(object sender, EventArgs e)
        {

            if (Division.IsClosing == true)
            {
                division = new واجهة_إدارة_الشعب();
                division.Show();
            }
            else
            {
                division.Show();
            }
        }

        private void DivisionDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ClassDivisionCategory.IsLoadDivisionForDivision) && (ClassDivisionCategory.IsLoadClassForDivision))
            {
                int IdDivision = DivisionDivision.SelectedIndex;
                MyClassDivisionCategory.DivisionDivisionID = ClassDivisionCategory.IdDivisiones[IdDivision];
                LoaddataGridSortDivision();
                LoadDivisionSortInfoMethod();
            }
        }
        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void واجهة_إدارة_اللطلاب_FormClosing(object sender, FormClosingEventArgs e)
        {
            STU.IsClosing = true;
        }

        private void زر_واجهة_الفئات_Click(object sender, EventArgs e)
        {

            if (Category.IsClosing == true)
            {
                category = new واجهة_إدارة_الفئات();
                category.Show();
            }
            else
            {
                category.Show();
            }
        }

        private void زر_إضافة_الطلاب_لفئة_Click(object sender, EventArgs e)
        {
            MyClassDivisionCategory.StudentClassCategoryID = HeaderCheckBox.GetNum(dataGridStudentCategory);
            if (MyClassDivisionCategory.StudentClassCategoryID.Count == 0)
                MessageBox.Show("يجب اختيار طلاب لإضافتهم لفئة ما", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try {
                    //  for (int i = 0; i < MyClassDivisionCategory.StudentClassCategoryID.Count; i++)
                    //  MyClassDivisionCategory.InsertSortCategory(MyClassDivisionCategory.StudentClassCategoryID[i], MyClassDivisionCategory.StudentCategoryID, ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.DivisionCategoryID, MyClassDivisionCategory.CategoryCategoryID);
                    MyClassDivisionCategory.InsertSortCategoryInOneClick(MyClassDivisionCategory);
                    loaddataGridSortCategory();
                    loaddataGridCategoryStudent();
                    MyClassDivisionCategory.StudentClassCategoryID.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            MyClassDivisionCategory.StudentSortDivisionID = HeaderCheckBox.GetNum(dataGridSortCategory);
            if (MyClassDivisionCategory.StudentClassCategoryID.Count == 0)
                MessageBox.Show("يجب اختيار طلاب لحذفهم من الفئة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)             
                 //   MyClassDivisionCategory.DeleteSortCategory(MyClassDivisionCategory.StudentSortDivisionID[i], ClassDivisionCategory.idStudyYear, MyClassDivisionCategory.StudentCategoryID, MyClassDivisionCategory.DivisionCategoryID, MyClassDivisionCategory.CategoryCategoryID);
                MyClassDivisionCategory.DeleteSortCategoryInOneClick(MyClassDivisionCategory);
                واجهة_إدارة_اللطلاب.deleg.dataGridSortCategory.DataSource = null;
                loaddataGridSortCategory();
                واجهة_إدارة_اللطلاب.deleg.dataGridStudentCategory.DataSource = null;
                loaddataGridCategoryStudent();
                MyClassDivisionCategory.StudentClassCategoryID.Clear();
            }
        }
        private void StudentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassDivisionCategory.IsLoadDivisionForCategory && ClassDivisionCategory.IsLoadClassForCategory)
            {
                int IdClass = StudentCategory.SelectedIndex;
                MyClassDivisionCategory.StudentCategoryID = ClassDivisionCategory.IdClasses[IdClass];
                loaddataGridCategoryStudent();
            }
        }
        private void DivisionCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ClassDivisionCategory.IsLoadDivisionForCategory && ClassDivisionCategory.IsLoadClassForCategory)
            {
                int IdDivision = DivisionCategory.SelectedIndex;
                MyClassDivisionCategory.DivisionCategoryID = ClassDivisionCategory.IdDivisiones[IdDivision];
                loaddataGridCategoryStudent();
            }
        }
        private void CategoryCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdCategory = CategoryCategory.SelectedIndex;
            MyClassDivisionCategory.CategoryCategoryID = ClassDivisionCategory.IdCategories[IdCategory];
            dataGridSortDivision.DataSource = null;
            MyClassDivisionCategory.StudentClassCategoryID = HeaderCheckBox.GetNum(dataGridDivisionStudent);
            loaddataGridSortCategory();
        }

        private void STU_Image_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label40_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }
        private void زر_واجهة_إدارة_الاختبارات_Click(object sender, EventArgs e)
        {
            if (Exam.IsClosing == true)
            {
                exam = new واجهة_إدارة_الاختبارات();
                exam.Show();
            }
            else
            {
                exam.Show();
            }
        }

        private void IdExam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void TableLayoutPanel53_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void TableLayoutPanel54_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void Label43_Click(object sender, EventArgs e)
        {

        }
     
        #region
        private void ClassMessID_SelectedIndexChanged(object sender, EventArgs e)
        {
            myMessStu.IdClass = ClassDivisionCategory.IdClasses[classMessID.SelectedIndex];
            ClassDivisionCategory.ShowCustomSelectDivisionForThisClass(divisionMessID, Division.idStudyYear, myMessStu.IdClass);
            if (!(divisionMessID.Items.Count == 0))
            {
                divisionMessID.SelectedIndex = 0;
                myMessStu.idDivision = ClassDivisionCategory.IdDivisiones[0];
            }
            ShowSortDivisionMess();
        }

        private void DivisionMessID_SelectedIndexChanged(object sender, EventArgs e)
        {
            myMessStu.idDivision = ClassDivisionCategory.IdDivisiones[divisionMessID.SelectedIndex];        
            ShowSortDivisionMess();
        }

        private void SeasonID_SelectedIndexChanged(object sender, EventArgs e)
        {
            myMessStu.idSeason = ClassDivisionCategory.IdSeasons[seasonMessID.SelectedIndex];
        }
        private void IdDateDay_ValueChanged(object sender, EventArgs e)
        {
            myMessStu.DateDay = DateDayMess.Value.ToString();
        }
        private void زر_حفظ_الحضور_Click(object sender, EventArgs e)
        {
            //للتحقق هل هذه الشعبة موجودة بجدول الغياب كي نحدد سنجري لإضافة أم تعديل
           // DataTable MessStuCheck = adMessStu.GetDataByCheckShowSortDivision(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);

            //لدينا سجلات و بالتالي سنعدّل
            try
            {
                if (MessStuCheck.Rows.Count > 0)
                {

                    foreach (DataGridViewRow row in idStuMess_DGV.Rows)
                    {

                        myMessStu.idStu = Convert.ToInt32(row.Cells[1].Value);
                        myMessStu.Mess = row.Cells[2].Value.ToString();
                        adMessStu.UpdateQuery(myMessStu.idSeason, myMessStu.Mess, myMessStu.DateDay, myMessStu.idStu);

                    }
                   
                    MessageBox.Show("تمت عملية تعديل التفقد بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                //سننشأهم
                else
                {
                    //سنضيف سجل جديد
                    foreach (DataGridViewRow row in MessStu.Rows)
                    {
                        myMessStu.idStu = Convert.ToInt32(row.Cells[1].Value);
                        myMessStu.Mess = row.Cells[2].Value.ToString();
                        adMessStu.InsertQuery(myMessStu.idStu, myMessStu.idSeason, STU.idStudyYear, myMessStu.DateDay, myMessStu.Mess);
                        MessStu = adMessStu.GetDataShowMess(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                      
                    }
                    
                    MessageBox.Show("تمت عملية إضافة التفقد بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.idStuMess_DGV.DataSource = MessStu;
                rename_idStuMess_DGV();
            }
            catch
            {
                MessageBox.Show("لم تتم عملية تسجيل الحضور بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void زر_مسح_الحضور_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in MessStu.Rows)
            {
                myMessStu.idStu = (int)row[1];
                adMessStu.InsertQuery(myMessStu.idStu, myMessStu.idSeason, STU.idStudyYear, myMessStu.DateDay, "");
                MessStu = adMessStu.GetDataShowMess(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                واجهة_إدارة_اللطلاب.deleg.idStuMess_DGV.DataSource = MessStu;
                rename_idStuMess_DGV();
            }
        }

        #endregion

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void زر_إضافة_العلامات_Click(object sender, EventArgs e)
        {
            //للتحقق هل هذه الشعبة أو الفئة موجودة بجدول العلامات  كي نحدد سنجري لإضافة أم تعديل
            try
            {
                if (TypeSubject == "نظري")
                {
                    //التمرين غير موجود و بالتالي سنضيفه لجدول العلامات
                    DataTable MarkStuSortDivision = adSortDivision.GetDataByShowSortDivision(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId);
                    //التمرين موجود و بالتالي سنعدّل و سنجلبه من جدول العلامات
                    DataTable MarkStuCheckSortDivision = adSortDivision.GetDataByShowCheckSortDivision(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId,myStuMark.idExam);
                    //لدينا سجلات و بالتالي سنعدّل     
                    if (MarkStuCheckSortDivision.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in idStu_DGV.Rows)
                        {
                            txt_path.Text = row.Cells[3].Value.ToString();
                            myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                            myStuMark.mark = Convert.ToSingle(row.Cells[2].Value);
                            adSortDivision.UpdateQuery(myStuMark.SubjectId, myStuMark.idExam, myStuMark.idSeason, STU.idStudyYear, myStuMark.idHall, myStuMark.BeginExam.ToString(), myStuMark.EndExam.ToString(), myStuMark.mark.ToString(), myStuMark.FileType, myStuMark.FileName, myStuMark.FileAttachement, myStuMark.idStu);

                        }
                        MessageBox.Show("تمت عملية التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //سننشأهم
                    else
                    {
                        //سنضيف سجل جديد
                        foreach (DataGridViewRow row in idStu_DGV.Rows)
                        {
                            myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                            myStuMark.mark = Convert.ToSingle(row.Cells[2].Value);
                            adSortDivision.InsertQuery(myStuMark.idStu, myStuMark.SubjectId, myStuMark.idExam, myStuMark.idSeason, STU.idStudyYear, myStuMark.BeginExam.ToString(), myStuMark.EndExam.ToString(), myStuMark.idHall, myStuMark.mark.ToString(), myStuMark.FileType, myStuMark.FileName, myStuMark.FileAttachement,myStuMark.IdClass,myStuMark.DivisionId);

                        }
                        MessageBox.Show("تمت عملية الإضافة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                    idStu_DGV.DataSource = null;
                    DataTable StuSortCategory = asSortCategory.GetDataByShowSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId);
                    idStu_DGV.DataSource = StuSortCategory;
                }
                //مادة عملية
                else
                {
                    DataTable MarkStuSortCategory = asSortCategory.GetDataByShowSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId);
                    DataTable MarkStuCheckSortCategory = asSortCategory.GetDataByShowCheckSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId, myStuMark.idExam);

                    //لدينا سجلات و بالتالي سنعدّل
                   
                    if (MarkStuCheckSortCategory.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow row in idStu_DGV.Rows)
                        {
                            txt_path.Text = row.Cells[3].Value.ToString();
                            myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                            myStuMark.mark = Convert.ToSingle(row.Cells[2].Value);
                            asSortCategory.UpdateQuery(myStuMark.SubjectId, myStuMark.idExam, myStuMark.idSeason, STU.idStudyYear, myStuMark.idHall, myStuMark.BeginExam.ToString(), myStuMark.EndExam.ToString(), myStuMark.mark.ToString(), myStuMark.FileType, myStuMark.FileName, myStuMark.FileAttachement, myStuMark.idStu);

                        }
                        MessageBox.Show("تمت عملية التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //سننشأهم
                    else
                    {
                        //سنضيف سجل جديد
                        foreach (DataGridViewRow row in idStu_DGV.Rows)
                        {
                            myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                            myStuMark.mark = Convert.ToSingle(row.Cells[2].Value);
                            myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                            asSortCategory.InsertQuery(myStuMark.idStu, myStuMark.SubjectId, myStuMark.idExam, myStuMark.idSeason, STU.idStudyYear, myStuMark.BeginExam.ToString(), myStuMark.EndExam.ToString(), myStuMark.idHall, myStuMark.mark.ToString(), myStuMark.FileType, myStuMark.FileName, myStuMark.FileAttachement,myStuMark.IdClass,myStuMark.DivisionId,myStuMark.CategoryId);

                        }
                        MessageBox.Show("تمت عملية الإضافة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    idStu_DGV.DataSource = null;
                    DataTable StuSortCategory = asSortCategory.GetDataByShowSortCategory(STU.idStudyYear, myStuMark.IdClass, myStuMark.DivisionId, myStuMark.CategoryId);
                    idStu_DGV.DataSource = StuSortCategory;
                }
                rename_idStu_DGV();
              
            }
            catch
            {
               // return;
            }
        }
        private void زر_حذف_كل_العلامات_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in idStu_DGV.Rows)
            {
                myStuMark.idStu = Convert.ToInt32(row.Cells[0].Value);
                adSortDivision.UpdateQuery(myStuMark.SubjectId, myStuMark.idExam, myStuMark.idSeason, STU.idStudyYear, myStuMark.idHall, myStuMark.BeginExam.ToString(), myStuMark.EndExam.ToString(), myStuMark.mark.ToString(), myStuMark.FileType, myStuMark.FileName, myStuMark.FileAttachement, myStuMark.idStu);

            }
        }
      
        private void زر_ملف_الأسئلة_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"c:\";
            openFileDialog2.Filter = "PDF file|*.pdf|*.Excel|*.xls;*.xlsx|txt(*.txt)|*.txt|All Files|*.*";
            openFileDialog2.Title = "اختر نوع الملف";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = openFileDialog2.FileName;

                if (!(txt_path.Text == string.Empty))
                {
                    string FilePath = txt_path.Text;
                    //اسم الملف
                    string FileName = Path.GetFileName(FilePath);
                    //اسم اللاحقة
                    string FileType = Path.GetExtension(FilePath);
                    //قراءة الملف و تخزينه ضمن قاععدة البيانات
                    byte[] file = System.IO.File.ReadAllBytes(FilePath);

                    myStuMark.FileName = FileName;
                    myStuMark.FileType = FileType;
                    myStuMark.FileAttachement = file;
                }

                else
                {
                    myStuMark.FileName = null;
                    myStuMark.FileType = null;
                    myStuMark.FileAttachement = null;
                }
            }
        }
        //لعرض ملف الأسئلة
        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ToolStripItem showQuestions = contextMenuStrip1.Items[0];

            if (e.ClickedItem == showQuestions)
            {
                try
                {
                    int r = Convert.ToInt32(this.idStu_DGV.CurrentRow.Cells[0].Value);
            
                    if (!(idStu_DGV.CurrentRow.Cells["FileQuestionName"].Value == DBNull.Value))
                    {
                        string FileName = idStu_DGV.CurrentRow.Cells["FileQuestionName"].Value.ToString();
                        //محتوى الملف
                        byte[] FileContent = (byte[])idStu_DGV.CurrentRow.Cells["FileAttachement"].Value;
                        FileContent = FileContent.ToArray();
                        //قراءة محتوى الملف
                        System.IO.File.WriteAllBytes(FileName, FileContent);
                        //إظهار الملف
                        System.Diagnostics.Process.Start(FileName);
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد ملف أسئلة لعرضه", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //عندما نكون قد فتحنا ملف و عند محاولة فتحه للمرة الثانية
                catch
                {
                    MessageBox.Show("قد تم فتح الملف للمرة الأولى", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void IdClassShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(IdClassShow.SelectedIndex == -1))
            {
                DGV_STU.DataSource = myStu.SelectStu(ClassDivisionCategory.IdClasses[IdClassShow.SelectedIndex], STU.idStudyYear);
                rename();
                LoadSTUInfoMethod();
            
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                this.DGV_STU.DataSource = myStu.SelectStu(myStu.IdClass, STU.idStudyYear);
                rename();
            }
            else
            {
                this.DGV_STU.DataSource = myStu.SearchStu(STU.idStudyYear, textBox1.Text);
                rename();
            }
        }

        private void IdStu_DGV_DoubleClick(object sender, EventArgs e)
        {
      
        }

        public static Boolean findTabPage1 = true;
        public static Boolean findTabPage2 = true;
        public static Boolean findTabPage3 = true;
        public static Boolean findTabPage4 = true;
        public static Boolean findTabPage5 = true;
        private void IdStu_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int findTabPage { get; set; }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if( (tabControl1.SelectedTab == تبويب_إدارة_الطلاب)&&(findTabPage1))
            {
                findTabPage = 1;
                findTabPage1 = false;
                SelectTab();
            }

            if( (tabControl1.SelectedTab == تبويب_فرز_الشعب)&&(findTabPage2))
            {
                findTabPage = 2;
                findTabPage2 = false;
                SelectTab();
            }

            if ((tabControl1.SelectedTab == تبويب_فرز_الفئات)&&(findTabPage3))
            {
                findTabPage = 3;
                findTabPage3 = false;
                SelectTab();
            }

            if ((tabControl1.SelectedTab == تبويب_حضور_الطلاب)&&(findTabPage4))
            {
                findTabPage = 4;
                findTabPage4 = false;
                SelectTab();
            }

            if ((tabControl1.SelectedTab == تبويب_العلامات)&&(findTabPage5))
            {
                findTabPage = 5;
                findTabPage5 = false;
                SelectTab();
            }

            //and for displaying data:
           
        }

    }
}