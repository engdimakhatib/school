using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL.PL
{
   
     public   class DbProvider
        {
            public dbHelper dbhelper = new dbHelper();
            //  AddNewUser
            public void InsertNewUser(string txtuser_name, string txtuser_pass, string cmb_userrole)
            {
                dbhelper.OpenDBConnection();
                string query = "insert into user_tbl(user_name,user_pass,user_role)";
                query += "values (@user_name,@user_pass,@user_role)";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@user_name", txtuser_name);
                mycommand.Parameters.AddWithValue("@user_pass", txtuser_pass);
                mycommand.Parameters.AddWithValue("@user_role", cmb_userrole);
                mycommand.ExecuteNonQuery();
                dbhelper.closeDbConnection();
            }

            public DataTable LoadUserTable()
            {
                dbhelper.OpenDBConnection();

                string query = "select user_id,user_name as 'اسم المستخدم',user_pass as 'كلمة المرور' ,user_role as 'المنصب' from user_tbl";

                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            public void UpdateCurrentUsers(string user_id, string txtuser_name, string txtuser_pass, string cmb_userrole)
            {

                dbhelper.OpenDBConnection();

                string query = "update user_tbl set user_name=@user_name,user_pass=@user_pass,user_role=@user_role where user_id=" + user_id + "";


                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@user_name", txtuser_name);
                mycommand.Parameters.AddWithValue("@user_pass", txtuser_pass);
                mycommand.Parameters.AddWithValue("@user_role", cmb_userrole);
                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();


            }
            public void DeleteCurrentUser(string user_id)
            {
                try
                {
                    dbhelper.OpenDBConnection();

                    string query = "delete from user_tbl where user_id=" + user_id + "";


                    SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                    mycommand.ExecuteNonQuery();

                    dbhelper.closeDbConnection();
                }
                catch
                {

                }
            }
            public DataTable SearchUser(string txtuser_search)
            {
                dbhelper.OpenDBConnection();

                string query = "select  user_id,user_name as 'اسم المستخدم',user_pass as 'كلمة المرور' ,user_role as 'المنصب' from user_tbl where  user_name like '%" + txtuser_search + "%'";

                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            //InsertNewRole
            public void InsertNewRole(string txtrole_name, string txtrole_code, string txtrole_Desc)
            {

                dbhelper.OpenDBConnection();

                string query = "insert into role_tbl(role_name,role_code,role_desc)";
                query += "values (@role_name,@role_code,@role_desc)";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@role_name", txtrole_name);
                mycommand.Parameters.AddWithValue("@role_code", txtrole_code);
                mycommand.Parameters.AddWithValue("@role_desc", txtrole_Desc);
                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();

            }

            public void UpdateCurrentRole(string role_id, string txtrole_name, string txtrole_code, string txtrole_Desc)
            {

                dbhelper.OpenDBConnection();

                string query = "update role_tbl set role_name=@role_name,role_code=@role_code,role_desc=@role_desc where role_id=" + role_id + "";


                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@role_name", txtrole_name);
                mycommand.Parameters.AddWithValue("@role_code", txtrole_code);
                mycommand.Parameters.AddWithValue("@role_desc", txtrole_Desc);
                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();


            }
            public void DeleteCurrentRole(string role_id)
            {
                try
                {
                    dbhelper.OpenDBConnection();

                    string query = "delete from  role_tbl where role_id=" + role_id + "";


                    SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                    mycommand.ExecuteNonQuery();

                    dbhelper.closeDbConnection();
                }
                catch
                {

                }
            }
            public DataTable Searchrole(string txtrole_search)
            {
                dbhelper.OpenDBConnection();

                string query = "select  role_id,role_name as 'اسم المنصب',role_code as 'الرمز' ,role_desc as 'الوصف' from   role_tbl where  role_name like '%" + txtrole_search + "%'";

                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            public DataTable LoadRoleTable()
            {
                dbhelper.OpenDBConnection();

                string query = "select role_id,role_name as 'اسم المنصب',role_code as 'الرمز' ,role_desc as 'الوصف' from role_tbl";

                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            /*********************************************************************************************************************/
            /**Insert permission Table**/
            /*********************************************************************************************************************/
            //نمرر له اسم السماحية و اسم الفورم 
            public void InsertAllFormsAndButtons(string per_text, string per_form)
            {
                dbhelper.OpenDBConnection();

                string query = "insert into permission_tbl (per_text,per_form)";
                query += "values(@per_text,@per_form)";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@per_text", per_text);
                mycommand.Parameters.AddWithValue("@per_form", per_form);

                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();
            }

            /*******************************************************************************************************************/
            /*Load permission*/
            public DataTable LoadPermissions()
            {
                dbhelper.OpenDBConnection();

                string query = "select per_id,per_name,per_text ,per_tag,per_assembly,per_form from permission_tbl";

                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            /*********************************************************************************************************************/
            /**Insert permission Role Table**/
            /*********************************************************************************************************************/
            //نمرر له اسم السماحية و اسم الفورم 
            public void InsertInPermissionRole(string role_code, string per_id, string user_select)
            {
                dbhelper.OpenDBConnection();

                string query = "insert into role_permission_tbl (role_code,per_id,user_select)";
                query += "values(@role_code,@per_id,@user_select)";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@role_code", role_code);
                mycommand.Parameters.AddWithValue("@per_id", per_id);
                mycommand.Parameters.AddWithValue("@user_select", user_select);
                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();
            }

            /*******************************************************************************************************************/
            /*Load permission*/
            //رح تحمّل سماحيات عنصر معين
            //AD مثلا أعطيه المدير 
            //وهو يجلب كل سماحياته
            public DataTable LoadPermissionsRole(string role_code)
            {
                dbhelper.OpenDBConnection();

                string RolePer = "role_permission_tbl";
                string query = "select * from " + RolePer + "where role_code=" + RolePer + "";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            public DataTable LoadPermissionsRole(string role_code, string formName)
            {
                dbhelper.OpenDBConnection();


                string query = "select * from role_permission_tbl ,permission_tbl where role_permission_tbl.per_id=permission_tbl.per_id and role_permission_tbl.role_code='" + role_code + "'and permission_tbl.per_form='" + formName + "'";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
            public void UpdatePermissionRole(string role_code, string user_select, string per_id)
            {
                dbhelper.OpenDBConnection();

                string query = "update role_permission_tbl set user_select=@user_select where role_code='" + role_code + "'and  per_id='" + per_id + "'";


                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());
                mycommand.Parameters.AddWithValue("@user_select", user_select);

                mycommand.ExecuteNonQuery();

                dbhelper.closeDbConnection();

            }
            /*check for Password and UserName*/
            public DataTable LoadUseTable(string user_name, string user_pass)
            {

                dbhelper.OpenDBConnection();


                string query = "select * from user_tbl where user_name='" + user_name + "'and user_pass='" + user_pass + "'";
                SqlCommand mycommand = new SqlCommand(query, dbhelper.GetdbConnection());

                DataTable datatable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(mycommand);
                da.Fill(datatable);
                da.Dispose();

                dbhelper.closeDbConnection();
                return datatable;
            }
        }
    }

