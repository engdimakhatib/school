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
    public partial class واجهة_إضافة_عطل : Form
    {
        public واجهة_إضافة_عطل()
        {
            InitializeComponent();
        }
        StudyYear year = new StudyYear();
        private void DGV_Holiday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void rename()
        {
        
             
                DGV_Holiday.Columns[2].HeaderText = "اسم العطلة";
                DGV_Holiday.Columns[3].HeaderText = "مدة العطلة";
                DGV_Holiday.Columns[4].HeaderText = "تاريخ العطلة";
                //id
                DGV_Holiday.Columns[0].Visible = false;
             
                //idStudyYear
                DGV_Holiday.Columns[1].Visible = false;
      

        }
        int BeginStudyYear =Convert.ToInt32( StudyYear.BeginStudyYear);
        int EndStudyYear= Convert.ToInt32(StudyYear.EndStudyYear );

        public void ClearTextBox()
        {
            NameHoliday.Text = "";
            DateHoliday.CustomFormat = "";
            Duration.Text = "";
        }
        public Boolean check() {
            Boolean check = true;
            if ((NameHoliday.Text == "") || (DateHoliday.Text == "") || (Duration.Value == 0))
                check = false;
            return check;
        }
        private void زر_حذف_العطل_الرسمية_Click(object sender, EventArgs e)
        {
          year.DeleteHoliday(year.idHoliday);
          
            واجهة_العام_الدراسي_و_العطل.deleg.DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
            واجهة_العام_الدراسي_و_العطل.deleg.rename();
            DGV_Holiday.DataSource = year.SelectHoliday(StudyYear.YearID);
            rename();
            MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void زر_إضافة_العطل_الرسمية_Click(object sender, EventArgs e)
        {
           
                if (check())
                {
                    year.InsertHoliday(NameHoliday.Text, StudyYear.YearID, Duration.Value.ToString(), DateHoliday.Value.ToString());
                  
                    واجهة_العام_الدراسي_و_العطل.deleg.DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
                واجهة_العام_الدراسي_و_العطل.deleg.rename();
                DGV_Holiday.DataSource = year.SelectHoliday(StudyYear.YearID);
                rename();
                MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
           


        }
        private void واجهة_إضافة_عطل_Load(object sender, EventArgs e)
        {

    //int yearID=   year.SelectStudyYearID(StudyYear.BeginStudyYear );

            DGV_Holiday.DataSource = year.SelectHoliday(StudyYear.YearID);
                rename();
            if ((StudyYear.YearID ==-1))
            {
                MessageBox.Show("يجب إدخال العام الدراسي أولاً و تحديد كل تاريخ مطلوب", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        private void DGV_Holiday_DoubleClick(object sender, EventArgs e)
        {
            ClearTextBox();
        if (DGV_Holiday.SelectedCells.Count > 0)
           {
                int SelectRowIndex = DGV_Holiday.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_Holiday.Rows[SelectRowIndex];
                year.idHoliday = Convert.ToInt32(SelectedRow.Cells[0].Value);

                if (!(SelectedRow.Cells[2].Value.ToString() == ""))
                    NameHoliday.Text = SelectedRow.Cells[2].Value.ToString();
                if (!(SelectedRow.Cells[3].Value.ToString() == ""))
                    Duration.Text = SelectedRow.Cells[3].Value.ToString();

                if (!(SelectedRow.Cells[4].Value.ToString() == ""))
                {
                    string DateHoliday1 = SelectedRow.Cells[4].Value.ToString();
                    DateHoliday.CustomFormat = "dd/MM/yyyy";

                    DateHoliday.Value = (Convert.ToDateTime(DateHoliday1));
                }
           


            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void واجهة_إضافة_عطل_FormClosing(object sender, FormClosingEventArgs e)
        {
            StudyYear.IsClosingHoliday = true;
        }

        private void CheckBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                NameHoliday.Text = "رأس السنة الهجرية";
                Duration.Value = 1;
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value  = 0;
            }
        }

        private void CheckBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                NameHoliday.Text = "رأس السنة الميلادية";
                Duration.Value = 1;
          
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32( StudyYear.EndStudyYear), 1, 1);
            }
            else
            {
                DateHoliday.CustomFormat = " ";
                NameHoliday.Text = "";
                Duration.Value = 0;
            }
        }

        private void CheckBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                NameHoliday.Text = "عيد المولد الشريف";
                Duration.Value = 1;
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.BeginStudyYear), 1, 1);
            }
            else
            {
                NameHoliday.Text = "";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                NameHoliday.Text = "عيد الميلاد المجيد";
                Duration.Value = 1;
          
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.BeginStudyYear), 12, 25);
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
            }
        }

        private void CheckBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                NameHoliday.Text = "حرب تشرين التحريرية";
                Duration.Value = 1;
          
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.BeginStudyYear), 10, 3);
            }
            else
            {
                NameHoliday.Text = "";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                NameHoliday.Text = "عيد الفصح الغربي";
                Duration.Value = 1;
            
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 4, 17);

            }
            else
            {
                NameHoliday.Text = "";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                NameHoliday.Text = "عيد الفصح غ/ش";
                Duration.Value = 1;
            
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 4, 24);

            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
                DateHoliday.CustomFormat = " ";
            }
        }

        private void CheckBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                NameHoliday.Text = "عيد المعلم";
                Duration.Value = 1;
         
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 3, 17);
            }
            else
            {
                NameHoliday.Text = " ";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                NameHoliday.Text = "عيد الأم";
                Duration.Value = 1;
          
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 3,21 );

            }
            else
            {
                NameHoliday.Text = "";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox12_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                NameHoliday.Text = "عيد الجلاء";
                Duration.Value = 1;
          
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 4, 17);
            }
            else
            {
                NameHoliday.Text = "";
                DateHoliday.CustomFormat = " ";
                Duration.Value = 0;
            }
        }

        private void CheckBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                NameHoliday.Text = "عيد الأضحى";
                Duration.Value = 1;
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                NameHoliday.Text = "عيد الفطر";
                Duration.Value = 1;
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
            }
        }

        private void CheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                NameHoliday.Text = "عيد العمال";
                Duration.Value = 1;
        
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32(StudyYear.EndStudyYear), 5, 1);
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
                DateHoliday.CustomFormat = " ";
            }
        }

        private void CheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                NameHoliday.Text = "عيد الشهداء";
                Duration.Value = 1;
  
                int year = DateTime.Now.Year;
                DateHoliday.CustomFormat = "dd/MM/yyyy";
                DateHoliday.Value = new DateTime(Convert.ToInt32( StudyYear.EndStudyYear), 5, 6);
            }
            else
            {
                NameHoliday.Text = "";
                Duration.Value = 0;
                DateHoliday.CustomFormat = " ";
            }
        }

        private void DGV_Holiday_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void زر_تعديل_العطلة_Click(object sender, EventArgs e)
        {
            if (check())
            {
                year.UpdateHoliday(year.idHoliday, NameHoliday.Text, Duration.Value.ToString(), DateHoliday.Value.ToString());
                DGV_Holiday.DataSource = year.SelectHoliday(StudyYear.YearID);
                rename();
                واجهة_العام_الدراسي_و_العطل.deleg.DGV_StudyYear.DataSource = year.LoadStudyYearHoliday(StudyYear.YearID);
                واجهة_العام_الدراسي_و_العطل.deleg.rename();
               
                MessageBox.Show("تمت التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
    }
}
