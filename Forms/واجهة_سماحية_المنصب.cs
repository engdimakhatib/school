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
    public partial class واجهة_صلاحية_كل_منصب : Form
    {

        public واجهة_صلاحية_كل_منصب()
        {
            InitializeComponent();
        }
        PL. DbProvider dbprovider = new PL.DbProvider();
        PL.Permission per = new PL.Permission();
        private void زر_حفظ_صلاحية_المنصب_Click(object sender, EventArgs e)
        {
            //العقد الخارجية treeview نمر بحلقة على عقد ال 
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                //ونمر بحلقة أخرى على كل فرع لكل عقدة خارجية أو العقد الداخلية
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; i++)
                {
                    //نجعل بالبداية ولا شي مختار

                    int select = 0;
                    //أو لا check نشوف إذا العقدة معمول لها 
                    if (treeView1.Nodes[i].Nodes[j].Checked == true)
                    {
                        select = 1;
                    }
                    else
                    {
                        select = 0;
                    }
                    //و رح يعدّل الاختيار فقط per_id اللي أنا عاملوعلى النود و رح ياخد التاغ اللي كانselect  و رح ياخد الcomboBox رح ياهد الكود الموجود في 
                    dbprovider.UpdatePermissionRole(cmb_RolePermission.SelectedValue.ToString(), select.ToString(), treeView1.Nodes[i].Nodes[j].Tag.ToString());
                }

            }
        }

        private void Cmb_RolePermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //رح نمسك كل نود و نمشي عليها وحدة وحدة
            //Nodes-->Form Names
            //Nodes-->Nodes   BTN,MemuStrip.........
            //    اّخر  user إلى  user  أول خطوة نعمل مسح لكل شي لما ننقل من 
            //مشان يضيف الأصناف الجديدة
            treeView1.Nodes.Clear();
            List<string> formNames = new List<string>();
            for (int i = 0; i < formNames.Count; i++)
            {

                treeView1.Nodes.Add(formNames[i]);
                //يحمل جدول فيه أسماؤ الفورم و العناصر اللي جواه
                // Admin  نعطيه الاختيار اللي ننا اخترناه مثل   
                //رح ترجع العناصر الخاصة بالفورم بدلالة الكود
                dt = dbprovider.LoadPermissionsRole(cmb_RolePermission.SelectedValue.ToString(), formNames[i]);
                dataGridViewRolePer.DataSource = dt;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    //كل قورم تطلع يطلع تحتها أسماء اللي جواها
                    //اسم الش اللي علملنا عليه صلاحية  dt.Rows[j][5]. 
                    //permission اللي لهل  id ال   Tag  و حظينا بال   
                    treeView1.Nodes[i].Nodes.Add(dt.Rows[j][5].ToString()).Tag = dt.Rows[j][1].ToString();
                    if (dt.Rows[j][2].ToString().Equals("1"))
                    {
                        treeView1.Nodes[i].Nodes[j].Checked = true;
                    }
                    else
                        if (dt.Rows[j][2].ToString().Equals("0"))
                    {
                        treeView1.Nodes[i].Nodes[j].Checked = false;
                    }
                    else { }
                }
            }
            //هذه الميثود سوف 
        }

        private void واجهة_صلاحية_كل_منصب_Load(object sender, EventArgs e)
        {
            //ميثود رح نستهدمها لمرة واحدة
            //1
             List<string> FormNames = per.GetFormsNames();
             DataTable dt = new DataTable();
            //2
            // بهذا الفورم items محمّل بأسماء ال  DataTable نعطيها فورم و ترجع لنا 
            //DataTable  نعمل لها دمج مع ال 
            //3
            for (int i = 0; i < FormNames.Count; i++)
             {dt.Merge(per.LoadformItemsNamesDT(FormNames[i].ToString())); }

            // permission     في جدول ال   insert و نعملو    DataTable  في النهاية ناخد ال 
            //4
             for (int i = 0; i <dt.Rows.Count ; i++)
             { dbprovider.InsertAllFormsAndButtons(dt.Rows[i][1].ToString(),dt.Rows[i][0].ToString());}
            // Buttons,Forms,PictureBoxes....  خطوة ستتم مرة واحدة كي نجلب كل أسماء ال



            treeView1.CheckBoxes = true;
            // كاسم ظاهري name يعيد جدول لذا نختار حقل   
            // قيمة كحقل code   و حفل
            cmb_RolePermission.DataSource = dbprovider.LoadRoleTable();
            cmb_RolePermission.ValueMember = dbprovider.LoadRoleTable().Columns[2].ToString();
            cmb_RolePermission.DisplayMember = dbprovider.LoadRoleTable().Columns[1].ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void واجهة_صلاحية_كل_منصب_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting.IsClosingUserPer = true;
        }
        //select Role Load Permission
        //جديد user ولكن بدي لما أعمل
        //نسخة و يعطيه ياها permission يعمل من ال 
        //لذا نعمل ميثود و نستخدمها لمرة واحدة تحوي السماحيات بكل مشروعي من أزرار و واجهات و صندوق صورة
    }
}

