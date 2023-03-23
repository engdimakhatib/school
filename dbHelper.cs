using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace MYSCHOOLFINAL
{
    public class dbHelper
    {
        static string sql = "Data Source=LAPTOP-G3VSBFBH\\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";
        SqlConnection con = new SqlConnection(sql);
        /*return DB connection*/
        public SqlConnection GetdbConnection()
        {
            return con;
        }
        /*open connection*/
        public void OpenDBConnection()
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
        }
        /*close connection*/
        public void closeDbConnection()
        {
            con.Close();
        }
    }

}
