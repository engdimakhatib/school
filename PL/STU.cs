using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
  public   class STU
    {
        public static Boolean IsClosing = false;
        public static  DataTable MyTable ;

        public static int i;
        public static int x;
        public int id;
        public string FirstName;
        public string LastName;
        public string DadName;
        public string MomName;
        public string DateBirthday;
        public bool isLoad = false;
        public bool isShowRecord = false;
        public bool isDoubleClick = false;

        public string PlaceBirthday;
        public string DateRegistration;
        public string Sum ;
        public string Notes = "";
        public static int idStudyYear;
        public string Address;
        public int IdClass=-1;
        public int IsMove = 0;
        public string NameClass;
        public string PhoneNum ;
        public string NumExam;
        public byte[] img;
        public List<string> StuInfo ;

        public DataTable STUDetailsInfo;

       
           public static dbHelper dbhelper = new dbHelper();
        public List<string> InsertSTU(string FirstName, string LastName, string DadName, string MomName, string DateBirthday, string PlaceBirthday, string DateRegistration, string Sum, string Notes, int idStudyYear, string Address, int IdClass, string NameClass, string PhoneNum, string NumExam,byte[] stu_img)
        {
            StuInfo = new List<string>();
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertSTU";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@FirstName", FirstName);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@LastName", LastName);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@DadName", DadName);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@MomName", MomName);
            MyComm.Parameters.Add(param4);
            MyComm.Parameters.Add(new SqlParameter("@DateBirthday", SqlDbType.Date)).Value = DateBirthday;
            SqlParameter param6 = new SqlParameter("@PlaceBirthday", PlaceBirthday);
            MyComm.Parameters.Add(param6);
            SqlParameter param7 = new SqlParameter("@DateRegistration", DateRegistration);
            MyComm.Parameters.Add(param7);
            SqlParameter param8 = new SqlParameter("@Sum", Sum);
            MyComm.Parameters.Add(param8);
            SqlParameter param9 = new SqlParameter("@Notes", Notes);
            MyComm.Parameters.Add(param9);
            SqlParameter param10 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param10);
            SqlParameter param11 = new SqlParameter("@Address", Address);
            MyComm.Parameters.Add(param11);
            SqlParameter param12 = new SqlParameter("@IdClass", IdClass);
            MyComm.Parameters.Add(param12);          
            SqlParameter param13= new SqlParameter("@NameClass", NameClass);
            MyComm.Parameters.Add(param13);
            SqlParameter param14 = new SqlParameter("@PhoneNum", PhoneNum);
            MyComm.Parameters.Add(param14);
         
            SqlParameter param15 = new SqlParameter("@NumExam", NumExam);
            MyComm.Parameters.Add(param15);
            SqlParameter param16;
            if (stu_img != null)
            { param16 = new SqlParameter("@STU_Image", stu_img); }
            else
            { param16 = new SqlParameter("@STU_Image", DBNull.Value); }
            MyComm.Parameters.Add(param16);

            SqlParameter OutPutParameter1 = new SqlParameter("@IDOUT", SqlDbType.Int);
          
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);

            SqlParameter OutPutParameter2 = new SqlParameter("@NumTotalSTU", SqlDbType.Int);
    
            OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter2);

            SqlParameter OutPutParameter3 = new SqlParameter("@NumStuClass", SqlDbType.Int);
           
            OutPutParameter3.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter3);

            MyComm.ExecuteNonQuery();

        
            string IDOUT;
            string NumTotalSTU;

            string NumStuClass;
            if (OutPutParameter1.Value == null)
                IDOUT = "";
            else IDOUT = OutPutParameter1.Value.ToString();

            if (OutPutParameter2.Value == null)
                NumTotalSTU = "";
            else NumTotalSTU = OutPutParameter2.Value.ToString();

            if (OutPutParameter3.Value == null)
                NumStuClass = "";
            else NumStuClass = OutPutParameter3.Value.ToString();

            StuInfo.Add(IDOUT);
            StuInfo.Add(NumTotalSTU);
            StuInfo.Add(NumStuClass);

            dbhelper.closeDbConnection();
            return StuInfo;
        }
        public void UpdateSTU(string FirstName, string LastName, string DadName, string MomName, string DateBirthday, string PlaceBirthday, string DateRegistration, string Sum, string Notes, int idStudyYear, string Address, int IdClass,int IsMove, string NameClass, string PhoneNum, string NumExam, byte[] stu_img,int id)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "UpdateSTU";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@FirstName", FirstName);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@LastName", LastName);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@DadName", DadName);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@MomName", MomName);
            MyComm.Parameters.Add(param4);
            MyComm.Parameters.Add(new SqlParameter("@DateBirthday", SqlDbType.Date)).Value = DateBirthday;
            SqlParameter param6 = new SqlParameter("@PlaceBirthday", PlaceBirthday);
            MyComm.Parameters.Add(param6);
            SqlParameter param7 = new SqlParameter("@DateRegistration", DateRegistration);
            MyComm.Parameters.Add(param7);
            SqlParameter param8 = new SqlParameter("@Sum", Sum);
            MyComm.Parameters.Add(param8);
            SqlParameter param9 = new SqlParameter("@Notes", Notes);
            MyComm.Parameters.Add(param9);
            SqlParameter param10 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param10);
            SqlParameter param11 = new SqlParameter("@Address", Address);
            MyComm.Parameters.Add(param11);
            SqlParameter param12 = new SqlParameter("@IdClass", IdClass);
            MyComm.Parameters.Add(param12);
            SqlParameter param13 = new SqlParameter("@IsMove", IsMove);
            MyComm.Parameters.Add(param13);
            SqlParameter param14= new SqlParameter("@NameClass", NameClass);
            MyComm.Parameters.Add(param14);
            SqlParameter param15 = new SqlParameter("@PhoneNum", PhoneNum);
            MyComm.Parameters.Add(param15);
         
            SqlParameter param16 = new SqlParameter("@NumExam", NumExam);
            MyComm.Parameters.Add(param16);
            SqlParameter param17;
            if (stu_img != null)
            {
                param17= new SqlParameter("@STU_Image", stu_img);
            }
            else
            {
                param17 = new SqlParameter("@STU_Image", DBNull.Value);

            }
            MyComm.Parameters.Add(param17);
            SqlParameter param18 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param18);
            MyComm.ExecuteNonQuery();  
            dbhelper.closeDbConnection();
          
        }
        public DataTable SelectStu(int idClass ,int idStudyYear)
        {
            MyTable = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectStu";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            MyComm.ExecuteScalar();
           SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyAdapter.Fill(MyTable);
            dbhelper.closeDbConnection();
            return MyTable;
        }
        public DataTable SearchStu( int idStudyYear ,string Search)
        {
            DataTable dt = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SearchStu";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@Search", Search);
            MyComm.Parameters.Add(param2);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            //dt.Clear();
            MyAdapter.Fill(dt);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return dt;
        }
        public List<string> DeleteStu(int id, int idStudyYear,int idClass)
        {
            StuInfo = new List<string>();
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteStu";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@ID", id);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param3);
           

            SqlParameter OutPutParameter1 = new SqlParameter();
            OutPutParameter1.ParameterName = "@NumTotalSTU";
            OutPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);

            SqlParameter OutPutParameter2 = new SqlParameter();
            OutPutParameter2.ParameterName = "@NumStuClass";
            OutPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter2);

            MyComm.ExecuteNonQuery();

        string NumTotalSTU;

            string NumStuClass;
           

            if (OutPutParameter1.Value == null)
                NumTotalSTU = "";
            else NumTotalSTU = OutPutParameter1.Value.ToString();

            if (OutPutParameter2.Value == null)
                NumStuClass = "";
            else NumStuClass = OutPutParameter2.Value.ToString();

           
            StuInfo.Add(NumTotalSTU);
            StuInfo.Add(NumStuClass);
            dbhelper.closeDbConnection();
            return StuInfo;

        }
        public void DeleteStuForSortCategory(int idStu)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteStuForSortCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
        public void DeleteStuForSortDivision(int idStu)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteStuForSortDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
           
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
        public DataTable selectSTUimg(int id)
        {
            DataTable dt = new DataTable();

            dt = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "selectSTUimg";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);
          
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            dt.Clear();
            MyAdapter.Fill(dt);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return dt;
        }

        
             public DataTable LoadSTUInfoMethod(int idStudyYear, int idClass)
        {
            STUDetailsInfo = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "LoadSTUInfoMethod";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
   
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            STUDetailsInfo.Clear();
            MyAdapter.Fill(STUDetailsInfo);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return STUDetailsInfo;
        }
    }
}
