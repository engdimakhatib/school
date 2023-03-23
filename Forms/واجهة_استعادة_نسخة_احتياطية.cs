using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_استعادة_نسخة_احتياطية : Form
    {
        public واجهة_استعادة_نسخة_احتياطية()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        static string sql = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
        SqlConnection con = new SqlConnection(@sql);
        public void Restore()
        {
            try
            {

                string bquery = "ALTER Databse  MySchool  SET  OFFLINE WITH ROLLBACK IMMEDIATE;" +
                    "Restore Database MySchool from Disk ='" + txt_FileName.Text+"'";
                cmd = new SqlCommand(bquery, con);
                con.Open();

                cmd.ExecuteNonQuery();
          
                DialogResult dialog = MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void واجهة_استعادة_نسخة_احتياطية_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingRestore = true;
        }

        private void زر_فتح_ملف_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txt_FileName.Text = openFileDialog1.FileName;
        }

        private void زر_إنشاء_نسخة_احتياطية_Click(object sender, EventArgs e)
        {
            Restore();
        }

        private void واجهة_استعادة_نسخة_احتياطية_Load(object sender, EventArgs e)
        {

        }
    }
}
