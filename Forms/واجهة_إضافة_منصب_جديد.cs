using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSCHOOLFINAL.Forms
{
    public partial class واجهة_إضافة_منصب_جديد : Form
    {
        PL.DbProvider dbprovider = new PL.DbProvider();
        public واجهة_إضافة_منصب_جديد()
        {
            InitializeComponent();
        }
        private void ClearTextBoxes()
        {
            txtrole_name.Text = "";
            txtrole_code.Text = "";
            txtrole_Desc.Text = "";
        }
        private void زر_مسح_Click(object sender, EventArgs e)
        {
            try
            {
                string RoleID = dataGridViewRole.CurrentRow.Cells[0].Value.ToString();
                dbprovider.DeleteCurrentRole(RoleID);
                dataGridViewRole.DataSource = dbprovider.LoadRoleTable();
                dataGridViewRole.Columns[0].Visible = false;
            }
            catch { }   
        }

        private void زر_بحث_منصب_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewRole.DataSource = dbprovider.Searchrole(txtrole_name.Text);
                dataGridViewRole.Columns[0].Visible = false;
            }
            catch { }
        }

        private void زر_تعديل_منصب_Click(object sender, EventArgs e)
        {
            try
            {
                string RoleID = dataGridViewRole.CurrentRow.Cells[0].Value.ToString();
                dbprovider.UpdateCurrentRole(RoleID, txtrole_name.Text, txtrole_code.Text, txtrole_Desc.Text);
                dataGridViewRole.DataSource = dbprovider.LoadRoleTable();
                dataGridViewRole.Columns[0].Visible = false;
            }
            catch { }
        }

        private void زر_حفظ_منصب_Click(object sender, EventArgs e)
        {
            try { 
            dbprovider.InsertNewRole(txtrole_name.Text, txtrole_code.Text, txtrole_Desc.Text);
            dataGridViewRole.DataSource = dbprovider.LoadRoleTable();
            dataGridViewRole.Columns[0].Visible = false;
            //  : جديد  Role لما نضيف
            // الجديد و خصائصه  Role  و يبدأ يضيف لها ال  Role ياخد نسخة من جدول  
            // الأساسية الموجودة في برنامجنا permission  رح نحمل ال
            DataTable dt = dbprovider.LoadPermissions();
            //  جديد إلا لو نحنا بدنا نقفل شي  user   و رقم واحد للدلالة على أن مختار أو متاح لأي  DataTableفي ال     index  يقابل ال     Permission id  و ترتيب اللي هو   AD  نمرر كود المدير مثلا
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dbprovider.InsertInPermissionRole(txtrole_code.Text, i.ToString(), "1");
            }
            //هيك رح يسجّل اسم المنصب و السماحيات الخاصة به
            }
            catch { }
        }

        private void واجهة_إضافة_منصب_جديد_Load(object sender, EventArgs e)
        {
            dataGridViewRole.DataSource = dbprovider.LoadRoleTable();
            dataGridViewRole.Columns[0].Visible = false;
        }

        private void DataGridViewRole_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ClearTextBoxes();
                txtrole_name.Text = dataGridViewRole.CurrentRow.Cells[1].Value.ToString();
                txtrole_code.Text = dataGridViewRole.CurrentRow.Cells[2].Value.ToString();
                txtrole_Desc.Text = dataGridViewRole.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void واجهة_إضافة_منصب_جديد_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingRole=true;
        }
    }
}
