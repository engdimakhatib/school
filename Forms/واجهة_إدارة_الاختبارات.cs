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
    public partial class واجهة_إدارة_الاختبارات : Form
    {
        public واجهة_إدارة_الاختبارات()
        {
            InitializeComponent();
        }
        Exam myExam = new Exam();
        public void rename()
        {
            DGV_Exam.Columns[0].Visible = false;
            DGV_Exam.Columns[1].HeaderText = "اسم الاختبار";
        }
        private void DGV_Exam_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Exam.Rows.Count > 0)
            {
                int SelectRowIndex = DGV_Exam.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_Exam.Rows[SelectRowIndex];

                myExam.id = Convert.ToInt32(SelectedRow.Cells[0].Value);

                if (!(this.DGV_Exam.CurrentRow.Cells[1].Value == null))
                    NameExam.Text = SelectedRow.Cells[1].Value.ToString();
                rename();
            }
        }

        private void زر_إضافة_اختبار_Click(object sender, EventArgs e)
        {
            if (!(NameExam.Text == null))
            {
                myExam.InsertExam(NameExam.Text);
                DGV_Exam.DataSource = myExam.SelectExam();
                rename();

                ClassDivisionCategory.ShowCustomCategory(واجهة_إدارة_اللطلاب.deleg.CategoryCategory, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                DataTable dt = myExam.SelectExam();
               ( (ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).DataSource = dt;
                ((ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).DisplayMember = "NameExam";
                ((ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).ValueMember = "id";
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

                MessageBox.Show("يجب إدخال اسم الاختبار", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void زر_حذف_اختبار_Click(object sender, EventArgs e)
        {
            try
            {
                myExam.DeleteExam(myExam.id);
                DGV_Exam.DataSource = myExam.SelectExam();
      

                rename();
                ClassDivisionCategory.ShowCustomCategory(واجهة_إدارة_اللطلاب.deleg.CategoryCategory, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                DataTable dt = myExam.SelectExam();
                ((ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).DataSource = dt;
                ((ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).DisplayMember = "NameExam";
                ((ListBox)(واجهة_إدارة_اللطلاب.deleg.idExam)).ValueMember = "id";
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("فشلت عملية الحذف", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void واجهة_إدارة_الاختبارات_Load(object sender, EventArgs e)
        {
            DGV_Exam.DataSource = myExam.SelectExam();
            rename();
        }

        private void واجهة_إدارة_الاختبارات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exam.IsClosing = true;
        }
    }
}
