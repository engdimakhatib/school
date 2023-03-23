using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MYSCHOOLFINAL
{
  
  public   class EMP
    {
        public static int idStudyYear;
        public static  int id;
        public string FirstName;
        public string LastName;
        public string DadName;
        public string MomName;
        public string PhoneNumber;
        public string PlaceAndNumQaid;
        public int SelfNum;
        public string FinancialNum;
        public string ReverseNum;
        public string DeletionNum;
        public string NationalNum;
        public string NumBackIdentity;
        public string Email;
        public string maritialState;
        public int NumChildren;
        public string Qualification;
        public string certificate;
        public string GraduationDate;
        public string Category;
        public string ApprovedName;
        public float Salary;
        public string OriginalSchool;
        public string TempSchool;
        public int NumHour;
        public string BirthdayDate;
        public string DirectlyAtSchool;
        public string YearStartWork;
        public int functionalityID;
        public int AssignedWorkID;
        public string situation;
        public int NumPresident;
        public int NumTrustWorthy;
        public string DateCourses;
        public string RecruitmentDivison;
        public string Notes;
        public string address;
        public string Courses;
        public int IsMove;
        public static string functionalityNewText;
         public static  string AssignedWorNewText;

        public static int functionalityIDIndex = -1;
        public static int AssignedWorkIDIndex = -1;

        public DataTable MyTable; 
    
        public static int i = 0;
        public static Boolean IsClosing = false;

        public static  string AssignedWorkOldText = "";
        public static  string functionalityOldText = "";

        public static Boolean IsClosingAddEMP = false;
        public static Boolean IsClosingUpdateEmp = false;
        public static Boolean IsClosingWoork = false;
        public static int idAssignedWork;




        public void InsertAssignedWork(string NameWork, int idStudyYear, string Notes)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[3];

            p[0] = new SqlParameter("@NameWork", SqlDbType.NChar, 100);
            p[0].Value = NameWork;


            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            p[2] = new SqlParameter("@Notes", SqlDbType.NVarChar, 100);
            p[2].Value = Notes;

            ob.RUA("InsertAssignedWork", p);

            ob.close();

        }
        public void UpdateAssignedWork(int id, string NameWork, int idStudyYear, string Notes)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@NameWork", SqlDbType.NChar, 100);
            p[1].Value = NameWork;


            p[2] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[2].Value = idStudyYear;

            p[3] = new SqlParameter("@Notes", SqlDbType.NVarChar, 200);
            p[3].Value = Notes;
            ob.RUA("UpdateAssignedWork", p);

            ob.close();

        }


        public void DeleteAssignedWork(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("DeleteAssignedWork", p);

            ob.close();

        }
        public DataTable SelectAssignedWork(int idStudyYear)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[0].Value = idStudyYear;

            dt = ob.Reader("SelectAssignedWork", p);
            ob.close();
            return dt;
        }
        public DataTable SelectFunctionality()
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();
          
            dt = ob.Reader("SelectFunctionality", null);
            ob.close();
            return dt;
        }
        public int InsertEMP(string FirstName, string LastName, string DadName, string MomName, string PhoneNumber, string PlaceAndNumQaid, int SelfNum, string FinancialNum, string ReverseNum, string DeletionNum, string NationalNum, string NumBackIdentity, string Email, string maritialState, int NumChildren, string Qualification, string certificate, string GraduationDate, string Category, string ApprovedName, float Salary, string OriginalSchool, string TempSchool, int NumHour, string BirthdayDate, string DirectlyAtSchool, string YearStartWork, string situation, int NumPresident, int NumTrustWorthy, int RemainingNumHour, string DateCourses, string RecruitmentDivison, byte[] EMP_Image, string Notes, string address, string Courses,string AssignedWork,string functionality, int StudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[41];

            p[0] = new SqlParameter("@FirstName", SqlDbType.NChar, 100);
            p[0].Value = FirstName;


            p[1] = new SqlParameter("@LastName", SqlDbType.NChar, 100);
            p[1].Value = LastName;

            p[2] = new SqlParameter("@DadName", SqlDbType.NChar, 100);
            p[2].Value = DadName;

            p[3] = new SqlParameter("@MomName", SqlDbType.NChar, 100);
            p[3].Value = MomName;

            p[4] = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50);
            p[4].Value = PhoneNumber;

            p[5] = new SqlParameter("@PlaceAndNumQaid", SqlDbType.NVarChar, 100);
            p[5].Value = PlaceAndNumQaid;

            p[6] = new SqlParameter("@SelfNum", SqlDbType.Int);
            p[6].Value = SelfNum;

            p[7] = new SqlParameter("@FinancialNum", SqlDbType.NVarChar, 50);
            p[7].Value = FinancialNum;

            p[8] = new SqlParameter("@ReverseNum", SqlDbType.NVarChar, 50);
            p[8].Value = ReverseNum;

            p[9] = new SqlParameter("@DeletionNum", SqlDbType.NVarChar, 50);
            p[9].Value = DeletionNum;

            p[10] = new SqlParameter("@NationalNum", SqlDbType.NVarChar, 50);
            p[10].Value = NationalNum;

            p[11] = new SqlParameter("@NumBackIdentity", SqlDbType.NVarChar, 50);
            p[11].Value = NumBackIdentity;

            p[12] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
            p[12].Value = Email;

            p[13] = new SqlParameter("@maritialState", SqlDbType.NVarChar, 50);
            p[13].Value = maritialState;

            p[14] = new SqlParameter("@NumChildren", SqlDbType.Int);
            p[14].Value = NumChildren;

            p[15] = new SqlParameter("@Qualification", SqlDbType.NVarChar, 50);
            p[15].Value = Qualification;

            p[16] = new SqlParameter("@certificate", SqlDbType.NVarChar, 50);
            p[16].Value = certificate;

            p[17] = new SqlParameter("@GraduationDate", SqlDbType.NVarChar, 50);
            p[17].Value = GraduationDate;

            p[18] = new SqlParameter("@Category", SqlDbType.NVarChar, 50);
            p[18].Value = Category;

            p[19] = new SqlParameter("@ApprovedName", SqlDbType.NChar, 100);
            p[19].Value = ApprovedName;

            p[20] = new SqlParameter("@Salary", SqlDbType.Float);
            p[20].Value = Salary;

            p[21] = new SqlParameter("@OriginalSchool", SqlDbType.NVarChar, 100);
            p[21].Value = OriginalSchool;

            p[22] = new SqlParameter("@TempSchool", SqlDbType.NVarChar, 100);
            p[22].Value = TempSchool;

            p[23] = new SqlParameter("@NumHour", SqlDbType.Int);
            p[23].Value = NumHour;

            p[24] = new SqlParameter("@BirthdayDate ", SqlDbType.NVarChar, 50);
            p[24].Value = BirthdayDate;

            p[25] = new SqlParameter("@DirectlyAtSchool", SqlDbType.NVarChar, 50);
            p[25].Value = DirectlyAtSchool;

            p[26] = new SqlParameter("@YearStartWork", SqlDbType.NVarChar, 50);
            p[26].Value = YearStartWork;

            p[27] = new SqlParameter("@situation", SqlDbType.NVarChar, 50);
            p[27].Value = situation;

            p[28] = new SqlParameter("@NumPresident", SqlDbType.Int);
            p[28].Value = NumPresident;

            p[29] = new SqlParameter("@NumTrustWorthy", SqlDbType.Int);
            p[29].Value = NumTrustWorthy;

            p[30] = new SqlParameter("@RemainingNumHour", SqlDbType.Int);
            p[30].Value = RemainingNumHour;

            p[31] = new SqlParameter("@DateCourses", SqlDbType.NVarChar, 50);
            p[31].Value = DateCourses;


            p[32] = new SqlParameter("@RecruitmentDivison ", SqlDbType.NVarChar, 100);
            p[32].Value = RecruitmentDivison;

            if (EMP_Image != null) { 
            p[33] = new SqlParameter("@EMP_Image", SqlDbType.Image);
            p[33].Value = EMP_Image;
        }
        else{
                p[33] = new SqlParameter("@EMP_Image", SqlDbType.Image);
                p[33].Value = DBNull.Value;
            }
            p[34] = new SqlParameter("@Notes", SqlDbType.NVarChar, 200);
            p[34].Value = Notes;

            p[35] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            p[35].Value = address;

            p[36] = new SqlParameter("@Courses", SqlDbType.NVarChar, 200);
            p[36].Value = Courses;

            p[37] = new SqlParameter("@AssignedWork", SqlDbType.NVarChar, 200);
            p[37].Value = AssignedWork;

            p[38] = new SqlParameter("@functionality", SqlDbType.NVarChar, 200);
            p[38].Value = functionality;

            p[39] = new SqlParameter("@StudyYear", SqlDbType.Int);
            p[39].Value = StudyYear;

            p[40] = new SqlParameter("@IDOUT", SqlDbType.Int);

            p[40].Direction = ParameterDirection.Output;

            ob.RUA("InsertEMP", p);

            ob.close();

            string id;
            if (p[40].Value == null)
                id = "";
            else id = p[40].Value.ToString();
        
            return Convert.ToInt32(id);

        }
        public void InsertJob(int idEMP,int IdYear,int AssignedWorkID,int functionalityID,string AssignedWorkOldText,string functionalityOldText)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[6];

            p[0] = new SqlParameter("@idEMP ", SqlDbType.Int );
            p[0].Value = idEMP;


            p[1] = new SqlParameter("@IdYear", SqlDbType.Int);
            p[1].Value = IdYear;

            p[2] = new SqlParameter("@AssignedWorkID", SqlDbType.Int);
            p[2].Value = AssignedWorkID;
            p[3] = new SqlParameter("@functionalityID", SqlDbType.Int);
            p[3].Value = functionalityID;

            p[4] = new SqlParameter("@AssignedWorkOldText", SqlDbType.NChar, 100);
            p[4].Value = AssignedWorkOldText;
            p[5] = new SqlParameter("@functionalityOldText", SqlDbType.NChar, 100);

            p[5].Value = functionalityOldText;
            ob.RUA("InsertJob", p);

            ob.close();

        }
        public void UpdateJob(int idEMP, int IdYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@idEMP ", SqlDbType.Int);
            p[0].Value = idEMP;


            p[1] = new SqlParameter("@IdYear", SqlDbType.Int);
            p[1].Value = IdYear;

     
            ob.RUA("UpdateJob", p);

            ob.close();

        }
        public void UpdateEMP(string FirstName, string LastName, string DadName, string MomName, string PhoneNumber, string PlaceAndNumQaid, int SelfNum, string FinancialNum, string ReverseNum, string DeletionNum, string NationalNum, string NumBackIdentity, string Email, string maritialState, int NumChildren, string Qualification, string certificate, string GraduationDate, string Category, string ApprovedName, float Salary, string OriginalSchool, string TempSchool, int NumHour, string BirthdayDate, string DirectlyAtSchool, string YearStartWork, string situation, int NumPresident, int NumTrustWorthy, int RemainingNumHour, string DateCourses,int IsMove, string RecruitmentDivison, byte[] EMP_Image, string Notes, string address, string Courses, string AssignedWork, string functionality, int StudyYear, int id)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[42];

            p[0] = new SqlParameter("@FirstName", SqlDbType.NChar, 100);
            p[0].Value = FirstName;


            p[1] = new SqlParameter("@LastName", SqlDbType.NChar, 100);
            p[1].Value = LastName;

            p[2] = new SqlParameter("@DadName", SqlDbType.NChar, 100);
            p[2].Value = DadName;

            p[3] = new SqlParameter("@MomName", SqlDbType.NChar, 100);
            p[3].Value = MomName;

            p[4] = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50);
            p[4].Value = PhoneNumber;

            p[5] = new SqlParameter("@PlaceAndNumQaid", SqlDbType.NVarChar, 100);
            p[5].Value = PlaceAndNumQaid;

            p[6] = new SqlParameter("@SelfNum", SqlDbType.Int);
            p[6].Value = SelfNum;

            p[7] = new SqlParameter("@FinancialNum", SqlDbType.NVarChar, 50);
            p[7].Value = FinancialNum;

            p[8] = new SqlParameter("@ReverseNum", SqlDbType.NVarChar, 50);
            p[8].Value = ReverseNum;

            p[9] = new SqlParameter("@DeletionNum", SqlDbType.NVarChar, 50);
            p[9].Value = DeletionNum;

            p[10] = new SqlParameter("@NationalNum", SqlDbType.NVarChar, 50);
            p[10].Value = NationalNum;

            p[11] = new SqlParameter("@NumBackIdentity", SqlDbType.NVarChar, 50);
            p[11].Value = NumBackIdentity;

            p[12] = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
            p[12].Value = Email;

            p[13] = new SqlParameter("@maritialState", SqlDbType.NVarChar, 50);
            p[13].Value = maritialState;

            p[14] = new SqlParameter("@NumChildren", SqlDbType.Int);
            p[14].Value = NumChildren;

            p[15] = new SqlParameter("@Qualification", SqlDbType.NVarChar, 50);
            p[15].Value = Qualification;

            p[16] = new SqlParameter("@certificate", SqlDbType.NVarChar, 50);
            p[16].Value = certificate;

            p[17] = new SqlParameter("@GraduationDate", SqlDbType.NVarChar, 50);
            p[17].Value = GraduationDate;

            p[18] = new SqlParameter("@Category", SqlDbType.NVarChar, 50);
            p[18].Value = Category;

            p[19] = new SqlParameter("@ApprovedName", SqlDbType.NChar, 100);
            p[19].Value = ApprovedName;

            p[20] = new SqlParameter("@Salary", SqlDbType.Float);
            p[20].Value = Salary;

            p[21] = new SqlParameter("@OriginalSchool", SqlDbType.NVarChar, 100);
            p[21].Value = OriginalSchool;

            p[22] = new SqlParameter("@TempSchool", SqlDbType.NVarChar, 100);
            p[22].Value = TempSchool;

            p[23] = new SqlParameter("@NumHour", SqlDbType.Int);
            p[23].Value = NumHour;

            p[24] = new SqlParameter("@BirthdayDate ", SqlDbType.NVarChar, 50);
            p[24].Value = BirthdayDate;

            p[25] = new SqlParameter("@DirectlyAtSchool", SqlDbType.NVarChar, 50);
            p[25].Value = DirectlyAtSchool;

            p[26] = new SqlParameter("@YearStartWork", SqlDbType.NVarChar, 50);
            p[26].Value = YearStartWork;

            p[27] = new SqlParameter("@situation", SqlDbType.NVarChar, 50);
            p[27].Value = situation;

            p[28] = new SqlParameter("@NumPresident", SqlDbType.Int);
            p[28].Value = NumPresident;

            p[29] = new SqlParameter("@NumTrustWorthy", SqlDbType.Int);
            p[29].Value = NumTrustWorthy;

            p[30] = new SqlParameter("@RemainingNumHour", SqlDbType.Int);
            p[30].Value = RemainingNumHour;

            p[31] = new SqlParameter("@DateCourses", SqlDbType.NVarChar, 50);
            p[31].Value = DateCourses;

            p[32] = new SqlParameter("@IsMove", SqlDbType.Int );
            p[32].Value = IsMove;

            p[33] = new SqlParameter("@RecruitmentDivison ", SqlDbType.NVarChar, 100);
            p[33].Value = RecruitmentDivison;

            if (EMP_Image != null)
            {
                p[34] = new SqlParameter("@EMP_Image", SqlDbType.Image);
                p[34].Value = EMP_Image;
            }
            else
            {
                p[34] = new SqlParameter("@EMP_Image", SqlDbType.Image);
                p[34].Value = DBNull.Value;
            }

    

            p[35] = new SqlParameter("@Notes", SqlDbType.NVarChar, 200);
            p[35].Value = Notes;

            p[36] = new SqlParameter("@address", SqlDbType.NVarChar, 200);
            p[36].Value = address;

            p[37] = new SqlParameter("@Courses", SqlDbType.NVarChar, 200);
            p[37].Value = Courses;

            p[38] = new SqlParameter("@AssignedWork", SqlDbType.NVarChar, 200);
            p[38].Value = AssignedWork;

            p[39] = new SqlParameter("@functionality", SqlDbType.NVarChar, 200);
            p[39].Value = functionality;


            p[40] = new SqlParameter("@StudyYear", SqlDbType.Int);
            p[40].Value = StudyYear;

            p[41] = new SqlParameter("@id", SqlDbType.Int);

            p[41].Value = id;
            ob.RUA("UpdateEMP", p);

            ob.close();
        }
            public DataTable SelectEMP(int StudyYear)
        {
            MyTable = new DataTable();
              DXL ob = new DXL();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@StudyYear", SqlDbType.Int);
            p[0].Value = StudyYear;

            MyTable = ob.Reader("SelectEMP", p);
            ob.close();
            return MyTable;
        }
        public DataTable SeachEmpInfo(string search,int  idStudyYear)
        {
            MyTable = new DataTable();
            DXL ob = new DXL();
            ob.open();
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@search", SqlDbType.NVarChar);
            p[0].Value = search;
            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;
            MyTable = ob.Reader("SeachEmpInfo", p);
            ob.close();
            return MyTable;
        }

        public void DeleteEMP(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("DeleteEMP", p);

            ob.close();

        }

        public void deleteAdjWorkEMP(int id, int idStudyYear)
        {
            DXL ob = new DXL();
            ob.open();

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@idEMP", SqlDbType.Int);
            p[0].Value = id;

            p[1] = new SqlParameter("@idStudyYear", SqlDbType.Int);
            p[1].Value = idStudyYear;

            ob.RUA("deleteAdjWorkEMP", p);

            ob.close();

        }
        public DataTable selectEMPimg(int id)
        {
            DataTable dt = new DataTable();
            DXL ob = new DXL();
            ob.open();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", SqlDbType.Int);
            p[0].Value =id ;

            dt = ob.Reader("selectEMPimg", p);
            ob.close();
            return dt;
        }
    }
}
