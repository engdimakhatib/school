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
    public partial class واجهة_توزيع_درجات_المواد : Form
    {
        public واجهة_توزيع_درجات_المواد()
        {
            InitializeComponent();
            if (n == null)
                n = this;

        }
        private static واجهة_توزيع_درجات_المواد n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_توزيع_درجات_المواد deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_توزيع_درجات_المواد();
                }
                return n;
            }

        }
        Subject mySubject = new Subject();
        public static واجهة_توزيع_الدرجات Dist = new واجهة_توزيع_الدرجات();
        public static واجهة_إدخال_المواد subj = new واجهة_إدخال_المواد();

        public void buildCombobox()
        {
            mySubject.IsLoad = true;
            DataTable dt= mySubject.SelectClass();
            dt.Rows.RemoveAt(3);
            idClass.DataSource = dt;
           
            idClass.ValueMember = "id";
            idClass.DisplayMember = "NameClass";
            Subject.idClass = 1;
            Subject.NameClassSelected = "الأول الثانوي";
          

            idSubject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
            idSubject.ValueMember = "id";
            idSubject.DisplayMember = "NameSubject";
 

            idDistibution.DataSource = mySubject.SelectDist();
            idDistibution.ValueMember = "id";
            idDistibution.DisplayMember = "NameDistribution";
       
            mySubject.IsLoad = false;
        }
        private void DGV_EMP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void rename()
        {
            DGV_Subject_Dist.Columns[0].Visible = false;
            DGV_Subject_Dist.Columns[1].Visible = false;
            DGV_Subject_Dist.Columns[2].HeaderText = "اسم المادة";
            DGV_Subject_Dist.Columns[3].HeaderText = "اسم التوزيع";
            DGV_Subject_Dist.Columns[4].HeaderText = "العلامة";
            DGV_Subject_Dist.Columns[5].HeaderText = "اسم الصف";
        }
        private void واجهة_توزيع_درجات_المواد_Load(object sender, EventArgs e)
        {
            buildCombobox();
            idSubject_Loaded(idSubject);
            idDistibution_Loaded(idDistibution);
            if (!(idSubject.Items.Count == 0))
            {
                DGV_Subject_Dist.DataSource = mySubject.SelectDistMarkSubject(mySubject.idSubjectForDist);
                rename();
                Mark.Text = "";
            }
     
         
        }
        private void idSubject_Loaded(object sender) {
            if (!(idSubject.Items.Count==0)) {
                idSubject.SelectedIndex = 0;
                mySubject.idSubjectForDist = Convert.ToInt32(idSubject.SelectedValue);
            } }
        private void idDistibution_Loaded(object sender)
        {
            if (!(idDistibution.Items.Count == 0))
            {
                idDistibution.SelectedIndex = 0;
                mySubject.idDistributionForDist = Convert.ToInt32(idDistibution.SelectedValue);
            }
        }
        private void واجهة_توزيع_درجات_المواد_FormClosing(object sender, FormClosingEventArgs e)
        {
            Subject.IsClosingSubjectDistirution = true;
        }

        private void زر_إظهار_واجهة_المواد_Click(object sender, EventArgs e)
        {
           
            if (!(idClass.SelectedItem == null))
            {
                واجهة_إدخال_المواد.deleg.idClass.Text = Subject.NameClassSelected;
                واجهة_إدخال_المواد.deleg.idClass.SelectedItem = Subject.NameClassSelected;
                واجهة_إدخال_المواد.deleg.idClass.SelectedValue = Subject.idClass;
                if (Subject.IsClosingSubject == true)
                {
                    subj = new واجهة_إدخال_المواد();
                    subj.Show();
                }
                else
                {
                    subj.Show();
                }
            }
            else
            {
                MessageBox.Show("يجب اختيار الصف الذي ستضاف له المادة", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void زر_إظهار_واجهة_توزيع_الدرجات_Click(object sender, EventArgs e)
        {
            if (Subject.IsClosingDistribution == true)
            {
                Dist = new واجهة_توزيع_الدرجات();
                Dist.Show();
            }
            else
            {
                Dist.Show();
            }
        }

        private void IdClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(mySubject.IsLoad))
            {
               Subject.idClass= Convert.ToInt32(idClass.SelectedValue);
                Subject.NameClassSelected = idClass.Text.Trim().ToString();
                idSubject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
           
            }
        }

        private void IdSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(mySubject.IsLoad))
            {
                if (!(idSubject.Items.Count == 0))
                {
                    mySubject.idSubjectForDist = Convert.ToInt32(idSubject.SelectedValue);
                    if (!(mySubject.idSubjectForDist == -1) )
                    {
                        DGV_Subject_Dist.DataSource = mySubject.SelectDistMarkSubject(mySubject.idSubjectForDist);
                        rename();
                    }

                }
            }
        }
        private void DGV_Subject_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Subject_Dist.Rows.Count > 0)
            {
               // mySubject.idDistibution = Convert.ToInt32(this.DGV_Subject_Dist.CurrentRow.Cells[0].Value);
                if (!(this.DGV_Subject_Dist.CurrentRow.Cells[0].Value == null))
                    mySubject.idSubjectForDist = Convert.ToInt32(this.DGV_Subject_Dist.CurrentRow.Cells[0].Value);
                if (!(this.DGV_Subject_Dist.CurrentRow.Cells[1].Value == null))
                    mySubject.idDistributionForDist = Convert.ToInt32(this.DGV_Subject_Dist.CurrentRow.Cells[1].Value);
                if (!(this.DGV_Subject_Dist.CurrentRow.Cells[4].Value == null))
                {
                    mySubject.Mark = Convert.ToSingle(this.DGV_Subject_Dist.CurrentRow.Cells[4].Value);
                    Mark.Value = Convert.ToDecimal (this.DGV_Subject_Dist.CurrentRow.Cells[4].Value);
                }
            }
        }

        private void زر_إضافة_درجة_توزيع_مادة_Click(object sender, EventArgs e)
        {
            mySubject.Mark = Convert.ToSingle(Mark.Value);
            if (mySubject.idSubjectForDist == -1)
                MessageBox.Show("الرجاء اختيار مادة","",MessageBoxButtons.OK,MessageBoxIcon.Error );
            if (mySubject.idDistributionForDist == -1 )
                MessageBox.Show("الرجاء اختيار توزيع ما", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!(mySubject.Mark == 0))
            {
                mySubject.InsertDistSubject(mySubject.idSubjectForDist, mySubject.idDistributionForDist, Subject.idStudyYear, mySubject.Mark);
                DGV_Subject_Dist.DataSource = mySubject.SelectDistMarkSubject(mySubject.idSubjectForDist);
                rename();
            }
        }

        private void زر_جذف_توزيع_درجة_المادة_Click(object sender, EventArgs e)
        {
            mySubject.DeleteDistibutionMarkSubject(mySubject.idSubjectForDist, mySubject.idDistributionForDist);
            DGV_Subject_Dist.DataSource = mySubject.SelectDistMarkSubject(mySubject.idSubjectForDist);
            rename();
            Mark.Value = 0;
        }

        private void زر_تعديل_توزيع_درجة_المادة_Click(object sender, EventArgs e)
        {
            mySubject.Mark = Convert.ToSingle(Mark.Value);
            mySubject.UpdateSubjectDistribution(mySubject.idSubjectForDist, mySubject.idDistributionForDist, mySubject.Mark);
            DGV_Subject_Dist.DataSource = mySubject.SelectDistMarkSubject(mySubject.idSubjectForDist);
            rename();
        }

        private void IdDistibution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(mySubject.IsLoad))
            {
                mySubject.idDistributionForDist = Convert.ToInt32(idDistibution.SelectedValue);
               
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
