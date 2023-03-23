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
    public partial class واجهة_الأعمال_المكلفة : Form
    {
        public واجهة_الأعمال_المكلفة()
        {
            InitializeComponent();
        }
        EMP ob = new EMP();
        public void rename()
        {
            DGV_AssignedWoork.Columns[0].Visible = false;
          
            DGV_AssignedWoork.Columns[1].HeaderText = "اسم العمل المكلّف به";
            DGV_AssignedWoork.Columns[2].HeaderText = "ملاحظات";
        }
        public void ClearTextBox()
        {
            NameWork.Text = "";
            Notes.Text = "";
        }
        private void زر_إضافة_عمل_Click(object sender, EventArgs e)
        {
            try
            {
                ob.InsertAssignedWork(NameWork.Text, EMP.idStudyYear, Notes.Text);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.ValueMember = "id";
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DisplayMember = "NameWork";
                DGV_AssignedWoork.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                rename();
                ClearTextBox();
                MessageBox.Show("تمت الإضافة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("يرجى إدخال بيانات صحيحة", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                ob.UpdateAssignedWork(EMP.idAssignedWork, NameWork.Text, EMP.idStudyYear, Notes.Text);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.ValueMember = "id";
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DisplayMember = "NameWork";
                DGV_AssignedWoork.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                rename();
                ClearTextBox();
                MessageBox.Show("تمت التعديل بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("يرجى إدخال بيانات صحيحة", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try {
                ob.DeleteAssignedWork(EMP.idAssignedWork, EMP.idStudyYear);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.ValueMember = "id";
                واجهة_إضافة_تعديل_الموظفين.deleg.AssignedWorkID.DisplayMember = "NameWork";
                DGV_AssignedWoork.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
                rename();
                ClearTextBox();
                MessageBox.Show("تمت الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                return;
            }
            }

        private void واجهة_الأعمال_المكلفة_Load(object sender, EventArgs e)
        {
            DGV_AssignedWoork.DataSource = ob.SelectAssignedWork(EMP.idStudyYear);
            rename();
        }

        private void واجهة_الأعمال_المكلفة_FormClosing(object sender, FormClosingEventArgs e)
        {
            EMP.IsClosingWoork = true;
        }

        private void DGV_AssignedWoork_DoubleClick(object sender, EventArgs e)
        {
            ClearTextBox();
            if (DGV_AssignedWoork.SelectedCells.Count > 0)
            {
                int SelectRowIndex = DGV_AssignedWoork.SelectedCells[0].RowIndex;
                DataGridViewRow SelectedRow = DGV_AssignedWoork.Rows[SelectRowIndex];
                EMP.idAssignedWork = Convert.ToInt32(SelectedRow.Cells[0].Value);

                if (!(SelectedRow.Cells[1].Value.ToString() == ""))
                    NameWork.Text = SelectedRow.Cells[1].Value.ToString();
                if (!(SelectedRow.Cells[2].Value.ToString() == ""))
                {
                
                    Notes.Text  = SelectedRow.Cells[2].Value.ToString();

          
                }


            }
        }
    }
}