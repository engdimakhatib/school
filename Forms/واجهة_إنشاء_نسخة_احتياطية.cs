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
    public partial class واجهة_إنشاء_نسخة_احتياطية : Form
    {
        public واجهة_إنشاء_نسخة_احتياطية()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        static string sql = "Data Source=localhost;Initial Catalog=MySchool;Integrated Security=True";
        SqlConnection con = new SqlConnection(@sql);
        public void BackUp()
        {
            try {
                string file_name = txt_FileName.Text + "\\MySchool" + DateTime.Now.ToShortDateString().Replace('/', '-') + "-" +
         DateTime.Now.ToLongTimeString().Replace(':', '-');
                string bquery = "Backup Database MySchool to Disk ='" + file_name + ".bak'";
                cmd = new SqlCommand(bquery, con);
                con.Open();
                cmd.ExecuteNonQuery();
         
                DialogResult dialog = MessageBox.Show("تم حفظ النسخة الاحتياطية بنجاح", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void واجهة_إنشاء_نسخة_احتياطية_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingBackUp = true;
        }

        private void زر_فتح_مجلد_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                txt_FileName.Text = folderBrowserDialog1.SelectedPath;
        }

        private void زر_إنشاء_نسخة_احتياطية_Click(object sender, EventArgs e)
        {
           BackUp();
        }

        private void واجهة_إنشاء_نسخة_احتياطية_Load(object sender, EventArgs e)
        {

        }
    }
}
