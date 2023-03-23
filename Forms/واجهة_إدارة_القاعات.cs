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
    public partial class واجهة_إدارة_القاعات : Form
    {
        public واجهة_إدارة_القاعات()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }
        Hall myHall = new Hall();
        private static واجهة_إدارة_القاعات n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_إدارة_القاعات deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_إدارة_القاعات();
                }
                return n;
            }
        }
        public void rename()
        {
            DGV_Hall.Columns[0].Visible = false;
            DGV_Hall.Columns[1].Visible = false;
            DGV_Hall.Columns[2].HeaderText = "اسم القاعة";
            DGV_Hall.Columns[3].HeaderText = "الاسم المختصر";
            DGV_Hall.Columns[4].HeaderText = "نوع القاعة";
            DGV_Hall.Columns[5].HeaderText = "تصنيف القاعة";

            DGV_Hall.Columns[6].HeaderText = "ملاحظات";
        }
        public Boolean check()
        {
            Boolean ischeck = true;
            if ((NameHall.Text =="")||(TypeHall.SelectedItem==null)||(SpecializeHall.SelectedItem==null ))
                ischeck = false;
           return ischeck;
        }
        public void clear()
        {
            NameHall.Text = "";
            NickName.Text = "";
            TypeHall.SelectedItem = null;
            idclass.SelectedItem = null;
            SpecializeHall.SelectedItem = null;
            Notes.Text = "";
            idclass.Text = Hall.NameClassSelected;
            idclass.SelectedValue = Hall.idClass;
            idclass.SelectedItem = Hall.NameClassSelected;
        }
        private void واجهة_إدارة_القاعات_Load(object sender, EventArgs e)
        {
            DGV_Hall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
            rename();
            idclass.DataSource = myHall.SelectClass();
            idclass.ValueMember = "id";
            idclass.DisplayMember = "NameClass";
            واجهة_إدخال_المواد.deleg.idClass.Text = Subject.NameClassSelected;
            واجهة_إدخال_المواد.deleg.idClass.SelectedItem = Subject.NameClassSelected;
            واجهة_إدخال_المواد.deleg.idClass.SelectedValue = Subject.idClass;
        }

        private void زر_إضافة_قاعة_Click(object sender, EventArgs e)
        {
            try
            {
                myHall.NameHall = NameHall.Text;
                myHall.NickName = NickName.Text;
                myHall.SpecializeHall = SpecializeHall.SelectedItem.ToString();
                myHall.NotesHall = Notes.Text;
                myHall.TypeHall = TypeHall.SelectedItem.ToString();
                idclass.Text = Hall.NameClassSelected;
                idclass.SelectedValue = Hall.idClass;
                idclass.SelectedItem = Hall.NameClassSelected;
                if (check())
                {
                    myHall.InsertHall(myHall.NameHall, myHall.NickName, myHall.TypeHall, myHall.NotesHall, myHall.SpecializeHall, Hall.idClass, Hall.idStudyYear);
                    DGV_Hall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                    rename();
                    clear();
                   
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DisplayMember = "NameHall";
                    واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.ValueMember = "id";
                    MessageBox.Show("تم إضافة القاعة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("الرجاء إدخال معلومات القاعة المطلوبة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // return;
                }
            }
            catch
            {
                MessageBox.Show("يرجى إدخال كافة المعلومات","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void زر_تعديل_قاعة_Click(object sender, EventArgs e)
        {
            idclass.Text = Hall.NameClassSelected;
            idclass.SelectedValue = Hall.idClass;
            idclass.SelectedItem = Hall.NameClassSelected;
            myHall.NameHall = NameHall.Text;
            myHall.NickName = NickName.Text;
            myHall.SpecializeHall = SpecializeHall.SelectedItem.ToString();
            myHall.NotesHall = Notes.Text;
            myHall.TypeHall = TypeHall.SelectedItem.ToString();
            if (check())
            {
                myHall.UpdateHall(myHall.NameHall, myHall.NickName, myHall.TypeHall, myHall.NotesHall, myHall.SpecializeHall, myHall.IsClosed, Hall.idStudyYear, myHall.idHall);
                DGV_Hall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                rename();
                clear();
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DisplayMember = "NameHall";
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.ValueMember = "id";

                MessageBox.Show("تم تعديل القاعة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("الرجاء إدخال معلومات القاعة الملطوبة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void IsClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (IsClosed.Checked)
                myHall.IsClosed = 1;
            else
                myHall.IsClosed = 0;
        }

        private void زر_حذف_قاعة_Click(object sender, EventArgs e)
        {
            try {
                idclass.Text = Hall.NameClassSelected;
                idclass.SelectedValue = Hall.idClass;
                idclass.SelectedItem = Hall.NameClassSelected;
                myHall.DeleteHall(myHall.idHall, Hall.idStudyYear);
                myHall.DeleteFromEquipmentHallForHall(myHall.idHall);
                DGV_Hall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                rename();
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DataSource = myHall.SelectHall(Hall.idStudyYear, Hall.idClass);
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.DisplayMember = "NameHall";
                واجهة_إدارة_المعدات_في_كل_قاعة.deleg.idHall.ValueMember = "id";
                clear();
                MessageBox.Show("تم حذف القاعة بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("الرجاء تحديد القاعة المطلوب حذفها", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            }
        private void idclass_Loaded(object sender,int value)
        {
            if (!(idclass.Items.Count == 0))
            {
                idclass.SelectedValue = value;
               
            }
        }
        private void DGV_Hall_DoubleClick(object sender, EventArgs e)
        {
          
            myHall.idHall = Convert.ToInt32(this.DGV_Hall.CurrentRow.Cells[0].Value);
            if (!(this.DGV_Hall.CurrentRow.Cells[1].Value == null))
            {
             
               // idclass_Loaded(idclass, Convert.ToInt32(this.DGV_Hall.CurrentRow.Cells[1].Value));
                idclass.SelectedValue = Convert.ToInt32(this.DGV_Hall.CurrentRow.Cells[1].Value);
                idclass.Text  = Hall.NameClassSelected;
            }
            if (!(this.DGV_Hall.CurrentRow.Cells[2].Value == null))
            {
                NameHall.Text = this.DGV_Hall.CurrentRow.Cells[2].Value.ToString();
            }
            if (!(this.DGV_Hall.CurrentRow.Cells[3].Value == null))
                NickName.Text  = this.DGV_Hall.CurrentRow.Cells[3].Value.ToString();

            if (!(this.DGV_Hall.CurrentRow.Cells[4].Value == null))
            {
                TypeHall.SelectedItem = this.DGV_Hall.CurrentRow.Cells[4].Value.ToString().Trim();
                TypeHall.Text  = this.DGV_Hall.CurrentRow.Cells[4].Value.ToString();
            }

            if (!(this.DGV_Hall.CurrentRow.Cells[5].Value == null))
            {
                SpecializeHall.SelectedItem = this.DGV_Hall.CurrentRow.Cells[5].Value.ToString().Trim();
                SpecializeHall.Text= this.DGV_Hall.CurrentRow.Cells[5].Value.ToString();
            }
            if (!(this.DGV_Hall.CurrentRow.Cells[6].Value == null))
             Notes.Text=this.DGV_Hall.CurrentRow.Cells[6].Value.ToString();         
        }

        private void واجهة_إدارة_القاعات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hall.IsClosingHall = true;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
