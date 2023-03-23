using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    class Hall
    {
        public Boolean IsLoad = true;
        public static int idStudyYear;

        public int idHallForEquipment;
        public int idEquipmentForHall;
       public static int idClass = 1;
        public static string NameClassSelected;
        public int idEquipment;

        public string NameHall;
        public string NickName;
        public string TypeHall;
        public int IsClosed;
        public string NotesHall;
        public string SpecializeHall;
        public int idHall;
      //  public int idselectedclass;
        public static Boolean IsClosingHallEquipment = true;
        public static Boolean IsClosingHall = true;
        public static Boolean IsClosingEquipment = true;
        public string Num;
        public string Notes;
        public DataTable SelectClass()
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            dt = ob.Reader("SelectClass", null);
            ob.close();
            return dt;
        }

        public void InsertHall(string NameHall, string NickName, string TypeHall, string Notes, string SpecializeHall, int idClass, int IsStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[7];

            p[0] = new SqlParameter("@NameHall", SqlDbType.NChar, 100);
            p[0].Value = NameHall;


            p[1] = new SqlParameter("@NickName", SqlDbType.NVarChar, 100);
            p[1].Value = NickName;

            p[2] = new SqlParameter("@TypeHall", SqlDbType.NChar, 100);
            p[2].Value = TypeHall;


            p[3] = new SqlParameter("@Notes", SqlDbType.NVarChar, 1000);
            p[3].Value = Notes;


            p[4] = new SqlParameter("@SpecializeHall", SqlDbType.NChar, 100);
            p[4].Value = SpecializeHall;

            p[5] = new SqlParameter("@idClass", SqlDbType.Int);
            p[5].Value = idClass;

            p[6] = new SqlParameter("@IsStudyYear", SqlDbType.Int);
            p[6].Value = IsStudyYear;


            ob.RUA("InsertHall", p);

            ob.close();

        }
        public void UpdateHall(string NameHall, string NickName, string TypeHall, string Notes, string SpecializeHall,int IsClosed, int IsStudyYear,int id)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[8];

            p[0] = new SqlParameter("@NameHall", SqlDbType.NChar, 100);
            p[0].Value = NameHall;


            p[1] = new SqlParameter("@NickName", SqlDbType.NVarChar, 100);
            p[1].Value = NickName;

            p[2] = new SqlParameter("@TypeHall", SqlDbType.NChar, 100);
            p[2].Value = TypeHall;


            p[3] = new SqlParameter("@Notes", SqlDbType.NVarChar, 1000);
            p[3].Value = Notes;


            p[4] = new SqlParameter("@SpecializeHall", SqlDbType.NChar, 100);
            p[4].Value = SpecializeHall;

       

            p[5] = new SqlParameter("@IsClosed", SqlDbType.Int);
            p[5].Value = IsClosed;

             p[6] = new SqlParameter("@IsStudyYear", SqlDbType.Int);
        p[6].Value = IsStudyYear;
             p[7] = new SqlParameter("@id", SqlDbType.Int);
        p[7].Value = id;
            ob.RUA("UpdateHall", p);

            ob.close();

        }
        public void DeleteHall(int id, int IsStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@IsStudyYear", SqlDbType.Int);
            p[1].Value = IsStudyYear;

            ob.RUA("DeleteHall", p);

            ob.close();

        }
        public DataTable SelectHall(int idStudyYear, int idClass)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[0].Value = idStudyYear;

            p[1] = new SqlParameter("@idClass", SqlDbType.Int);
            p[1].Value = idClass;
            dt = ob.Reader("SelectHall", p);
            ob.close();
            return dt;
        }


        public void InsertEquipment(string NameEquipment,string Notes ,int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@NameEquipment", SqlDbType.NVarChar, 500);
            p[0].Value = NameEquipment;

            p[1] = new SqlParameter("@Notes", SqlDbType.NVarChar,1000);
            p[1].Value = Notes;

            p[2] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[2].Value = idStudyYear;


            ob.RUA("InsertEquipment", p);

            ob.close();

        }
        public void DeleteEquipment(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("DeleteEquipment", p);

            ob.close();

        }
        public void DeleteFromEquipmentHallForHall(int id)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idHall", SqlDbType.Int);
            p[0].Value = id;

            ob.RUA("DeleteFromEquipmentHallForHall", p);

            ob.close();

        }
        public void DeleteFromEquipmentHallForEquipment(int id)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idEquipment", SqlDbType.Int);
            p[0].Value = id;       
            ob.RUA("DeleteFromEquipmentHallForEquipment", p);
            ob.close();

        }


        public DataTable SelectEquipment(int idStudyYear)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[0].Value = idStudyYear;
     
            dt = ob.Reader("SelectEquipment", p);
            ob.close();
            return dt;
        }

        public void InsertHallEquipment(int idHall, int idEquipment,int idStudyYear, string Num, string Notes)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[5];

            p[0] = new SqlParameter("@idHall", SqlDbType.Int);
            p[0].Value = idHall;

            p[1] = new SqlParameter("@idEquipment", SqlDbType.Int);
            p[1].Value = idEquipment;

            p[2] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[2].Value = idStudyYear;

            p[3] = new SqlParameter("@Num", SqlDbType.NVarChar, 500);
            p[3].Value = Num;

            p[4] = new SqlParameter("@Notes", SqlDbType.NVarChar, 1000);
            p[4].Value = Notes;


            ob.RUA("InsertHallEquipment", p);

            ob.close();

        }
        public void UpdateHallEquipment(int idHall, int idEquipment, int idStudyYear, string Num, string Notes)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[5];

            p[0] = new SqlParameter("@idHall", SqlDbType.Int);
            p[0].Value = idHall;

            p[1] = new SqlParameter("@idEquipment", SqlDbType.Int);
            p[1].Value = idEquipment;

            p[2] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[2].Value = idStudyYear;

            p[3] = new SqlParameter("@Num", SqlDbType.NVarChar, 500);
            p[3].Value = Num;

            p[4] = new SqlParameter("@Notes", SqlDbType.NVarChar, 1000);
            p[4].Value = Notes;


            ob.RUA("UpdateHallEquipment", p);

            ob.close();

        }
        public DataTable SelectEquipmentHall(int idStudyYear, int idHall)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[0].Value = idStudyYear;

            p[1] = new SqlParameter("@idHall", SqlDbType.Int);
            p[1].Value = idHall;
            dt = ob.Reader("SelectEquipmentHall", p);
            ob.close();
            return dt;
        }

    }
}
