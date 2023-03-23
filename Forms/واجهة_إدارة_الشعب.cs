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
    public partial class واجهة_إدارة_الشعب : Form
    {
        public واجهة_إدارة_الشعب()
        {
            InitializeComponent();
        }
        Division myDivision = new Division();
        public void rename()
        {
            DGV_Division.Columns[0].Visible = false;
            DGV_Division.Columns[1].HeaderText = "اسم الشعبة";
        }
        private void زر_إضافة_شعبة_Click(object sender, EventArgs e)
        {
            if (!(NameDivision.Text == null))
            {
                myDivision.InsertDivision(NameDivision.Text, Division.idStudyYear);
                DGV_Division.DataSource = myDivision.SelectDivision(Division.idStudyYear);
                rename();
            
                ClassDivisionCategory.ShowCustomDivision(واجهة_إدارة_اللطلاب.deleg.DivisionDivision, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 

            MessageBox.Show("يجب إدخال اسم الشعبة","خطأ إدخال",MessageBoxButtons.OK,MessageBoxIcon.Error );
        }

        private void زر_حذف_شعبة_Click(object sender, EventArgs e)
        {
            try {
                myDivision.DeleteDivision(myDivision.id);
                DGV_Division.DataSource = myDivision.SelectDivision(Division.idStudyYear);
                DGV_Division.Columns[0].Visible = false;
              
                rename();
                ClassDivisionCategory.ShowCustomDivision(واجهة_إدارة_اللطلاب.deleg.DivisionDivision, ClassDivisionCategory.idStudyYear);
                واجهة_إدارة_اللطلاب.deleg.RenamedataGridCategoryStudent();
                MessageBox.Show("تمت العملية بنجاح", "معلومات العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch  {
                MessageBox.Show("فشلت عملية الحذف", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } }
        private void واجهة_إدارة_الشعب_Load(object sender, EventArgs e)
        {
            DGV_Division.DataSource = myDivision.SelectDivision(Division.idStudyYear);
            rename();
        }

        private void DGV_Division_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Division.Rows.Count > 0)
            {
                int SelectRowIndex = DGV_Division.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_Division.Rows[SelectRowIndex];

                myDivision.id = Convert.ToInt32(SelectedRow.Cells[0].Value);
            
                if (!(this.DGV_Division.CurrentRow.Cells[1].Value == null))
                    NameDivision.Text = SelectedRow.Cells[1].Value.ToString();
                rename();
            }
        }

        private void واجهة_إدارة_الشعب_FormClosing(object sender, FormClosingEventArgs e)
        {
            Division.IsClosing = true;
        }
    }
}
