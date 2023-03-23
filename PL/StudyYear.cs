using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public class StudyYear
    {
        public static dbHelper dbhelper = new dbHelper();
        public DataTable MyTable;
        public DataTable MyTableHoliday;
        public static  int YearID;
        public Boolean NotFound = false;
        public string IsLoadYear = "0";
        public  static  string BeginStudyYear="-1";
        public static string EndStudyYear = "-1";
        public int idHoliday;
        public static Boolean  IsClosingYear=false ;
        public static Boolean IsClosingHoliday = false;
        public int InsertandGetStudyYearIdName(string NameYear, string EndStudyYear, string AcceptStu, string BeginTerm1, string ExamTerm1, string TheRecess, string BeginSecondTerm, string BeginSecondExam, string paracticalExam, int NumDaySeason1, int NumDaySeason2, int NumActuallWeek, string Notes, string IsLoadYear)
        {
            dbhelper.OpenDBConnection();

            string MyQuery2 = "InsertStudyYearName";

            SqlCommand MyComm2 = new SqlCommand(MyQuery2, dbhelper.GetdbConnection());     
            MyComm2.CommandType = System.Data.CommandType.StoredProcedure;        
                SqlParameter param1 = new SqlParameter("@NameYear", NameYear);
                MyComm2.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@EndStudyYear", EndStudyYear);
                MyComm2.Parameters.Add(param2);

                MyComm2.Parameters.Add(new SqlParameter("@AcceptStu", SqlDbType.Date)).Value = AcceptStu;
                MyComm2.Parameters.Add(new SqlParameter("@BeginTerm1", SqlDbType.Date)).Value = BeginTerm1;
                MyComm2.Parameters.Add(new SqlParameter("@ExamTerm1", SqlDbType.Date)).Value = ExamTerm1;
                MyComm2.Parameters.Add(new SqlParameter("@TheRecess", SqlDbType.Date)).Value = TheRecess;
                MyComm2.Parameters.Add(new SqlParameter("@BeginSecondTerm", SqlDbType.Date)).Value = BeginSecondTerm;
                MyComm2.Parameters.Add(new SqlParameter("@BeginSecondExam", SqlDbType.Date)).Value = BeginSecondExam;
                MyComm2.Parameters.Add(new SqlParameter("@paracticalExam", SqlDbType.Date)).Value = paracticalExam;


                SqlParameter param10 = new SqlParameter("@NumDaySeason1", NumDaySeason1);
                MyComm2.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@NumDaySeason2", NumDaySeason2);
                MyComm2.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@NumActuallWeek", NumActuallWeek);
                MyComm2.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@Notes", Notes);
                MyComm2.Parameters.Add(param13);
                SqlParameter param14 = new SqlParameter("@IsLoadYear", IsLoadYear);
                MyComm2.Parameters.Add(param14);

                MyComm2.ExecuteNonQuery();
            string MyQuery = "dbo.SelectStudyYearID";

            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());

            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@NameYear", NameYear);
                MyComm.Parameters.Add(param);
                SqlParameter OutPutParameter = new SqlParameter();
                OutPutParameter.ParameterName = "@ID";
                OutPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                OutPutParameter.Direction = System.Data.ParameterDirection.Output;
                MyComm.Parameters.Add(OutPutParameter);

                MyComm.ExecuteScalar();

                string i = OutPutParameter.Value.ToString();

                int id = int.Parse(i);
            MyComm.Parameters.Clear();
            dbhelper.closeDbConnection();
            return id;
            
          
        }
        public int SelectStudyYearID(string NameYear)
        {
            dbhelper.OpenDBConnection();
            int id = -1;
            string MyQuery1 = "SelectStudyYearID";
            SqlCommand MyComm1 = new SqlCommand(MyQuery1, dbhelper.GetdbConnection());
            MyComm1.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@NameYear", NameYear);
            MyComm1.Parameters.Add(param1);

            SqlParameter OutPutParameter = new SqlParameter();
            OutPutParameter.ParameterName = "@ID";
            OutPutParameter.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter.Direction = System.Data.ParameterDirection.Output;
            MyComm1.Parameters.Add(OutPutParameter);

            MyComm1.ExecuteScalar();

            string i = OutPutParameter.Value.ToString();
            if (i == "")
                id = -1;
            else id = int.Parse(i);
            dbhelper.closeDbConnection();
            return id;

        }
  

        public Boolean EnabledForm(string NameYear, string EndStudyYear)
        {
            Boolean year = true;
            //السنة غير موجودة
            if (SelectStudyYearID(NameYear) == -1)


                year = false;
            //السنة المفحوصة ليست السنة الحالية
            // else if (!(NameYear == DateTime.Now.Year.ToString() || (EndStudyYear == DateTime.Now.Year.ToString())))

            //     year = false;




            return year;
        }
        public DataTable LoadStudyYearHoliday(int id)
        {
            MyTable = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "LoadStudyYearHoliday";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTable.Clear();
            MyAdapter.Fill(MyTable);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTable;
        }
        public DataTable SelectHoliday(int idStudyYear)
        {
            MyTableHoliday = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectHoliday";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableHoliday.Clear();
            MyAdapter.Fill(MyTableHoliday);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableHoliday;
        }

        public void InsertHoliday(string NameHoliday, int idStudyYear, string Duration, string Date)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertHoliday";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            try
            {
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter("@NameHoliday", NameHoliday);
                MyComm.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
                MyComm.Parameters.Add(param2);

                SqlParameter param3 = new SqlParameter("@Duration", Duration);
                MyComm.Parameters.Add(param3);

                MyComm.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)).Value = Date;
                MyComm.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                MyComm.Parameters.Clear();
                dbhelper.closeDbConnection();
                
            }
          
        }
        public void UpdateHoliday(int id, string NameHoliday, string Duration, string Date)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "updateHoliday";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            try
            {
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param1= new SqlParameter("@id", id);
                MyComm.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@NameHoliday", NameHoliday);
                MyComm.Parameters.Add(param2);

             

                SqlParameter param3 = new SqlParameter("@Duration", Duration);
                MyComm.Parameters.Add(param3);

                MyComm.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)).Value = Date;
                MyComm.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally
            {
                MyComm.Parameters.Clear();
                dbhelper.closeDbConnection();

            }

        }
        public void DeleteStudyYear(int id)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteStudyYear";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@id", id);
                MyComm.Parameters.Add(param1);
                MyComm.ExecuteNonQuery();
            }
            catch { return; }
            finally{
                MyComm.Parameters.Clear();
                dbhelper.closeDbConnection();
            }
           
        }
        public void DeleteHoliday(int id)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteHoliday";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            try
            {
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@id", id);
                MyComm.Parameters.Add(param1);
                MyComm.ExecuteNonQuery();
            }
            catch
            {
                return;
            }

            finally {
                MyComm.Parameters.Clear();
                dbhelper.closeDbConnection();
            }
           
        }
        public void DeleteHolidayStudyYear(int idStudyYear)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteHolidayStudyYear";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
                MyComm.Parameters.Add(param1);
                MyComm.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            finally {
                dbhelper.closeDbConnection();
                MyComm.Parameters.Clear();
            }
          
        }
        public void UpdateStudyYear(int id, string NameYear, string EndStudyYear, string AcceptStu, string BeginTerm1, string ExamTerm1, string TheRecess, string BeginSecondTerm, string BeginSecondExam, string paracticalExam, int NumDaySeason1, int NumDaySeason2, int NumActuallWeek, string Notes)
        {
            dbhelper.OpenDBConnection();

            string MyQuery2 = "UpdateStudyYear";
            SqlCommand MyComm = new SqlCommand(MyQuery2, dbhelper.GetdbConnection());

            try
            {
             
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param0 = new SqlParameter("@id", id);
                MyComm.Parameters.Add(param0);

                SqlParameter param1 = new SqlParameter("@NameYear", NameYear);
                MyComm.Parameters.Add(param1);

                SqlParameter param2 = new SqlParameter("@EndStudyYear", EndStudyYear);
                MyComm.Parameters.Add(param2);

                MyComm.Parameters.Add(new SqlParameter("@AcceptStu", SqlDbType.Date)).Value = AcceptStu;
                MyComm.Parameters.Add(new SqlParameter("@BeginTerm1", SqlDbType.Date)).Value = BeginTerm1;
                MyComm.Parameters.Add(new SqlParameter("@ExamTerm1", SqlDbType.Date)).Value = ExamTerm1;
                MyComm.Parameters.Add(new SqlParameter("@TheRecess", SqlDbType.Date)).Value = TheRecess;
                MyComm.Parameters.Add(new SqlParameter("@BeginSecondTerm", SqlDbType.Date)).Value = BeginSecondTerm;
                MyComm.Parameters.Add(new SqlParameter("@BeginSecondExam", SqlDbType.Date)).Value = BeginSecondExam;
                MyComm.Parameters.Add(new SqlParameter("@paracticalExam", SqlDbType.Date)).Value = paracticalExam;

                SqlParameter param10 = new SqlParameter("@NumDaySeason1", NumDaySeason1);
                MyComm.Parameters.Add(param10);

                SqlParameter param11 = new SqlParameter("@NumDaySeason2", NumDaySeason2);
                MyComm.Parameters.Add(param11);

                SqlParameter param12 = new SqlParameter("@NumActuallWeek", NumActuallWeek);
                MyComm.Parameters.Add(param12);

                SqlParameter param13 = new SqlParameter("@Notes", Notes);
                MyComm.Parameters.Add(param13);


                MyComm.ExecuteNonQuery();
            }
            catch { }
            finally {
                MyComm.Parameters.Clear();
                dbhelper.closeDbConnection();
               
            }
        

        }
       
    }
}
