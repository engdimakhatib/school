using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MYSCHOOLFINAL.PL
{
    //جزء خاص بالعلامات
    public class StuMark
    {
   
        public int IdClass = 1;
        public string NameClass = "";
        public int idStu;
        public int SubjectId;
        public int DivisionId;
        public int CategoryId;
        public int idExam;
        public int idSeason;
        public DateTime BeginExam;
        public DateTime EndExam;
        public int idHall;
        public float mark;
        public Boolean ThisClicked = true;
        public Boolean IsLoad = false;
        public static dbHelper dbhelper = new dbHelper();
        public List<string> SubjectEMP = new List<string>();
      public   byte[] FileAttachement=null;
        public string FileName=null;
        public string FileType=null;
        public string SelectTypeSubject( int idSubject)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectTypeSubject";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idSubject", idSubject);
            MyComm.Parameters.Add(param1);
            SqlParameter OutPutParameter1 = new SqlParameter("@TypeSubject", SqlDbType.NVarChar, 1000);
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);
            MyComm.ExecuteScalar();
            string TypeSubject;
           TypeSubject = OutPutParameter1.Value.ToString();
            dbhelper.closeDbConnection();
            return TypeSubject.Trim();
        }
     
        public List<string> ShowEmpSubject(int idSubject)
        {
            SubjectEMP.Clear();
        dbhelper.OpenDBConnection();
            string MyQuery = "ShowEmpSubject";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idSubject", idSubject);
            MyComm.Parameters.Add(param1);
            SubjectEMP = new List<string>();
        SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                //   MyTableExam.Add(Convert.ToInt32(MyReader["id"]));
                SubjectEMP.Add(MyReader["name"].ToString());
            }
            dbhelper.closeDbConnection();
            return SubjectEMP;
        }

        public byte[] SelectFileQuestion(int idStu,int idExam,int idSubject, int idSeason,int idStudyyear)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectFileQuestion";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);

            SqlParameter param5 = new SqlParameter("@idExam", idExam);
            MyComm.Parameters.Add(param5);
            SqlParameter param2 = new SqlParameter("@idSubject", idSubject);
            MyComm.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter("@idSeason", idSeason);
            MyComm.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter("@idStudyyear", idStudyyear);
            MyComm.Parameters.Add(param4);

            SqlParameter OutPutParameter1 = new SqlParameter("@FileAttachement", SqlDbType.VarBinary);
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);
            MyComm.ExecuteScalar();
            byte[] FileAttachement;
            FileAttachement = (byte[])OutPutParameter1.Value;
            dbhelper.closeDbConnection();
            return FileAttachement;      }
    }
}
