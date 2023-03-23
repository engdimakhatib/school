using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
   public class Category
    {
        public static dbHelper dbhelper = new dbHelper();

        public static DataTable MyTableCategory;
        public static int idStudyYear;
        public int id;
        public static Boolean IsClosing = true;
        public void InsertCategory(string NameCategory, int idStudyYear)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@NameCategory", NameCategory);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);

            MyComm.ExecuteNonQuery();

        }

        public DataTable SelectCategory(int idStudyYear)
        {
            MyTableCategory = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);

            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyAdapter.Fill(MyTableCategory);


            dbhelper.closeDbConnection();
            return MyTableCategory;
        }
        public void DeleteCategory(int id)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);

            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
    }
}
