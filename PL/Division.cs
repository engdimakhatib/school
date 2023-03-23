using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
 public    class Division
    {

        public static dbHelper dbhelper = new dbHelper();
        public static int NumTotalDivision;
        public static DataTable  MyTableDivision;
        public static int idStudyYear;
        public int id;
        public static Boolean IsClosing = true;
        public void InsertDivision(string NameDivision,int idStudyYear)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@NameDivision", NameDivision);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
           
            MyComm.ExecuteNonQuery();
           
        }

        public DataTable SelectDivision(int idStudyYear)
        {
            MyTableDivision = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
          
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyAdapter.Fill(MyTableDivision);


            dbhelper.closeDbConnection();
            return MyTableDivision;
        }
        public void DeleteDivision(int id)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);

            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
    }
}
