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
    public partial class واجهة_توزيع_الدرجات : Form
    {
        public واجهة_توزيع_الدرجات()
        {
            InitializeComponent();
        }
        Subject mySubject = new Subject();
        private void واجهة_توزيع_الدرجات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Subject.IsClosingDistribution = true;
        }

        private void زر_إضافة__توزيع_درجة_Click(object sender, EventArgs e)
        {
            if (!(NameDistribution.Text == ""))
            {
                mySubject.InsertDistribution(NameDistribution.Text);
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.DataSource = mySubject.SelectDist();
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.ValueMember = "id";
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.DisplayMember = "NameDistribution";
                DGV_Distribution.DataSource = mySubject.SelectDist();
                DGV_Distribution.Columns[0].Visible = false;
                DGV_Distribution.Columns[1].HeaderText = "اسم التوزيع";
                NameDistribution.Text = "";
                MessageBox.Show("تمت الإضافة بنجاح","",MessageBoxButtons.OK,MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show("يرجى إدخال اسم التوزيع","",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }
        private void زر_حذف_توزيع_درجة_Click(object sender, EventArgs e)
        {
            if (DGV_Distribution.Rows.Count > 0)
            {
                mySubject.DeleteDistibution(mySubject.idDistibution, Subject.idStudyYear);
                mySubject.DeleteDistibutionFromMarkSubject(mySubject.idDistibution);
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.DataSource = mySubject.SelectDist();
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.ValueMember = "id";
                واجهة_توزيع_درجات_المواد.deleg.idDistibution.DisplayMember = "NameDistribution";
                DGV_Distribution.DataSource = mySubject.SelectDist();
                DGV_Distribution.Columns[0].Visible = false;
                DGV_Distribution.Columns[1].HeaderText = "اسم التوزيع";
                NameDistribution.Text = "";
                MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DGV_Distribution_DoubleClick(object sender, EventArgs e)
        {
            if (DGV_Distribution.Rows.Count > 0)
            {
                mySubject.idDistibution = Convert.ToInt32(this.DGV_Distribution.CurrentRow.Cells[0].Value);

                if (!(this.DGV_Distribution.CurrentRow.Cells[1].Value == null))
                    NameDistribution.Text = this.DGV_Distribution.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void واجهة_توزيع_الدرجات_Load(object sender, EventArgs e)
        {
            DGV_Distribution.DataSource = mySubject.SelectDist();
            DGV_Distribution.Columns[0].Visible = false;
            DGV_Distribution.Columns[1].HeaderText = "اسم التوزيع";
        }

        private void DGV_Distribution_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
