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
    public partial class واجهة_إدارة_المعدات : Form
    {
        public واجهة_إدارة_المعدات()
        {
            InitializeComponent();
        }
        Hall myHall = new Hall();
        public void rename()
        {
            DGV_Equipment.Columns[0].Visible = false;
            DGV_Equipment.Columns[1].HeaderText = "اسم المعد";
            DGV_Equipment.Columns[2].HeaderText = "ملاحظات";
        }
        private void واجهة_إدارة_المعدات_Load(object sender, EventArgs e)
        {
            DGV_Equipment.DataSource = myHall.SelectEquipment(Hall.idStudyYear);
            rename();
        }

        private void زر_إضافة_معد_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameEquipment.Text != null)
                {
                    myHall.InsertEquipment(NameEquipment.Text, Notes.Text, Hall.idStudyYear);
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.DataSource = myHall.SelectEquipment(Hall.idStudyYear);
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.DisplayMember = "NameEquipment";
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.ValueMember = "id";
                    DGV_Equipment.DataSource = myHall.SelectEquipment(Hall.idStudyYear);
                    rename();
            
                    MessageBox.Show("تم إضافة المعد بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch
            {
                MessageBox.Show("الرجاء إدخال بيانات المعد","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return;
            }
        }

        private void زر_حذف_معد_Click(object sender, EventArgs e)
        {
            try
            {
                myHall.DeleteEquipment(myHall.idEquipment, Hall.idStudyYear);
                myHall.DeleteFromEquipmentHallForEquipment(myHall.idEquipment);
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.DataSource = myHall.SelectEquipment(Hall.idStudyYear);
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.DisplayMember = "NameEquipment";
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idEquipment.ValueMember = "id";
                DGV_Equipment.DataSource = myHall.SelectEquipment(Hall.idStudyYear);
                rename();
                MessageBox.Show("تم حذف المعد بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("الرجاء تحديد المعد المطلوب حذفه", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void واجهة_إدارة_المعدات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hall.IsClosingEquipment = true;
        }

        private void DGV_Equipment_DoubleClick(object sender, EventArgs e)
        {
            if(DGV_Equipment.Rows.Count>0)
            {
                myHall.idEquipment = Convert.ToInt32(this.DGV_Equipment.CurrentRow.Cells[0].Value);
                if (!(this.DGV_Equipment.CurrentRow.Cells[1].Value == null))
                    NameEquipment.Text = this.DGV_Equipment.CurrentRow.Cells[1].Value.ToString();


                if (!(this.DGV_Equipment.CurrentRow.Cells[2].Value == null))
                {
                    Notes.Text = this.DGV_Equipment.CurrentRow.Cells[2].Value.ToString();
                  
                }
            }
        }
    }
}
