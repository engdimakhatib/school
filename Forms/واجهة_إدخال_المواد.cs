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
    public partial class واجهة_إدخال_المواد : Form
    {
        public واجهة_إدخال_المواد()
        {
            InitializeComponent();
            if (n == null)
                n = this;
      
        }

        Subject mySubject = new Subject();
        private static واجهة_إدخال_المواد n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_إدخال_المواد deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_إدخال_المواد();
                }
                return n;
            }
           

        }
        private void واجهة_إدخال_المواد_FormClosing(object sender, FormClosingEventArgs e)
        {
            Subject.IsClosingSubject = true;
        }
        public void ClearTextBox()
        {
            NameSubject.Text = "";

            TypeSubject.SelectedItem = null;
            idClass.SelectedItem = null;

            NumHour.Value = 0;
            NumStudies1.Value = 0;
            NumStudies2.Value = 0;
            NumExcercise1.Value = 0;
            NumExcercise2.Value = 0;
            ExamDuration.Value = 0;
            idClass.Text = Subject.NameClassSelected;
            idClass.SelectedItem = Subject.NameClassSelected;
            idClass.SelectedValue = Subject.idClass;
        }
        public Boolean check()
        {
            Boolean ischeck = true;
           if((mySubject.NameSubject=="")||(mySubject.NumHour==0)||(idClass.SelectedItem==null )||(TypeSubject.SelectedItem==null)||(mySubject.ExamDuration==0))
                ischeck = false;
            if(TypeSubject.SelectedItem.ToString()=="عملي")
            {
                if ((NumExcercise1.Value == 0) || (NumExcercise2.Value == 0))
                {
                    ischeck = false;
                    MessageBox.Show("يجب إدخال عدد تمارين عملية لكل فصل","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                }
            }
            if (TypeSubject.SelectedItem.ToString() == " نظري")
            {
                if ((NumStudies1.Value == 0) || (NumStudies2.Value == 0))
                {
                    ischeck = false;
                    MessageBox.Show("يجب إدخال عدد المذاكرات ة لكل فصل", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ischeck;
        }
        private void زر_إضافة__مادة_Click(object sender, EventArgs e)
        {
            try {
               idClass.Text = Subject.NameClassSelected;
            idClass.SelectedItem = Subject.NameClassSelected;
                mySubject.NameSubject = NameSubject.Text.Trim().ToString();
                mySubject.TypeSubject = TypeSubject.SelectedItem.ToString();
                mySubject.NameClass = idClass.Text.ToString();
                mySubject.ExamDuration = Convert.ToInt32(ExamDuration.Value);
                mySubject.NumHour = Convert.ToInt32(NumHour.Value);
                mySubject.NumExcercise1 = Convert.ToInt32(NumExcercise1.Value);
                mySubject.NumExcercise2 = Convert.ToInt32(NumExcercise2.Value);
                mySubject.NumStudies1 = Convert.ToInt32(NumStudies1.Value);
                mySubject.NumStudies2 = Convert.ToInt32(NumStudies2.Value);
                if (check())
                {
                    mySubject.InsertSubject(mySubject.NameSubject, Subject.idStudyYear, Subject.idClass, mySubject.NumHour, mySubject.TypeSubject, mySubject.ExamDuration, mySubject.NameClass, mySubject.NumExcercise1, mySubject.NumExcercise2, mySubject.NumStudies1, mySubject.NumStudies2);
                    DGV_Subject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
                    rename();
                    واجهة_توزيع_درجات_المواد.deleg.idSubject.DataSource = mySubject.SelectSubject(EMP.idStudyYear, Subject.idClass);
                    واجهة_توزيع_درجات_المواد.deleg.idSubject.ValueMember = "id";
                    واجهة_توزيع_درجات_المواد.deleg.idSubject.DisplayMember = "NameSubject";
                    ClearTextBox();
                  
                }
         
            }
            catch(Exception ex)
            {
                // MessageBox.Show("","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
            }

        private void زر_حذف_مادة_Click(object sender, EventArgs e)
        {
            mySubject.DeleteSubject(mySubject.idSubject, Subject.idStudyYear);
            mySubject.DeleteSubjectFromMarkSubject(mySubject.idSubject);
            واجهة_توزيع_درجات_المواد.deleg.idSubject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);          
            DGV_Subject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
            واجهة_توزيع_درجات_المواد.deleg.idSubject.ValueMember = "id";
            واجهة_توزيع_درجات_المواد.deleg.idSubject.DisplayMember = "NameSubject";
            rename();
            ClearTextBox();
        }

        private void زر_تعديل_مادة_Click(object sender, EventArgs e)
        {
            idClass.Text = Subject.NameClassSelected;
            idClass.SelectedItem = Subject.NameClassSelected;
            if (check())
            {

                mySubject.UpdateSubject(mySubject.NameSubject, Subject.idStudyYear, Subject.idClass, mySubject.NumHour, mySubject.TypeSubject, mySubject.ExamDuration, mySubject.NameClass, mySubject.NumExcercise1, mySubject.NumExcercise2, mySubject.NumStudies1, mySubject.NumStudies2, mySubject.IsCanceled, mySubject.idSubject);
                DGV_Subject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
                rename();
                واجهة_توزيع_درجات_المواد.deleg.idSubject.DataSource = mySubject.SelectSubject(EMP.idStudyYear, Subject.idClass);
                واجهة_توزيع_درجات_المواد.deleg.idSubject.ValueMember = "id";
                واجهة_توزيع_درجات_المواد.deleg.idSubject.DisplayMember = "NameSubject";
                ClearTextBox();
            
            }
            }

        private void واجهة_إدخال_المواد_Load(object sender, EventArgs e)
        {
            idClass.DataSource = mySubject.SelectClass();
            idClass.ValueMember = "id";
            idClass.DisplayMember = "NameClass";
            idClass.Text = Subject.NameClassSelected;
            idClass.SelectedItem = Subject.NameClassSelected;
            idClass.SelectedValue = Subject.idClass;
            DGV_Subject.DataSource = mySubject.SelectSubject(Subject.idStudyYear, Subject.idClass);
            TypeSubject.SelectedItem = null;
        
            rename();
        }

        private void IsCanceled_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCanceled.Checked)
                mySubject.IsCanceled = 1;
            else
                mySubject.IsCanceled = 0;
        }
        public void rename()
        {
            this.DGV_Subject.Columns[1].HeaderText = "اسم المادة";
            this.DGV_Subject.Columns[2].HeaderText = "نوع المادة";
            this.DGV_Subject.Columns[3].HeaderText = "نصاب المادة";
            this.DGV_Subject.Columns[4].HeaderText = "مدة الامتحان";
            this.DGV_Subject.Columns[5].HeaderText = "عدد تمارين عملية للفصل الأول";
            this.DGV_Subject.Columns[6].HeaderText = "عدد تمارين عملية للفصل الثاني";
            this.DGV_Subject.Columns[7].HeaderText = "عدد مذاكرات الفصل الأول";
            this.DGV_Subject.Columns[8].HeaderText = "عدد مذاكرات الفصل الثاني";
           this.DGV_Subject.Columns[10].HeaderText = "اسم الصف";
            //رقم الصف
            //   this.DGV_Subject.Columns[9].HeaderText = "";

            this.DGV_Subject.Columns[0].Visible = false;

            this.DGV_Subject.Columns[9].Visible = false;

        }
        private void DGV_Subject_DoubleClick(object sender, EventArgs e)
        {
            mySubject.idSubject = Convert.ToInt32(this.DGV_Subject.CurrentRow.Cells[0].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[1].Value == null))
              NameSubject.Text = this.DGV_Subject.CurrentRow.Cells[1].Value.ToString();

            if (!(this.DGV_Subject.CurrentRow.Cells[2].Value == null))
            {
                TypeSubject.SelectedItem = this.DGV_Subject.CurrentRow.Cells[2].Value.ToString();
                TypeSubject.Text= this.DGV_Subject.CurrentRow.Cells[2].Value.ToString();
            }
            if (!(this.DGV_Subject.CurrentRow.Cells[3].Value == null))
               NumHour.Value   =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[3].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[4].Value == null))
               ExamDuration.Value  =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[4].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[5].Value == null))
              NumExcercise1.Value  =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[5].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[6].Value == null))
                NumExcercise2.Value =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[6].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[7].Value == null))
                NumStudies1.Value =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[7].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[8].Value == null))
                NumStudies2.Value  =Convert.ToInt32( this.DGV_Subject.CurrentRow.Cells[8].Value);

            if (!(this.DGV_Subject.CurrentRow.Cells[10].Value == null))
            {
                idClass.SelectedItem = this.DGV_Subject.CurrentRow.Cells[10].Value.ToString();
                idClass.Text = this.DGV_Subject.CurrentRow.Cells[10].Value.ToString();
            }
        }
    }
}
