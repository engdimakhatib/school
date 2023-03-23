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
    public partial class واجهة_العام_الدراسي_و_العطل : Form
    {
        private static واجهة_العام_الدراسي_و_العطل n;
        public static واجهة_إضافة_عطل holiday=new واجهة_إضافة_عطل();
        StudyYear year = new StudyYear();
        public واجهة_العام_الدراسي_و_العطل()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }

  
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_العام_الدراسي_و_العطل deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_العام_الدراسي_و_العطل();
                }
                return n;
            }

        }
        public void ClearTextBoxes()
        {
            BeginStudyYear.CustomFormat = " ";
            EndStudyYear.CustomFormat = " ";
            AcceptStu.CustomFormat = " ";
            BeginTerm1.CustomFormat = " ";
            ExamTerm1.CustomFormat = " ";
            TheRecess.CustomFormat = " ";
            BeginSecondTerm.CustomFormat = " ";
            paracticalExam.CustomFormat = " ";
       
            BeginSecondExam.CustomFormat = " ";
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            numericUpDown3.Text = "";

            textBox4.Text = "";
        }
        public void rename()
        {
             {
                DGV_StudyYear.Columns[1].HeaderText = "بداية العام الدراسي";
                DGV_StudyYear.Columns[2].HeaderText = "نهاية العام الدراسي";
                DGV_StudyYear.Columns[3].HeaderText = "تاريخ قبول و تسجيل الطلاب";
                DGV_StudyYear.Columns[4].HeaderText = "تاريخ بداية الفصل الأول";
                DGV_StudyYear.Columns[5].HeaderText = "تاريخ امتحان الفصل الأول";
                DGV_StudyYear.Columns[6].HeaderText = "تاريخ بداية العطلة الانتصافية";
                DGV_StudyYear.Columns[7].HeaderText = "تاريخ بداية الفصل الثاني";
                DGV_StudyYear.Columns[8].HeaderText = "تاريخ امتحان الفصل الثاني";
                DGV_StudyYear.Columns[9].HeaderText = "تاريخ امتحان الفحص العملي";
                DGV_StudyYear.Columns[10].HeaderText = "عدد أيام الفصل الأول";
                DGV_StudyYear.Columns[11].HeaderText = "عدد أيام الفصل الثاني";
                DGV_StudyYear.Columns[12].HeaderText = "عدد أسابيع الدوام الفعلي";
                DGV_StudyYear.Columns[13].HeaderText = "عدد أيام الدوام الكلية";
                DGV_StudyYear.Columns[14].HeaderText = "ملاحظات";
                //   DGV_StudyYear.Columns[16].HeaderText = "اسم العطلة";
                //  DGV_StudyYear.Columns[17].HeaderText = "تاريخ العطلة";
                // DGV_StudyYear.Columns[18].HeaderText = "مدة العطلة";
                //idStudyYear
                DGV_StudyYear.Columns[0].Visible = false;
                //Holiday.id 
             //   DGV_StudyYear.Columns[15].Visible = false;

            } }
        public Boolean check() {
            Boolean check = true;
            if ((BeginStudyYear.Text == "") || (EndStudyYear.Text == "") || (AcceptStu.Text =="") || (BeginTerm1.Text == "") || (ExamTerm1.Text == "") || (TheRecess.Text == "") || (BeginSecondTerm.Text == "") || (BeginSecondExam.Text == "") || (paracticalExam.Text == "") || (numericUpDown1.Value == 0) || (numericUpDown2.Value == 0) || (numericUpDown3.Value == 0))
                check = false;
            return check;
        }
        //زر إضافة العام الدراسي
        private void Button1_Click(object sender, EventArgs e)
        {
            BeginStudyYear.CustomFormat = "yyyy";
            EndStudyYear.CustomFormat = "yyyy";
            DGV_StudyYear.DataSource = null;
            StudyYear.YearID = year.SelectStudyYearID(BeginStudyYear.Value.Year.ToString());
            if (!(StudyYear.YearID == -1))
            {
                MessageBox.Show("هذه السنة موجودة فعلا");
                year.NotFound = true;
            }
            else
            {
                if (check())
                {
                    StudyYear.YearID = year.InsertandGetStudyYearIdName(BeginStudyYear.Value.Year.ToString(), EndStudyYear.Value.Year.ToString(), AcceptStu.Value.ToString(), BeginTerm1.Value.ToString(), ExamTerm1.Value.ToString(), TheRecess.Value.ToString(), BeginSecondTerm.Value.ToString(), BeginSecondTerm.Value.ToString(), paracticalExam.Value.ToString(), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown1.Value)+Convert.ToInt32(numericUpDown2.Value), textBox4.Text, year.IsLoadYear);
                   
                    year.NotFound = true;
                    MessageBox.Show("تمت الإضافة بنجاح","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
            rename();

        }

        private void زر_حذف_عام_دراسي_Click(object sender, EventArgs e)
        {
            year.DeleteHolidayStudyYear(StudyYear.YearID);
            year.DeleteStudyYear(StudyYear.YearID);
            DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
            rename();
        }

        private void زر_تعديل_عام_دراسي_Click(object sender, EventArgs e)
        {
            if (check())
            {
                year.UpdateStudyYear(StudyYear.YearID, BeginStudyYear.Value.Year.ToString(), EndStudyYear.Value.Year.ToString(), AcceptStu.Value.ToString(), BeginTerm1.Value.ToString(), ExamTerm1.Value.ToString(), TheRecess.Value.ToString(), BeginSecondTerm.Value.ToString(), BeginSecondTerm.Value.ToString(), paracticalExam.Value.ToString(), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), textBox4.Text);
                DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
                rename();
                MessageBox.Show("تم التعديل بنجاح","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
        }
        private void DGV_StudyYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_StudyYear_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_StudyYear.SelectedCells.Count > 0)
            {
                ClearTextBoxes();
                int SelectRowIndex = DGV_StudyYear.SelectedCells[0].RowIndex;  
                DataGridViewRow SelectedRow = DGV_StudyYear.Rows[SelectRowIndex];
                StudyYear.YearID = Convert.ToInt32(SelectedRow.Cells[0].Value);
              
                int BeginStudyYear1 = Convert.ToInt32(SelectedRow.Cells[1].Value);
                DateTime d1 = new DateTime(BeginStudyYear1, 1, 1);
                BeginStudyYear.CustomFormat = "yyyy";
                BeginStudyYear.Value = d1;

                int EndStudyYear1 = Convert.ToInt32(SelectedRow.Cells[2].Value.ToString());
                DateTime d2 = new DateTime(EndStudyYear1, 1, 1);
                EndStudyYear.CustomFormat = "yyyy";
                EndStudyYear.Value = d2;

                string AcceptStu1 = SelectedRow.Cells[3].Value.ToString();
                AcceptStu.CustomFormat = "dd/MM/yyyy";
                AcceptStu.Value = (Convert.ToDateTime(AcceptStu1));


                string ExamTerm11 = SelectedRow.Cells[5].Value.ToString();
                ExamTerm1.CustomFormat = "dd/MM/yyyy";
                ExamTerm1.Value = (Convert.ToDateTime(ExamTerm11));

                string TheRecess1 = SelectedRow.Cells[6].Value.ToString();
                TheRecess.CustomFormat = "dd/MM/yyyy";
                TheRecess.Value = (Convert.ToDateTime(TheRecess1));

                string BeginSecondTerm1 = SelectedRow.Cells[7].Value.ToString();
                BeginSecondTerm.CustomFormat = "dd/MM/yyyy";
                BeginSecondTerm.Value = (Convert.ToDateTime(BeginSecondTerm1));

                string BeginSecondExam1 = SelectedRow.Cells[8].Value.ToString();
                BeginSecondExam.Value = (Convert.ToDateTime(BeginSecondExam1));

                string paracticalExam1 = SelectedRow.Cells[9].Value.ToString();
                paracticalExam.CustomFormat = "dd/MM/yyyy";
                paracticalExam.Value = (Convert.ToDateTime(paracticalExam1));

                numericUpDown1.Text = SelectedRow.Cells[10].Value.ToString();
                numericUpDown2.Text = SelectedRow.Cells[11].Value.ToString();
                numericUpDown3.Text = SelectedRow.Cells[12].Value.ToString();
                textBox4.Text = SelectedRow.Cells[14].Value.ToString();

                string BeginTerm11 = SelectedRow.Cells[4].Value.ToString();
                BeginTerm1.CustomFormat = "  dd/MM/yyyy";
                BeginTerm1.Value = (Convert.ToDateTime(BeginTerm11));
            }
        }

        private void واجهة_العام_الدراسي_و_العطل_Load(object sender, EventArgs e)
        {
            
           DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
                rename();
                ClearTextBoxes();
            
        
       }

        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ParacticalExam_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void DGV_StudyYear_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void زر_واجهة_العطل_Click(object sender, EventArgs e)
        {
            if (StudyYear.IsClosingHoliday == true )
            {
                holiday  = new واجهة_إضافة_عطل();
                holiday.Show();
            }
            else
            {
                holiday.Show();
            }
        }

        private void واجهة_العام_الدراسي_و_العطل_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudyYear.IsClosingYear = true;

        }

        private void BeginStudyYear_ValueChanged(object sender, EventArgs e)
        {
            BeginStudyYear.CustomFormat = "yyyy";
            StudyYear.BeginStudyYear = BeginStudyYear.Value.Year.ToString();
            EndStudyYear.CustomFormat = "yyyy";
            int endstudyyear = Convert.ToInt32(StudyYear.BeginStudyYear) + 1;
            EndStudyYear.Value = new DateTime(endstudyyear,1,1);
            StudyYear.EndStudyYear = endstudyyear.ToString();
        }

        private void EndStudyYear_ValueChanged(object sender, EventArgs e)
        {
            
         //   Convert.ToInt32(year.BeginStudyYear) + 1
        //    EndStudyYear.Value ="";
        }

        private void AcceptStu_ValueChanged(object sender, EventArgs e)
        {
            AcceptStu.CustomFormat = "dd/MM/yyyy";
        }

        private void BeginTerm1_ValueChanged(object sender, EventArgs e)
        {
            BeginTerm1.CustomFormat = "dd/MM/yyyy";
        }

        private void ExamTerm1_ValueChanged(object sender, EventArgs e)
        {
            ExamTerm1.CustomFormat = "dd/MM/yyyy";
        }

        private void TheRecess_ValueChanged(object sender, EventArgs e)
        {
            TheRecess.CustomFormat = "dd/MM/yyyy";
        }

        private void BeginSecondTerm_ValueChanged(object sender, EventArgs e)
        {
            BeginSecondTerm.CustomFormat = "dd/MM/yyyy";
        }

        private void BeginSecondExam_ValueChanged(object sender, EventArgs e)
        {
            BeginSecondExam.CustomFormat = "dd/MM/yyyy";
        }

        private void ParacticalExam_ValueChanged_1(object sender, EventArgs e)
        {
            paracticalExam.CustomFormat = "dd/MM/yyyy";
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //numericUpDown3.Value += numericUpDown2.Value;
            numActuallWeek =Math.Round((numActuallWeek+Convert.ToInt32( numericUpDown2.Value))/7);
            numericUpDown3.Value = Convert.ToInt32(numActuallWeek);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // numericUpDown3.Value += numericUpDown1.Value;
            numActuallWeek = Math.Round((numActuallWeek + Convert.ToInt32(numericUpDown1.Value)) / 7);
            numericUpDown3.Value= Convert.ToInt32(numActuallWeek);
        }
        public double numActuallWeek;
        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
