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
    public partial class واجهة_إضافة_مستخدم_جديد : Form
    {
        string myRole;
        PL.DbProvider dbprovider = new PL.DbProvider();
        PL.Permission per = new PL.Permission();
        public واجهة_إضافة_مستخدم_جديد()
        {
           
            InitializeComponent();
        }
        public واجهة_إضافة_مستخدم_جديد(string Role)
        {
            this.myRole = Role;
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtuser_name.Text = "";
            txtuser_pass.Text = "";
            cmb_userrole.Text = "";
        }
        private void زر_بحث_عن_مستخدم_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewUser.DataSource = dbprovider.SearchUser(txtuser_search.Text);
                dataGridViewUser.Columns[0].Visible = false;
            }
            catch { }
        }

        private void زر_تعديل_مستخدم_Click(object sender, EventArgs e)
        {
            try
            {
                string user_id = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                dbprovider.UpdateCurrentUsers(user_id, txtuser_name.Text, txtuser_pass.Text, cmb_userrole.Text);
                dataGridViewUser.DataSource = dbprovider.LoadUserTable();
                dataGridViewUser.Columns[0].Visible = false;
            }
            catch { }
        }

        private void زر_حفظ_مستخدم_Click(object sender, EventArgs e)
        {
            dbprovider.InsertNewUser(txtuser_name.Text, txtuser_pass.Text, cmb_userrole.Text);
            dataGridViewUser.DataSource = dbprovider.LoadUserTable();
            dataGridViewUser.Columns[0].Visible = false;
        }

        private void زر_حذف_مستخدم_Click(object sender, EventArgs e)
        {
            try
            {
                string user_id = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                dbprovider.DeleteCurrentUser(user_id);
                dataGridViewUser.DataSource = dbprovider.LoadUserTable();
                dataGridViewUser.Columns[0].Visible = false;
                ClearTextBoxes();
            }
            catch { }
        }

        private void واجهة_إضافة_مستخدم_جديد_Load(object sender, EventArgs e)
        {
            cmb_userrole.DataSource = dbprovider.LoadRoleTable();
            cmb_userrole.DisplayMember = dbprovider.LoadRoleTable().Columns[1].ToString();

            dataGridViewUser.DataSource = dbprovider.LoadUserTable();
            dataGridViewUser.Columns[0].Visible = false;
            //if (myRole == "V")
            //    per.LoadDefaultPermission(this);
            //else if (myRole == "AD")
            //{ }
        }

    

        private void زر_حذف_مستخدم_Click_1(object sender, EventArgs e)
        {
            try
            {
                string RoleID = dataGridViewUser.CurrentRow.Cells[0].Value.ToString();
                dbprovider.DeleteCurrentRole(RoleID);
                dataGridViewUser.DataSource = dbprovider.LoadRoleTable();
                dataGridViewUser.Columns[0].Visible = false;
            }
            catch { }
        }

        private void DataGridViewUser_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            ClearTextBoxes();
            txtuser_name.Text = dataGridViewUser.CurrentRow.Cells[1].Value.ToString();
            txtuser_pass.Text = dataGridViewUser.CurrentRow.Cells[2].Value.ToString();
            cmb_userrole.Text = dataGridViewUser.CurrentRow.Cells[3].Value.ToString();
                }
            catch
            { }
        }

        private void واجهة_إضافة_مستخدم_جديد_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingUsers = true;
        }
    }
}
