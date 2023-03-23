using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL.PL
{
    class Permission
    {

        public static dbHelper dbhelper = new dbHelper();
        
        //اجرائية السماحيات الافتراضية  و لا شي مفعل
        public void LoadDefaultPermission(Form form)
        {
            foreach (var btn in form.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }

        }
        //   form-->btn
        //form-->MenuStrip-->Items(Admin)-->ToolsStrip
        public void LoadEMPtPer(Form form)
        {
            foreach (var btn in form.Controls.OfType<MenuStrip>())
            {
                //Get Array in TabControl In Form
                //var TCs = form.Controls.OfType<TabControl>();
                //  TCs.ElementAt(0).TabPages[0]. 
                var MSs = form.Controls.OfType<MenuStrip>();
                MSs.ElementAt(0).Items[0].Enabled = true;
                //نفعل القائمة وعناصرها ذو الدليل المذكور و نلغي تفعيل كل شيء اّخر
                for (int i = 0; i < MSs.ElementAt(0).Items.Count; i++)
                {
                    if (i != 0)
                    {
                        MSs.ElementAt(0).Items[i].Enabled = false;
                    }
                }
            }
        }
        // نحتاج ميثود ترجع لنا أسماء الفورم في مشروعنا لاستخدامها 
        //nodes
        //treeview في
        //FormName-->List
        //و ميثود ثانية تعيد أسماء العناصر في كل فورم بدلالة اسم الفورم
        //Item In Form(FormName)-->DatatTable//compelete permission table لأول مرة
        /***********الميثود الأولى التي تعيد أسماء الفورم في لائحة********/
        public List<string> GetFormsNames()
        {
            List<string> formsNames = new List<string>();
            Assembly myproject = Assembly.Load("MYSCHOOLFINAL");
            foreach (Type t in myproject.GetTypes())
            {
                if (t.BaseType == typeof(Form))
                {
                    formsNames.Add(t.Name);
                }
            }
            return formsNames;
        }
        /**********الميثود الثانية التي تعيد جدول فيه كل ما هو تحت الفورم*********/
        public DataTable LoadformItemsNamesDT(String FormName)
     {
            //مررنا الفورم كنص وليس كفورم
            //ويجيب منها الفورم الشغّالة Assembly ياخد ال
            //ويبدأ يدور فيها لو النوع فورم و الاسم هو الاسم اللي أنا عطيتو ياه
            //يجبلي الناتج اللي إلها
            var formType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => a.BaseType == typeof(Form) && a.GetTypeInfo().Name == FormName)
                .FirstOrDefault();

            //ويشغّلها Activation رح يعرف قورم و يعملها
            Form f = (Form)Activator.CreateInstance(formType);

            DataTable formsItem = new DataTable();
            formsItem.Columns.Add("f.Name");
            formsItem.Columns.Add("name");
            formsItem.Columns.Add("Text");
            formsItem.Columns.Add("mType");
            // var MS=f.Controls.OfType<MenuStrip >();
            // MenuStrip وجد
            // if (MS.Count() > 0)
            // {
            // Name,Text,Type رح نلف على العناصر اللي جواها و نبدأ نجيب
            //  for(int i=0;i<MS.ElementAt(0).Items.Count;i++)
            ///  {
            //    string name = MS.ElementAt(0).Items[i].Name;
            //    string Text = MS.ElementAt(0).Items[i].Text ;
            //   string mType = MS.ElementAt(0).Items[i].GetType().ToString();
            //formsName.Add(Text)
            //permission مشان نحطهن في ال   f.Name,name رج نرجع هالسطر و اللي رح يلزمنا
            //  formsItem.Rows.Add(f.Name,name,Text,mType );

            //  }
            // }

         //   List<Control> controls =


           
         //var   BTN= f.Controls.OfType<Button>());
           
         //   if (BTN.Count() > 0)
         //   {
         //       // Name,Text,Type رح نلف على العناصر اللي جواها و نبدأ نجيب
         //       //f.Name  form name
         //       //name : items name in form
         //       for (int i = 0; i < BTN.Count(); i++)
         //       {
         //           String name = BTN.ElementAt(i).Name;
         //           String Text = BTN.ElementAt(i).Text;
         //           String mType = BTN.ElementAt(i).GetType().ToString();
         //           //رح نضيف سطر كمان فيه أسماء الأزرار اللي لاقيناها
         //           formsItem.Rows.Add(f.Name, name, Text, mType);

         //       }
         //   }

         //   var PB = f.Controls.OfType<PictureBox>();
         //   if (PB.Count() > 0)
         //   {
         //       // Name,Text,Type رح نلف على العناصر اللي جواها و نبدأ نجيب
         //       for (int i = 0; i < PB.Count(); i++)
         //       {
         //           String name = PB.ElementAt(i).Name;
         //           String Text = PB.ElementAt(i).Tag.ToString();
         //           String mType = PB.ElementAt(i).GetType().ToString();
         //           //رح نضيف سطر كمان فيه أسماء الأزرار اللي لاقيناها
         //           formsItem.Rows.Add(f.Name, name, Text, mType);

         //       }
         //   }
            var c = GetAll(f, typeof(Button));
            if (c.Count() > 0)
            {
                // Name,Text,Type رح نلف على العناصر اللي جواها و نبدأ نجيب
                //f.Name  form name
                //name : items name in form
                for (int i = 0; i < c.Count(); i++)
                {
                    String name = c.ElementAt(i).Name;
                    String Text = c.ElementAt(i).Text;
                    String mType = c.ElementAt(i).GetType().ToString();
                    //رح نضيف سطر كمان فيه أسماء الأزرار اللي لاقيناها
                    formsItem.Rows.Add(f.Name, name, Text, mType);

                }
            }
            var p = GetAll(f, typeof(PictureBox));
            if (p.Count() > 0)
            {
                // Name,Text,Type رح نلف على العناصر اللي جواها و نبدأ نجيب
                //f.Name  form name
                //name : items name in form
                for (int i = 0; i < p.Count(); i++)
                {
                    String name = p.ElementAt(i).Name;
                    String Text = p.ElementAt(i).Text;
                    String mType = p.ElementAt(i).GetType().ToString();
                    //رح نضيف سطر كمان فيه أسماء الأزرار اللي لاقيناها
                    formsItem.Rows.Add(f.Name, name, Text, mType);

                }
            }

            return formsItem;
            // لفينا على الفورم 
            //رح نرجعها  menustrip,button,tabcontrol  إذا لاقينا    
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        //Apply permission on Current form
        //DB لما افتح أي فورم رح تاخد اسم الرول و المستخدم اللي فاتح فيه و رح تطبق عليه السماحيات المسجلة بال 
        // اللي داخل user بدنا نعرف الشغلات اللمحددة لل 
        public void RetrievePermissionRole(string Role, Form form)
        {
            dbhelper.OpenDBConnection();


            string query = "select  permission_tbl.per_id,permission_tbl.per_name,permission_tbl.per_form,role_permission_tbl.role_code,role_permission_tbl.per_id as Expr1,role_permission_tbl.user_select from  permission_tbl inner join role_permission_tbl on permission_tbl.per_id=role_permission_tbl.per_id where permission_tbl.per_form='" + form + "'and role_permission_tbl.role_code='" + Role + "' ";
            SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
            //النتيجة عبارة عن أسماء الأزرار و الأشياء الموجودة في الفورم
            //وكل زر رح حددله ماذا سيحصل معه بناء على اسم الرول المعطاة
            DataTable datatable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(mycommand);
            da.Fill(datatable);
            da.Dispose();

            dbhelper.closeDbConnection();
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                //true اللي إلها واحد نعملها   select و  datatable و اسمها هو الاسم المسجل عندي بال  menustrip  إذا كان العنصر    
                foreach (var MS in form.Controls.OfType<MenuStrip>())
                {
                    if (MS.Items[i].Name == datatable.Rows[i][1].ToString())
                    {
                        if (datatable.Rows[i][5].ToString().Equals("1"))
                        {
                            MS.Items[i].Enabled = true;
                        }
                        else
                        {
                            MS.Items[i].Enabled = false;
                        }
                    }
                }
            }
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                //true اللي إلها واحد نعملها   select و  datatable و اسمها هو الاسم المسجل عندي بال  menustrip  إذا كان العنصر    
                foreach (var BTN in form.Controls.OfType<Button>())
                {
                    if (BTN.Name == datatable.Rows[i][1].ToString())
                    {
                        if (datatable.Rows[i][5].ToString().Equals("1"))
                        {
                            BTN.Enabled = true;
                        }
                        else
                        {
                            BTN.Enabled = false;
                        }
                    }
                }
            }
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                //true اللي إلها واحد نعملها   select و  datatable و اسمها هو الاسم المسجل عندي بال  menustrip  إذا كان العنصر    
                foreach (var PB in form.Controls.OfType<PictureBox>())
                {
                    if (PB.Name == datatable.Rows[i][1].ToString())
                    {
                        if (datatable.Rows[i][5].ToString().Equals("1"))
                        {
                            PB.Enabled = true;
                        }
                        else
                        {
                            PB.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}
