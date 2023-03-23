using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
 public    class Exam
    {
        public static dbHelper dbhelper = new dbHelper();

        public static DataTable MyTableExam;
        public static int idStudyYear;
        public int id;
        public static Boolean IsClosing = true;
        public void InsertExam(string NameExam)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertExam";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@NameExam", NameExam);
            MyComm.Parameters.Add(param1);
      

            MyComm.ExecuteNonQuery();

        }

        public DataTable SelectExam()
        {
            MyTableExam = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectExam";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyAdapter.Fill(MyTableExam);


            dbhelper.closeDbConnection();
            return MyTableExam;
        }
        public void DeleteExam(int id)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteExam";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);

            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
    }
}
