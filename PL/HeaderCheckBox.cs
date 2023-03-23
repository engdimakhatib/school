using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MYSCHOOLFINAL
{
    public class HeaderCheckBox
    {
        public DataGridView G;
        public CheckBox Header = null;
        public bool IsHeaderCheckBoxClicked = false;
        public static List<int> Id = new List<int>();
        public void AddHeaderCheckBox(DataGridView G)
        {
            Header = new CheckBox();
            Header.Size = new Size(15, 15);
            Header.Left = G.Width;
            Header.Top = G.Top;
            Header.RightToLeft = RightToLeft.Yes;

            Header.Dock = DockStyle.Top ;
      
            G.Controls.Add(Header);
        }
        public void HeaderCheckBoxClick(CheckBox HcheckBox)
        {
            string name = G.Columns[0].Name;
            IsHeaderCheckBoxClicked = true;
            foreach (DataGridViewRow Row in G.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells[name]).Value = HcheckBox.Checked;
            G.RefreshEdit();
            IsHeaderCheckBoxClicked = false;
        }
        public void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }
        //id إضافة المختارين لللائحة الاختيار بتحدد ال    
        public static List<int> GetNum(DataGridView G)
        {

            string name = G.Columns[0].Name;

            for (int i = 0; i <= G.RowCount - 1; i++)
                if (Convert.ToBoolean(G.Rows[i].Cells[name].Value) == true)
                    Id.Add(Convert.ToInt32(G.Rows[i].Cells[1].Value));
            return Id;
        }

        public static List<int> GetNumNotChecked(DataGridView G)
        {

            string name = G.Columns[0].Name;

            for (int i = 0; i <= G.RowCount - 1; i++)
                if (Convert.ToBoolean(G.Rows[i].Cells[name].Value) == false)
                    Id.Add(Convert.ToInt32(G.Rows[i].Cells[1].Value));
            return Id;
        }
        public static List<int> GetNumNotCheckedSubject(DataGridView G)
        {

            string name = G.Columns[0].Name;

            for (int i = 0; i <= G.RowCount - 1; i++)
                if (Convert.ToBoolean(G.Rows[i].Cells[name].Value) == false)
                    Id.Add(Convert.ToInt32(G.Rows[i].Cells[2].Value));
            return Id;
        }

    }
}


