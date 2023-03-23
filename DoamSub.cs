using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MYSCHOOLFINAL
{
  public  class DoamSub
    {
        public static dbHelper dbhelper = new dbHelper();
        public static List<int> IdWeeks = new List<int>();
        public static List<int> IdLectures = new List<int>();

        public static Boolean IsClosing = false;
        public int idClass;
        public int idDivision;
        public int idCategory;



        //  أيام الأسبوعid  لإعادة
        public void ShowDoamWeek()
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowDoamWeek";

            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            MyComm.ExecuteNonQuery();
            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdWeeks.Add(Convert.ToInt32(MyReader["id"]));

            }
            dbhelper.closeDbConnection();
        }
        //إظهار حصص هذا العام وفق التوقيت الشتوي لتوزيع المواد على الحصص 
        public int ShowDoamLecture(int idStudyYear)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowDoamLecture";

            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);

            MyComm.ExecuteNonQuery();
            SqlDataReader MyReader = MyComm.ExecuteReader();

            while (MyReader.Read())
            {
                IdLectures.Add(Convert.ToInt32(MyReader["id"]));

            }
            dbhelper.closeDbConnection();
            return IdLectures.Count;

        }



    }
}
