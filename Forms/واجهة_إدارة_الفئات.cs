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
    public partial class واجهة_إدارة_الفئات : Form
    {
        public واجهة_إدارة_الفئات()
        {
            InitializeComponent();
        }
        Category myCategory = new Category();
        public void rename()
        {
            DGV_Category.Columns[0].Visible = false;
            DGV_Category.Columns[1].HeaderText = "اسم الفئة";
        }
        private void زر_إضافة_فئة_Click(object sender, EventArgs e)
        {
            if (!(NameCategory.Text == null))
            {
                myCategory.InsertCategory(NameCategory.Text, Category.idStudyYear);
                DGV_Category.DataSource = myCategory.SelectCategory(Category.idStudyYear);
                rename();

                ClassDivisionCategory.ShowCustomCategory(واجهة_إدارة_اللطلاب.deleg.CategoryCategory, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

                MessageBox.Show("يجب إدخال اسم الشعبة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void زر_حذف_فئة_Click(object sender, EventArgs e)
        {
            try
            {
                myCategory.DeleteCategory(myCategory.id);
                DGV_Category.DataSource = myCategory.SelectCategory(Division.idStudyYear);            
                rename();
                ClassDivisionCategory.ShowCustomCategory(واجهة_إدارة_اللطلاب.deleg.CategoryCategory, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("فشلت عملية الحذف", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void واجهة_إدارة_الفئات_Load(object sender, EventArgs e)
        {
            DGV_Category.DataSource = myCategory.SelectCategory(Division.idStudyYear);
            rename();
        }

        private void DGV_Category_DoubleClick(object sender, EventArgs e)
        {

            if (DGV_Category.Rows.Count > 0)
            {
                int SelectRowIndex = DGV_Category.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_Category.Rows[SelectRowIndex];

              myCategory.id = Convert.ToInt32(SelectedRow.Cells[0].Value);

                if (!(this.DGV_Category.CurrentRow.Cells[1].Value == null))
                    NameCategory.Text = SelectedRow.Cells[1].Value.ToString();
                rename();
            }
        }

        private void واجهة_إدارة_الفئات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Category.IsClosing = true;
        }
    }
}
