using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_الطباعة : Form
    {
        public واجهة_الطباعة()
        {
            InitializeComponent();
        }
        StringBuilder htmlstringbld = new StringBuilder();
        //string path= @"..\..\HtmlFiles\" + "OnWork" + ".html";
       
        public static dbHelper dbhelper = new dbHelper();
        public Print myPrint = new Print();
        private void زر_القائم_على_رأس_العمل_Click(object sender, EventArgs e)
        {
            //قراءة ملف html
            //   String HtmlString = File.ReadAllText(path);

            //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
            //using (StreamReader sr = new StreamReader(fs))
            //{
            //     htmlstringbld = new StringBuilder();
            //    htmlstringbld.WriteLine(sr.ReadToEnd());
            //}
            //جدول المعطيات من قاعدة المعطيات
            //foreach(DataRow myRow in MyTable.Rows)
            //{
            //    htmlstringbld.WriteLine("<tr>");
            //    foreach (DataColumn myColumn in MyTable.Columns)
            //    {
            //        htmlstringbld.WriteLine("<td>");
            //        htmlstringbld.WriteLine(myRow[myColumn.ColumnName].ToString());
            //        htmlstringbld.WriteLine("</td>");

            //    }
            //    htmlstringbld.WriteLine("</tr>");
            //}

            //  حفظ الملف المملوء من بيانات قاعدة المعطيات على سطح المكتب 

            //   File.WriteAllText(@"Environment.GetFolderPath(Environment.SpecialFolder.Desktop)", htmlstringbld.ToString());

            //سننشأ مجلد على سطح المكتب بهذا الاسم
            DataTable MyTable = new DataTable();
            var newDirPath = Path.Combine(Environment.GetFolderPath( System.Environment.SpecialFolder.DesktopDirectory), "SchoolPrint");
            Directory.CreateDirectory(newDirPath);
            var newFilePath = Path.Combine(newDirPath,"OnWork.html");
            var filestream=  File.Create(newFilePath);
            var sw = new StreamWriter(filestream);

            MyTable = new DataTable();
            dbhelper.OpenDBConnection();
            string MyQuery = "select [Qualification],[FirstName],[PhoneNumber],[LastName],[SelfNum],[DadName],[functionality],[MomName],[certificate],[BirthdayDate],[Category],[NationalNum],[DeletionNum],[PlaceAndNumQaid],[maritialState],[address] from[dbo].[EMP] where[StudyYear]='" + StudyYear.YearID + "'";
            SqlCommand MyComm = new SqlCommand(MyQuery, dbhelper.GetdbConnection());
            MyComm.ExecuteScalar();
            SqlDataAdapter MyAdapter = new SqlDataAdapter(MyComm);
            MyAdapter.Fill(MyTable);
            dbhelper.closeDbConnection();

            foreach (DataRow myRow in MyTable.Rows)
            {
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
             //   sw.WriteLine("< meta charset =\"utf-8 >\"");
                sw.WriteLine("<meta charset=\"utf-8\" />");
                sw.WriteLine("<meta http-equiv =\"Content-Type\" content =\"text/html;charset=utf-8\" />");
                sw.WriteLine("<title>تقرير موظف بتاريخ </title>");

                sw.WriteLine("<style>");
                sw.WriteLine(" body");
                sw.WriteLine("{");
                sw.WriteLine(" font-family:Arial, Helvetica, sans-serif;");
                sw.WriteLine(" font-size: 16px;");
                sw.WriteLine("    font-weight: bold;");
                sw.WriteLine("}");
                sw.WriteLine("#mainHolder");
                sw.WriteLine(" {");
                sw.WriteLine(" float: right; ");
                sw.WriteLine("}");
                sw.WriteLine("table");
                sw.WriteLine("{");
                sw.WriteLine("border-collapse:collapse; ");
                sw.WriteLine(" }");
                sw.WriteLine("td");
                sw.WriteLine("{");
                sw.WriteLine("    border:2px solid black;");
                sw.WriteLine("   padding:4px;");
                sw.WriteLine(" direction: rtl; ");
                sw.WriteLine("  text-align: center;");
                sw.WriteLine("   width: 25%;");
                sw.WriteLine("}");
                sw.WriteLine("h3 ");
                sw.WriteLine(" {");
                sw.WriteLine("    float: right;");
                sw.WriteLine("display: block;");
                sw.WriteLine("}");
                sw.WriteLine(".space_col ");
                sw.WriteLine(" {");
                sw.WriteLine("border: none;");
                sw.WriteLine("}");
                sw.WriteLine(".sing");
                sw.WriteLine("{ ");
                sw.WriteLine(" float: right;");
                sw.WriteLine(" margin-right: 2cm;");
                sw.WriteLine("}");
                sw.WriteLine(".color_dark");
                sw.WriteLine(" {");
                sw.WriteLine(" background-color: rgb(202, 197, 197); ");
                sw.WriteLine("}");
                sw.WriteLine(".header_font");
                sw.WriteLine("{");
                sw.WriteLine("text-align:center;");
                sw.WriteLine("font-size:20px;");
                sw.WriteLine("}");
                sw.WriteLine("</style> ");
                sw.WriteLine(" </head>");

                sw.WriteLine("<body>");
                sw.WriteLine("<div id=\"mainHolder\">");
                sw.WriteLine("<div id=\"receivedTable\" style=\"margin-top:15px; width: 100% \">");

                sw.WriteLine("<table style = \"width:100%\" >");
                sw.WriteLine("<tr>");
                sw.WriteLine("<td style=\"\" class=\"space_col\">قائم على رأس العمل </td>");
                sw.WriteLine("<td class=\"space_col\"></td>");
                sw.WriteLine("<td style=\"text-align: right\" class=\"space_col\">مديرية التربية في حلب</td></tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<td style=\"\" class=\"space_col\">خاص للعاملين في المدارس</td>");
                sw.WriteLine("<td class=\"space_col\"><img src=\"..\\..\\img\\images(2).jpeg\" width=\"55px\" /></td>");
                sw.WriteLine("<td style=\"text-align: right\"class=\"space_col\">الثانوية المهنية لتقنيات الحاسوب بنات </td></tr>");
                sw.WriteLine("</table>");

                sw.WriteLine("<table style=\"margin-top:10px; width: 100%; float: center\">");
                sw.WriteLine("<tr class=\"color_dark\"><td class=\"header_font\" colspan=\"4\">بيانات العامل</td></tr>");
                string Qualification="", DeletionNum = "", maritialState="", address ="", FirstName ="", LastName ="", PhoneNumber ="", PlaceAndNumQaid = "", DadName="", Category = "", NationalNum = "", certificate = "", SelfNum="", BirthdayDate = "", functionality = "", MomName="";
                foreach (DataColumn myColumn in MyTable.Columns)
                {
                    Qualification = myRow[myColumn.ColumnName].ToString();
                    FirstName = myRow[myColumn.ColumnName].ToString();
                    PhoneNumber = myRow[myColumn.ColumnName].ToString();
                    LastName = myRow[myColumn.ColumnName].ToString();
                    SelfNum = myRow[myColumn.ColumnName].ToString();
                    DadName = myRow[myColumn.ColumnName].ToString();
                    functionality = myRow[myColumn.ColumnName].ToString();
                    MomName = myRow[myColumn.ColumnName].ToString();
                    certificate = myRow[myColumn.ColumnName].ToString();
                    BirthdayDate = myRow[myColumn.ColumnName].ToString();
                    Category = myRow[myColumn.ColumnName].ToString();
                    NationalNum = myRow[myColumn.ColumnName].ToString();
                    DeletionNum = myRow[myColumn.ColumnName].ToString();
                    PlaceAndNumQaid = myRow[myColumn.ColumnName].ToString();
                    address = myRow[myColumn.ColumnName].ToString();
                    maritialState = myRow[myColumn.ColumnName].ToString();
                }

                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(Qualification);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">المؤهل العلمي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(FirstName);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الاسم</td></tr>");

                    sw.WriteLine("<tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(PhoneNumber);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">رقم الهاتف</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(LastName);
                    sw.WriteLine("</td>");
                    sw.WriteLine("  <td class=\"color_dark\" >النسبة</td></tr>");

                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(SelfNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\" >الرقم الذاتي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(DadName);
                    sw.WriteLine("</td>");
                    sw.WriteLine("  <td class=\"color_dark\">الأب</td></tr>");

                    sw.WriteLine(" <tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(functionality);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الصفة الوظيفية</td>");

                sw.WriteLine("</td>");
                sw.WriteLine(MomName);
                sw.WriteLine("</td>");
                sw.WriteLine("<td class=\"color_dark\">اسم الأم ونسبتها</td></tr>");

                    sw.WriteLine(" <tr>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(certificate);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الاختصاص</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(BirthdayDate);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">مكان و تاريخ الولادة</td></tr>");

                    sw.WriteLine("<tr>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(Category);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الفئة</td>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(NationalNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">الرقم الوطني</td></tr>");

                    sw.WriteLine("<tr>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(DeletionNum);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">رقم الشطب</td>");


                    sw.WriteLine("<td>");
                    sw.WriteLine(PlaceAndNumQaid);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">محل ورقم القيد</td></tr>");

                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td>");
                    sw.WriteLine(maritialState);
                    sw.WriteLine("</td>");
                    sw.WriteLine(" <td class=\"color_dark\">الوضع العائلي</td>");

                    sw.WriteLine("<td>");
                    sw.WriteLine(address);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td class=\"color_dark\">مكان الإقامة</td></tr> ");

                
                sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"4\">معلومات خاصة بطبيعة العمل</td></tr>");
                sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"2\"></td>");
                sw.WriteLine("<td style=\"text-align: center\" colspan=\"2\">(داخل الصف أو خارج الصف وصفته)</td></tr>");
                sw.WriteLine("<tr class=\"color_dark\"><td style=\"text-align: center\" colspan=\"4\">ملاحظة : جميع المعلومات المدونة بالنسبة لطبيعة العمل تقع على عائق مدير المدرسة</td></tr>");

                sw.WriteLine("</table>");
                sw.WriteLine("</div>");

                sw.WriteLine("<p class=\"sing\" style=\"float: left; margin - left: 1cm\">اسم وتوقيع صاحب العلاقة</p>");
                sw.WriteLine("</div>");


                sw.WriteLine("<table style=\"width:100% \">");
                sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"4\">إلى دائرة المحاسبة :</td></tr>");
                sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"4\"> لا يزال العامل المذكور أعلاه قائماً على رأس عمله حتى تاريخ ...............</td></tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\">الموجه المشرف</td>");
                sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\">مدير الثانوية</td></tr>");

                sw.WriteLine("<tr><td class=\"space_col\" style=\"text-align: right\" colspan=\"2\"> الخاتم والتوقيع </td>");
                sw.WriteLine("<td class=\"space_col\" style=\"text-align: right\" colspan=\"2\"> الخاتم والتوقيع </td></tr>");               
                sw.WriteLine("</table>");
                sw.WriteLine("</br>");
                sw.WriteLine("</br>");
                sw.WriteLine("</br>");
                sw.WriteLine("</br>");
                sw.WriteLine("</br>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");



            }
            sw.Close();
            myPrint.PrintHelpPage(newFilePath);
            //    StringBuilder strbld = myPrint.OnWorkReport_AllEMP();
            //int i = 0;
            //while (i < strbld.Length - 1)
            //{
            //    sw.WriteLine(strbld[i]);
            //    i++;   
            //}

            // var sr = new StreamReader(newFilePath);
            //var read = true;
            //while (read)
            //{
            //    var line = sr.ReadLine();
            //    if (string.IsNullOrEmpty(line))
            //        read = false;

            //}
            //var sr = new StreamReader(newFilePath);
            //sr.ReadToEnd();
            //sr.Close();

            //الطباعة
        }
       
        private void واجهة_الطباعة_Load(object sender, EventArgs e)
        {

        }

        private void واجهة_الطباعة_FormClosing(object sender, FormClosingEventArgs e)
        {
          Print.IsClosing = true;
        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

