using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_إضافة_اللغات_و_العملات : Form
    {
        public واجهة_إضافة_اللغات_و_العملات()
        {
            this.Controls.Clear();
            InitializeComponent();
        }
        public void save_Language()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
                    Properties.Settings.Default.Lang = "ar";
                    Properties.Settings.Default.Save();
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    Properties.Settings.Default.Lang = "en";
                    Properties.Settings.Default.Save();
                    break;
                default: break;
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            save_Language();
        }

        private void Sy_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void USD_radioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void save_currency()
        {
            if(sy_radioButton.Checked )
            {
                Properties.Settings.Default.Currency = "ar-SY";
                Properties.Settings.Default.Currency_Check = "ل.س";
                Properties.Settings.Default.Save();

            }
            if (USD_radioButton.Checked)
            {
                Properties.Settings.Default.Currency = "en-US";
                Properties.Settings.Default.Currency_Check = "USD";
                Properties.Settings.Default.Save();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            save_currency();
            واجهة_تسجيل__الدخول login = new واجهة_تسجيل__الدخول();
            login.Show();
        }

        private void واجهة_إضافة_اللغات_و_العملات_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingLanguage_CurrencyForm = true;
        }

        private void واجهة_إضافة_اللغات_و_العملات_Load(object sender, EventArgs e)
        {

        }
    }
}
