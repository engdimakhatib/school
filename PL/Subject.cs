using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public class Subject
    {
        public static int idStudyYear;
        public int idSubject;
        public static Boolean IsClosingSubject = false;
        public static Boolean IsClosingDistribution = false;
        public static Boolean IsClosingSubjectDistirution = false;
        public bool IsLoad = true ;

        public string NameSubject;
        public string TypeSubject;
        public int ExamDuration;
        public string NameClass;
        public int NumExcercise1;
        public int NumExcercise2;
        public int NumStudies1;
        public int NumStudies2;
        public int NumHour;
        public int IsCanceled;
        public static    int idClass;
        public static string NameClassSelected;
        public int idDistibution;
        public int idSubjectForDist=-1;
        public int idDistributionForDist=-1;
        public float Mark;

        public void InsertSubject(string NameSubject, int idStudyYear, int idClass, int NumHour, string TypeSubject, int ExamDuration, string NameClass, int NumExcercise1, int NumExcercise2, int NumStudies1, int NumStudies2)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[11];

            p[0] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 100);
            p[0].Value = NameSubject;


            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            p[2] = new SqlParameter("@idClass", SqlDbType.Int);
            p[2].Value = idClass;


            p[3] = new SqlParameter("@NumHour", SqlDbType.Int);
            p[3].Value = NumHour;


            p[4] = new SqlParameter("@TypeSubject", SqlDbType.NChar, 20);
            p[4].Value = TypeSubject;

            p[5] = new SqlParameter("@ExamDuration", SqlDbType.NVarChar, 200);
            p[5].Value = ExamDuration;

            p[6] = new SqlParameter("@NameClass", SqlDbType.NVarChar, 100);
            p[6].Value = NameClass;


            p[7] = new SqlParameter("@NumExcercise1", SqlDbType.Int);
            p[7].Value = NumExcercise1;

            p[8] = new SqlParameter("@NumExcercise2", SqlDbType.Int);
            p[8].Value = NumExcercise2;

            p[9] = new SqlParameter("@NumStudies1", SqlDbType.Int);
            p[9].Value = NumStudies1;

            p[10] = new SqlParameter("@NumStudies2", SqlDbType.Int);
            p[10].Value = NumStudies2;

            ob.RUA("InsertSubject", p);

            ob.close();

        }
        public void UpdateSubject(string NameSubject, int idStudyYear, int idClass, int NumHour, string TypeSubject, int ExamDuration, string NameClass, int NumExcercise1, int NumExcercise2, int NumStudies1, int NumStudies2, int IsCanceled, int id)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[13];

            p[0] = new SqlParameter("@NameSubject", SqlDbType.NVarChar, 100);
            p[0].Value = NameSubject;


            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            p[2] = new SqlParameter("@idClass", SqlDbType.Int);
            p[2].Value = idClass;


            p[3] = new SqlParameter("@NumHour", SqlDbType.Int);
            p[3].Value = NumHour;


            p[4] = new SqlParameter("@TypeSubject", SqlDbType.NChar, 20);
            p[4].Value = TypeSubject;

            p[5] = new SqlParameter("@ExamDuration", SqlDbType.NVarChar, 200);
            p[5].Value = ExamDuration;

            p[6] = new SqlParameter("@NameClass", SqlDbType.NVarChar, 100);
            p[6].Value = NameClass;


            p[7] = new SqlParameter("@NumExcercise1", SqlDbType.Int);
            p[7].Value = NumExcercise1;

            p[8] = new SqlParameter("@NumExcercise2", SqlDbType.Int);
            p[8].Value = NumExcercise2;

            p[9] = new SqlParameter("@NumStudies1", SqlDbType.Int);
            p[9].Value = NumStudies1;

            p[10] = new SqlParameter("@NumStudies2", SqlDbType.Int);
            p[10].Value = NumStudies2;

            p[11] = new SqlParameter("@IsCanceled", SqlDbType.Int);
            p[11].Value = IsCanceled;

            p[12] = new SqlParameter("@id", SqlDbType.Int);
            p[12].Value = id;

            ob.RUA("UpdateSubject", p);

            ob.close();

        }

        public void DeleteSubject(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("DeleteSubject", p);

            ob.close();

        }
        public DataTable SelectSubject(int idStudyYear, int idClass)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[0].Value = idStudyYear;

            p[1] = new SqlParameter("@idClass", SqlDbType.Int);
                p[1].Value = idClass;
            dt = ob.Reader("SelectSubject", p);
            ob.close();
            return dt;
        }


        public DataTable SelectClass()
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            dt = ob.Reader("SelectClass", null);
            ob.close();
            return dt;
        }

        public void InsertDistribution(string NameDistribution)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@NameDistribution", SqlDbType.NVarChar, 100);
            p[0].Value = NameDistribution;


  

            ob.RUA("InsertDistribution", p);

            ob.close();

        }
        public void DeleteDistibution(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("DeleteDistibution", p);

            ob.close();

        }
        public DataTable SelectDist()
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();
       
            dt = ob.Reader("SelectDist", null);
            ob.close();
            return dt;
        }
   
        public DataTable SelectDistMarkSubject(int idSubject)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idSubject", SqlDbType.Int);
            p[0].Value = idSubject;
    
            dt = ob.Reader("SelectDistMarkSubject", p);
            ob.close();
            return dt;
        }
        public void InsertDistSubject(int idSubject,int idDistibution,int idStudyYear,float Mark)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[4];

            p[0] = new SqlParameter("@idSubject", SqlDbType.Int);
            p[0].Value = idSubject;


            p[1] = new SqlParameter("@idDistibution", SqlDbType.Int);
            p[1].Value = idDistibution;

            p[2] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[2].Value = idStudyYear;


            p[3] = new SqlParameter("@Mark", SqlDbType.Real );
            p[3].Value = Mark;
            ob.RUA("InsertDistSubject", p);

            ob.close();

        }
        public void DeleteDistibutionMarkSubject(int idSubject, int idDistibution)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idSubject", SqlDbType.Int);
            p[0].Value = idSubject;

            p[1] = new SqlParameter("@idDistibution", SqlDbType.Int);
            p[1].Value = idDistibution;

            ob.RUA("DeleteDistibutionMarkSubject", p);

            ob.close();

        }
        public void DeleteDistibutionFromMarkSubject(int idDistibution)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];
       
            p[0] = new SqlParameter("@idDistibution", SqlDbType.Int);
            p[0].Value = idDistibution;

            ob.RUA("DeleteDistibutionFromMarkSubject", p);

            ob.close();

        }
        public void DeleteSubjectFromMarkSubject(int idSubject)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idSubject", SqlDbType.Int);
            p[0].Value = idSubject;

        

            ob.RUA("DeleteSubjectFromMarkSubject", p);

            ob.close();

        }
        public void UpdateSubjectDistribution(int idSubject,int idDistibution,float Mark)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@idSubject", SqlDbType.Int);
            p[0].Value = idSubject;


            p[1] = new SqlParameter("@idDistibution", SqlDbType.Int);
            p[1].Value = idDistibution;

            p[2] = new SqlParameter("@Mark", SqlDbType.Float );
            p[2].Value = Mark;


        
            ob.RUA("UpdateSubjectDistribution", p);

            ob.close();

        }
    }
}
