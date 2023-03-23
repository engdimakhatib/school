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
    public partial class واجهة_إدارة_المعدات_في_كل_قاعة : Form
    {
        public واجهة_إدارة_المعدات_في_كل_قاعة()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }
        private static واجهة_إدارة_المعدات_في_كل_قاعة n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_إدارة_المعدات_في_كل_قاعة deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_إدارة_المعدات_في_كل_قاعة();
                }
                return n;
            }

        }
        Hall myHall = new Hall();
        واجهة_إدارة_المعدات Equipment = new واجهة_إدارة_المعدات();
        واجهة_إدارة_القاعات Halls = new واجهة_إدارة_القاعات();
        public void buildCombobox()
        {
            myHall.IsLoad = true;    
            idClass.DataSource = myHall.SelectClass();
           idClass.ValueMember = "id";
            idClass.DisplayMember = "NameClass";
            Hall.idClass = 1;
            Hall.NameClassSelected = "الأول الثانوي";
            idHall.DataSource = myHall.SelectHall(Subject.idStudyYear,Hall.idClass);
            idHall.ValueMember = "id";
            idHall.DisplayMember = "NameHall";
           idEquipment.DataSource = myHall.SelectEquipment(Convert.ToInt32(Subject.idStudyYear));
            idEquipment.ValueMember = "id";
            idEquipment.DisplayMember = "NameEquipment";
            myHall.IsLoad = false;
        }
        public void rename()
        {
            DGV_Hall_Equipment.Columns[0].Visible = false;
            DGV_Hall_Equipment.Columns[1].Visible = false;
            DGV_Hall_Equipment.Columns[2].HeaderText = "اسم القاعة";
            DGV_Hall_Equipment.Columns[3].HeaderText = "اسم المعد";
            DGV_Hall_Equipment.Columns[4].HeaderText = "عدد القطع";
            DGV_Hall_Equipment.Columns[5].HeaderText = "ملاحظات";
        }
        public void clear()
        {
            Notes.Text = " ";
            Num.Text = " ";

        }
        private void واجهة_إدارة_المعدات_في_كل_قاعة_Load(object sender, EventArgs e)
        {
            buildCombobox();
            idHall_Loaded(idHall);
            idEquipment_Loaded(idEquipment);
            DGV_Hall_Equipment.DataSource = myHall.SelectEquipmentHall(Hall.idStudyYear, myHall.idHallForEquipment);
            rename();
    
        }
        private void idHall_Loaded(object sender)
        {
            if (!(idHall.Items.Count == 0))
            {
                idHall.SelectedIndex = 0;
                myHall.idHallForEquipment = Convert.ToInt32(idHall.SelectedValue);
            }
        }
        private void idEquipment_Loaded(object sender)
        {
            if (!(idEquipment.Items.Count == 0))
            {
                idEquipment.SelectedIndex = 0;
                myHall.idEquipmentForHall = Convert.ToInt32(idEquipment.SelectedValue);
            }
        }
        private void IdClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(myHall.IsLoad))
            {
                Hall.idClass = Convert.ToInt32(idClass.SelectedValue);
                Hall.NameClassSelected = idClass.Text.Trim().ToString();
                idHall.DataSource = myHall.SelectHall(Subject.idStudyYear, Hall.idClass);
          
            }
        }

        private void IdHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(myHall.IsLoad))
            {
                if (!(idHall.Items.Count == 0))
                {
                    myHall.idHallForEquipment = Convert.ToInt32(idHall.SelectedValue);
                    if (!(myHall.idHallForEquipment == -1))
                    {
                        DGV_Hall_Equipment.DataSource = myHall.SelectEquipmentHall(Hall.idStudyYear,myHall.idHallForEquipment);
                        rename();
                    }

                }
            }
        }
            private void IdEquipment_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (!(myHall.IsLoad))
            {
                myHall.idEquipmentForHall = Convert.ToInt32(idEquipment.SelectedValue);

            }
        }
            private void زر_إظهار_واجهة_القاعات_Click(object sender, EventArgs e)
        {
            
             واجهة_إدارة_القاعات.deleg.idclass.Text = Hall.NameClassSelected;
            واجهة_إدارة_القاعات.deleg.idclass.SelectedValue = Hall.idClass;
            واجهة_إدارة_القاعات.deleg.idclass.SelectedItem = Hall.NameClassSelected;
            if (Hall.IsClosingHall == true)
                {
                    Halls = new واجهة_إدارة_القاعات();
                    Halls.Show();
                }
                else
                {
                    Halls.Show();
                }
            }

            private void زر_إظهار_واجهة_المعدات_Click(object sender, EventArgs e)
            {
                if (Hall.IsClosingEquipment == true)
                {
                    Equipment = new واجهة_إدارة_المعدات();
                    Equipment.Show();
                }
                else
                {
                    Equipment.Show();
                }
            }

            private void واجهة_إدارة_المعدات_في_كل_قاعة_FormClosing(object sender, FormClosingEventArgs e)
            {
                Hall.IsClosingEquipment = true;
            }

        private void DGV_Hall_Equipment_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Hall_Equipment.Rows.Count > 0)
            {
                myHall.idHallForEquipment = Convert.ToInt32(this.DGV_Hall_Equipment.CurrentRow.Cells[0].Value);
                if (!(this.DGV_Hall_Equipment.CurrentRow.Cells[1].Value == null))
                    myHall.idEquipmentForHall = Convert.ToInt32(this.DGV_Hall_Equipment.CurrentRow.Cells[0].Value);

             
                if (!(this.DGV_Hall_Equipment.CurrentRow.Cells[4].Value == null))
                {
                    Num.Text  = this.DGV_Hall_Equipment.CurrentRow.Cells[4].Value.ToString();
                    myHall.Num= this.DGV_Hall_Equipment.CurrentRow.Cells[4].Value.ToString();
                }

                if (!(this.DGV_Hall_Equipment.CurrentRow.Cells[5].Value == null))
                {
                    Notes.Text  = this.DGV_Hall_Equipment.CurrentRow.Cells[5].Value.ToString();
                myHall.Notes= this.DGV_Hall_Equipment.CurrentRow.Cells[5].Value.ToString();
                }
            }
        }

        private void زر_إضافة_معدات_للقاعة_Click(object sender, EventArgs e)
        {
            try {
                myHall.InsertHallEquipment(myHall.idHallForEquipment, myHall.idEquipmentForHall, Hall.idStudyYear, myHall.Num, myHall.Notes);
                DGV_Hall_Equipment.DataSource = myHall.SelectEquipmentHall(Hall.idStudyYear, myHall.idHallForEquipment);
                rename();
                clear();
                MessageBox.Show("تم إضافة معدات للقاعة بنجاح","",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }
            catch
            {
                MessageBox.Show("الرجاء إدخال المعلومات كاملة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            }

        private void زر_حذف_معدات_قاعة_Click(object sender, EventArgs e)
        {
            try
            {
                myHall.DeleteEquipment(myHall.idHallForEquipment, Hall.idStudyYear);
                DGV_Hall_Equipment.DataSource = myHall.SelectEquipmentHall(Hall.idStudyYear, myHall.idHallForEquipment);
                rename();
                clear();
                MessageBox.Show("تم حذف معدات للقاعة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("الرجاء تحديد المعطيات المطلوب حذفها", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void زر_تعديل_معدات_قاعة_Click(object sender, EventArgs e)
        {
            try
            {
                myHall.UpdateHallEquipment(myHall.idHallForEquipment, myHall.idEquipmentForHall, Hall.idStudyYear, myHall.Num, myHall.Notes);
                DGV_Hall_Equipment.DataSource = myHall.SelectEquipmentHall(Hall.idStudyYear, myHall.idHallForEquipment);
                rename();
                MessageBox.Show("تم تعديل معدات للقاعة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch
            {
                MessageBox.Show("الرجاء إدخال المعلومات كاملة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

    }