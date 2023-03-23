using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public class ClassDivisionCategory
    {
        public static List<string> SotrDivisionInfo;
        public static int idStudyYear;
        public int idClass;
        public int idDivision;
        public int idCategory;
        public int i_Class;
        public int i_Division;
        public int i_Category;

        public string NameClass;
        public float TotalMark;
        public float MinimunMark;

        public string NameDivision;
        public int NumTotalDivision;

        public string NameCategory;
        public static List<int> IdClasses = new List<int>();
        public static List<int> IdDivisiones = new List<int>();
        public static List<int> IdCategories = new List<int>();
        public static List<int> IdSubjects = new List<int>();
        public static List<int> IdSeasons = new List<int>();
        public static List<int> IdHalls = new List<int>();
        public static Boolean IsLoadClassForCategory = false;
        public static Boolean IsLoadDivisionForCategory = false;
        public static List<int>   IdEmpSubject = new List<int>();

        public static Boolean IsLoadClassForDivision = false;
        public static Boolean IsLoadDivisionForDivision = false;

        public static dbHelper dbhelper = new dbHelper();
        public DataTable MyTableClass;
        public DataTable MyTableDivision;
        public DataTable MyTableCategory;


        public DataTable MyTableStudentClassDivision;
        public int StudentDivision;
        public int DivisionDivisionID;

        public List<int> StudentClassDivisionID = new List<int>();
        public List<int> StudentSortDivisionID = new List<int>();
        public DataTable MyTableSortDivision;
        public DataTable MyTableSortDivisionAll;
        public DataTable SortDivisionDetailsInfo;

        public DataTable MyTableStudentClassCategory;
        public DataTable MyTableSortCategory;
        public DataTable MyTableSortCategoryAll;
        public int CategoryCategoryID;
        public int StudentCategoryID;
        public int DivisionCategoryID;
        public List<int> StudentClassCategoryID = new List<int>();
        public List<int> StudentSortCategory = new List<int>();
        public static void ShowCustomClass(System.Windows.Forms.ComboBox o)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectClass";

            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;


            MyComm.ExecuteNonQuery();
            SqlDataReader MyReader = MyComm.ExecuteReader();

            while (MyReader.Read() && !(MyReader["NameClass"].ToString().Trim() == "مشترك"))
            {
                IdClasses.Add(Convert.ToInt32(MyReader["id"]));
                o.Items.Add(MyReader["NameClass"].ToString());

            }
            dbhelper.closeDbConnection();
        }

        public static void ShowCustomDivision(System.Windows.Forms.ComboBox o, int idStudyYear)
        {
            IdDivisiones = null;
            IdDivisiones = new List<int>();
            o.DataSource = null;
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdDivisiones.Add(Convert.ToInt32(MyReader["id"]));

                o.Items.Add(MyReader["NameDivision"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void ShowCustomSelectDivisionForThisClass(System.Windows.Forms.ComboBox o, int idStudyYear,int idClass)
        {
            IdDivisiones = null;
            IdDivisiones = new List<int>();
            o.DataSource = null;
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectDivisionForThisClass";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdDivisiones.Add(Convert.ToInt32(MyReader["idDivision"]));

                o.Items.Add(MyReader["NameDivision"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void SelectDivisionForThisClass(System.Windows.Forms.ComboBox o, int idStudyYear,int idClass)
        {
            IdDivisiones = null;
            IdDivisiones = new List<int>();
            o.DataSource = null;
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectDivisionForThisClass";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdDivisiones.Add(Convert.ToInt32(MyReader["id"]));

                o.Items.Add(MyReader["NameDivision"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void ShowCustomCategory(System.Windows.Forms.ComboBox o, int idStudyYear)
        {
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlDataReader MyReader = MyComm.ExecuteReader();

            while (MyReader.Read())
            {
                IdCategories.Add(Convert.ToInt32(MyReader["id"]));
                o.Items.Add(MyReader["NameCategory"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void SelectCategoryForThisClass(System.Windows.Forms.ComboBox o, int idStudyYear,int idClass,int idDivision)
        {
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectCategoryForThisClass";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param3);
            SqlDataReader MyReader = MyComm.ExecuteReader();

            while (MyReader.Read())
            {
                IdCategories.Add(Convert.ToInt32(MyReader["idCategory"]));
                o.Items.Add(MyReader["NameCategory"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void ShowCustomSubject(System.Windows.Forms.ComboBox o, int idStudyYear, int idClass)
        {
            o.Items.Clear();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectSubject";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdSubjects.Add(Convert.ToInt32(MyReader["id"]));
                o.Items.Add(MyReader["NameSubject"].ToString());

            }
            dbhelper.closeDbConnection();

        }
        public static void ShowEmpSubject(System.Windows.Forms.TextBox o, int idSubject)
        {

            dbhelper.OpenDBConnection();
            string MyQuery = "ShowEmpSubject";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idSubject", idSubject);
            MyComm.Parameters.Add(param1);

            SqlDataReader MyReader = MyComm.ExecuteReader();
            int i = 0;
            while (MyReader.Read())
            {
                 IdEmpSubject.Add(Convert.ToInt32(MyReader["id"]));
                o.Lines[i] = (MyReader["NameSubject"].ToString());
                i++;

            }
            dbhelper.closeDbConnection();

        }
        public static void ShowCustomSeason(System.Windows.Forms.ComboBox o)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectSeason";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
        
            SqlDataReader MyReader = MyComm.ExecuteReader();

            while (MyReader.Read())
            {
                IdSeasons.Add(Convert.ToInt32(MyReader["id"]));
                o.Items.Add(MyReader["NameSeason"].ToString());

            }
            dbhelper.closeDbConnection();
        }
         
        public static void ShowCustomHall(System.Windows.Forms.ComboBox o,int idStudyYear,int idClass)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectHall";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);

            SqlDataReader MyReader = MyComm.ExecuteReader();
            while (MyReader.Read())
            {
                IdHalls.Add(Convert.ToInt32(MyReader["id"]));
                o.Items.Add(MyReader["NameHall"].ToString());
            }
            dbhelper.closeDbConnection();
        }
        public static int ReturnClassIndex(int idClass)
        {
            int i;
            for (i = 0; i < IdClasses.Count; i++)
                if (IdClasses[i] == idClass)
                    break;
            return i;
        }

        public void InsertDivision(string NameDivision, int NumTotalDivision, int idStudyYear)
        {
            dbhelper.OpenDBConnection();


            string MyQuery = "InsertDivision";

            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@NameDivision", NameDivision);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@NumTotalDivision ", NumTotalDivision);
            MyComm.Parameters.Add(param2);


            SqlParameter param3 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param3);
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
       
        public void DeleteDivision(int id, int idStudyYear)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
        public DataTable ShowDivision(int idStudyYear)
        {
            MyTableDivision = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableDivision.Clear();
            MyAdapter.Fill(MyTableDivision);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableDivision;
        }
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
            dbhelper.closeDbConnection();
        }
     
        public void DeleteCategory(int id, int idStudyYear)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@id", id);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
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
            MyTableCategory.Clear();
            MyAdapter.Fill(MyTableCategory);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableCategory;
        }
        //إظهار طلاب الصف الغير مفروزين لشعبة , كي يتم الفرز للشعبة المختارة
        public DataTable SelectStuClassDivision(int IdClass, int idStudyYear)
        {
            MyTableStudentClassDivision = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectStuClassDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@IdClass", IdClass);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableStudentClassDivision.Clear();
            MyAdapter.Fill(MyTableStudentClassDivision);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableStudentClassDivision;
        }
        //إضافة طلاب لشعبة ما
        public List<string> InsertSortDivisionInOneClick(ClassDivisionCategory MyClassDivisionCategory)
        {
       
            dbhelper.OpenDBConnection();

            for (int i = 0; i < MyClassDivisionCategory.StudentClassDivisionID.Count; i++)
            {
                string MyQuery = "InsertSortDivision";
                SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter OutPutParameter1 = new SqlParameter();
                SqlParameter OutPutParameter2 = new SqlParameter();
                SqlParameter OutPutParameter3 = new SqlParameter();
                MyComm.Dispose();

                SqlParameter param1 = new SqlParameter("@idStu", MyClassDivisionCategory.StudentClassDivisionID[i]);
                MyComm.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@idClass", MyClassDivisionCategory.StudentDivision);
                MyComm.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@idStudyYear", ClassDivisionCategory.idStudyYear);
                MyComm.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@idDivision", MyClassDivisionCategory.DivisionDivisionID);
                MyComm.Parameters.Add(param4);

                OutPutParameter1.ParameterName = "@NumStuInDivision";
                OutPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
                OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
                MyComm.Parameters.Add(OutPutParameter1);

                OutPutParameter2.ParameterName = "@NumDivisionClass";
                OutPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
                OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
                MyComm.Parameters.Add(OutPutParameter2);


                OutPutParameter3.ParameterName = "@NumDivision";
                OutPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
                OutPutParameter3.Direction = System.Data.ParameterDirection.Output;
                MyComm.Parameters.Add(OutPutParameter3);


                MyComm.ExecuteNonQuery();


                SotrDivisionInfo = new List<string>();

                string NumStuInDivision;
                string NumDivisionClass;

                string NumDivision;
                if (OutPutParameter1.Value == null)
                    NumStuInDivision = "";
                else NumStuInDivision = OutPutParameter1.Value.ToString();

                if (OutPutParameter2.Value == null)
                    NumDivisionClass = "";
                else NumDivisionClass = OutPutParameter2.Value.ToString();

                if (OutPutParameter3.Value == null)
                    NumDivision = "";
                else NumDivision = OutPutParameter3.Value.ToString();

                SotrDivisionInfo.Add(NumStuInDivision);
                SotrDivisionInfo.Add(NumDivisionClass);
                SotrDivisionInfo.Add(NumDivision);
            }
            dbhelper.closeDbConnection();
            return SotrDivisionInfo;


        }

            public List<string> InsertSortDivision(int idStu, int idClass, int idStudyYear, int idDivision)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertSortDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param4);


            SqlParameter OutPutParameter1 = new SqlParameter();
            OutPutParameter1.ParameterName = "@NumStuInDivision";
            OutPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);

            SqlParameter OutPutParameter2 = new SqlParameter();
            OutPutParameter2.ParameterName = "@NumDivisionClass";
            OutPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter2);

            SqlParameter OutPutParameter3 = new SqlParameter();
            OutPutParameter3.ParameterName = "@NumDivision";
            OutPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter3.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter3);

            MyComm.ExecuteNonQuery();
             
            SotrDivisionInfo = new List<string>();

            string NumStuInDivision;
            string NumDivisionClass;

            string NumDivision;
            if (OutPutParameter1.Value == null)
                NumStuInDivision = "";
            else NumStuInDivision = OutPutParameter1.Value.ToString();

            if (OutPutParameter2.Value == null)
                NumDivisionClass = "";
            else NumDivisionClass = OutPutParameter2.Value.ToString();

            if (OutPutParameter3.Value == null)
                NumDivision = "";
            else NumDivision = OutPutParameter3.Value.ToString();

            SotrDivisionInfo.Add(NumStuInDivision);
            SotrDivisionInfo.Add(NumDivisionClass);
            SotrDivisionInfo.Add(NumDivision);

            dbhelper.closeDbConnection();
            return SotrDivisionInfo;
        }


        public List<string> DeleteSortDivisionInOneClick(ClassDivisionCategory MyClassDivisionCategory)
        {
            dbhelper.OpenDBConnection();

            for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)
            {
                string MyQuery = "DeleteSortDivision";
                SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@idStu", MyClassDivisionCategory.StudentSortDivisionID[i]);
                MyComm.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@idStudyYear", ClassDivisionCategory.idStudyYear);
                MyComm.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@idClass", MyClassDivisionCategory.StudentDivision);
                MyComm.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@idDivision", MyClassDivisionCategory.DivisionDivisionID);
            MyComm.Parameters.Add(param4);


            SqlParameter OutPutParameter1 = new SqlParameter();
            OutPutParameter1.ParameterName = "@NumStuInDivision";
            OutPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);

            SqlParameter OutPutParameter2 = new SqlParameter();
            OutPutParameter2.ParameterName = "@NumDivisionClass";
            OutPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter2);

            SqlParameter OutPutParameter3 = new SqlParameter();
            OutPutParameter3.ParameterName = "@NumDivision";
            OutPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter3.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter3);

            MyComm.ExecuteNonQuery();

            SotrDivisionInfo = new List<string>();

            string NumStuInDivision;
            string NumDivisionClass;

            string NumDivision;
            if (OutPutParameter1.Value == null)
                NumStuInDivision = "";
            else NumStuInDivision = OutPutParameter1.Value.ToString();

            if (OutPutParameter2.Value == null)
                NumDivisionClass = "";
            else NumDivisionClass = OutPutParameter2.Value.ToString();

            if (OutPutParameter3.Value == null)
                NumDivision = "";
            else NumDivision = OutPutParameter3.Value.ToString();

            SotrDivisionInfo.Add(NumStuInDivision);
            SotrDivisionInfo.Add(NumDivisionClass);
            SotrDivisionInfo.Add(NumDivision);
        }
            dbhelper.closeDbConnection();
            return SotrDivisionInfo;

        }

        //حذف طلاب من شعبة ما

        public List<string> DeleteSortDivision(int idStu, int idStudyYear,int idClass,int idDivision)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteSortDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param4);
      

            SqlParameter OutPutParameter1 = new SqlParameter();
            OutPutParameter1.ParameterName = "@NumStuInDivision";
            OutPutParameter1.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter1.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter1);

            SqlParameter OutPutParameter2 = new SqlParameter();
            OutPutParameter2.ParameterName = "@NumDivisionClass";
            OutPutParameter2.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter2.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter2);

            SqlParameter OutPutParameter3 = new SqlParameter();
            OutPutParameter3.ParameterName = "@NumDivision";
            OutPutParameter3.SqlDbType = System.Data.SqlDbType.Int;
            OutPutParameter3.Direction = System.Data.ParameterDirection.Output;
            MyComm.Parameters.Add(OutPutParameter3);

            MyComm.ExecuteNonQuery();

            SotrDivisionInfo = new List<string>();

            string NumStuInDivision;
            string NumDivisionClass;

            string NumDivision;
            if (OutPutParameter1.Value == null)
                NumStuInDivision = "";
            else NumStuInDivision = OutPutParameter1.Value.ToString();

            if (OutPutParameter2.Value == null)
                NumDivisionClass = "";
            else NumDivisionClass = OutPutParameter2.Value.ToString();

            if (OutPutParameter3.Value == null)
                NumDivision = "";
            else NumDivision = OutPutParameter3.Value.ToString();

            SotrDivisionInfo.Add(NumStuInDivision);
            SotrDivisionInfo.Add(NumDivisionClass);
            SotrDivisionInfo.Add(NumDivision);

            dbhelper.closeDbConnection();
            return SotrDivisionInfo;

        }
        public DataTable ShowSortDivision(int idStudyYear, int idClass, int idDivision)
        {
            MyTableSortDivision = new DataTable();

            dbhelper.OpenDBConnection();

            string MyQuery = "ShowSortDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param3);        
            MyComm.ExecuteScalar();


            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableSortDivision.Clear();
            MyAdapter.Fill(MyTableSortDivision);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableSortDivision;
        }
        public DataTable LoadSortDivisionDetailsInfo(int idStudyYear, int idClass,int idDivision)
        {
            SortDivisionDetailsInfo = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "LoadSortDivisionDetailsInfo";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param3);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            SortDivisionDetailsInfo.Clear();
            MyAdapter.Fill(SortDivisionDetailsInfo);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return SortDivisionDetailsInfo;
        }

        public DataTable ShowSortDivisionAll(int idStudyYear, int idClass)
        {
            MyTableSortDivisionAll = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowSortDivisionAll";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);

            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableSortDivisionAll.Clear();
            MyAdapter.Fill(MyTableSortDivisionAll);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableSortDivisionAll;
        }

      
     
        public DataTable SelectStuClassCategory(int idClass, int idStudyYear, int idDivision)
        {
            MyTableStudentClassCategory = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "SelectStuClassCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param3);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableStudentClassCategory.Clear();
            MyAdapter.Fill(MyTableStudentClassCategory);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableStudentClassCategory;
        }


        public void InsertSortCategoryInOneClick(ClassDivisionCategory MyClassDivisionCategory)
        {
            dbhelper.OpenDBConnection();         

            for (int i = 0; i < MyClassDivisionCategory.StudentClassCategoryID.Count; i++)
            {
                string MyQuery = "InsertSortCategory";
                SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@idStu", MyClassDivisionCategory.StudentClassCategoryID[i]);
                MyComm.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@idClass", MyClassDivisionCategory.StudentCategoryID);
                MyComm.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@idStudyYear", ClassDivisionCategory.idStudyYear);
                MyComm.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@idDivision", MyClassDivisionCategory.DivisionCategoryID);
                MyComm.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@idCategory", MyClassDivisionCategory.CategoryCategoryID);
                MyComm.Parameters.Add(param5);
                MyComm.ExecuteNonQuery();
                MyComm.Dispose();
            }
            dbhelper.closeDbConnection();
        }
        public void InsertSortCategory(int idStu, int idClass, int idStudyYear, int idDivision, int idCategory)
        {
            dbhelper.OpenDBConnection();
            string MyQuery = "InsertSortCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

           

            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param4);
            SqlParameter param5 = new SqlParameter("@idCategory", idCategory);
            MyComm.Parameters.Add(param5);
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }

        public DataTable ShowSortCategory(int idStudyYear, int idClass, int idDivision, int idCategory)
        {
            MyTableSortCategory = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowSortCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idCategory", idCategory);
            MyComm.Parameters.Add(param4);
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableSortCategory.Clear();
            MyAdapter.Fill(MyTableSortCategory);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableSortCategory;
        }
        public void DeleteSortCategoryInOneClick(ClassDivisionCategory MyClassDivisionCategory)
        {
            dbhelper.OpenDBConnection();
            for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)
            {
                string MyQuery = "DeleteSortCategory";
                SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@idStu", MyClassDivisionCategory.StudentSortDivisionID[i]);
                MyComm.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter("@idStudyYear", ClassDivisionCategory.idStudyYear);
                MyComm.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@idClass", MyClassDivisionCategory.StudentCategoryID);
                MyComm.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter("@idDivision", MyClassDivisionCategory.DivisionCategoryID);
                MyComm.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@idCategory", MyClassDivisionCategory.CategoryCategoryID);
                MyComm.Parameters.Add(param5);
                MyComm.ExecuteNonQuery();
            }
            dbhelper.closeDbConnection();
        }
        //حذف فئة ما
        public void DeleteSortCategory(int idStu, int idStudyYear,int idClass,int idDivision,int idCategory)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteSortCategory";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
         
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param4);
            SqlParameter param5 = new SqlParameter("@idCategory", idCategory);
            MyComm.Parameters.Add(param5);
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }

        public void DeleteSortCategoryForDeleteDivisionInOneClick(ClassDivisionCategory MyClassDivisionCategory)
        {
            dbhelper.OpenDBConnection();


            for (int i = 0; i < MyClassDivisionCategory.StudentSortDivisionID.Count; i++)
            { 
                string MyQuery = "DeleteSortCategoryForDeleteDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", MyClassDivisionCategory.StudentSortDivisionID[i]);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", ClassDivisionCategory.idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idClass", MyClassDivisionCategory.StudentDivision);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", MyClassDivisionCategory.DivisionDivisionID);
            MyComm.Parameters.Add(param4);

            MyComm.ExecuteNonQuery();
        }
            dbhelper.closeDbConnection();
        }
        //عند حذف شعبة سأحذف الفئات الخاصة بها
        public void DeleteSortCategoryForDeleteDivision(int idStu, int idStudyYear, int idClass, int idDivision)
        {
            dbhelper.OpenDBConnection();

            string MyQuery = "DeleteSortCategoryForDeleteDivision";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@idStu", idStu);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@idClass", idClass);
            MyComm.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@idDivision", idDivision);
            MyComm.Parameters.Add(param4);
     
            MyComm.ExecuteNonQuery();
            dbhelper.closeDbConnection();
        }
        public DataTable ShowSortCategoryAll(int idStudyYear, int IdClass)
        {
            MyTableSortCategoryAll = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "ShowSortCategotyAll";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter("@idStudyYear", idStudyYear);
            MyComm.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@IdClass", IdClass);
            MyComm.Parameters.Add(param2);

            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyTableSortCategoryAll.Clear();
            MyAdapter.Fill(MyTableSortCategoryAll);
            MyAdapter.Dispose();
            dbhelper.closeDbConnection();
            return MyTableSortCategoryAll;
        }
    }
}
