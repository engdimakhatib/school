using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MYSCHOOLFINAL
{
    public partial class واجهة_الدوام : Form
    {
        public واجهة_الدوام()
        {
            InitializeComponent();
            if (n == null)
                n = this;
        }
        private static واجهة_الدوام n;
        static void cf(object sender, FormClosedEventArgs e)
        {
            n = null;
        }
        public static واجهة_الدوام deleg
        {
            get
            {
                if (n == null)
                {
                    n = new واجهة_الدوام();
                }
                return n;
            }

        }
        static string[] day = new string[] { "الأحد", "الاثنين", "الثلاثاء", "الأربعاء", "الخميس" };
        DoamSub MyDoamSub = new DoamSub();
        static int LectureNum = 0;
        private void واجهة_الدوام_Load(object sender, EventArgs e)
        {
            ClassDivisionCategory.ShowCustomClass(ClassSub);
            ClassDivisionCategory.ShowCustomDivision(DivisionSub, ClassDivisionCategory.idStudyYear);
            
            ClassDivisionCategory.ShowCustomCategory(CategorySub, ClassDivisionCategory.idStudyYear);

            if (!(DivisionSub.Items.Count == 0))
            {
                DivisionSub.SelectedIndex = 0;
                MyDoamSub.idDivision = ClassDivisionCategory.IdDivisiones[0];
            
            }
   
            MyDoamSub.idClass = ClassDivisionCategory.IdClasses[0];
            ClassSub.SelectedIndex = 0;
            if (!(CategorySub.Items.Count == 0))
            {
                CategorySub.SelectedIndex = 0;
                MyDoamSub.idCategory = ClassDivisionCategory.IdCategories[0];
            }
            //إضافة الحصص للأعمدة
            if (LectureNum == 0)
            {
                LectureNum = MyDoamSub.ShowDoamLecture(ClassDivisionCategory.idStudyYear);
                if (!(LectureNum == 0))
                {
                    for (int i = 1; i <= LectureNum; i++)
                    {
                        string s = "حصة" + (i);
                        string c = "col" + i;
                        DGV_DoamSub.Columns.Add(c, s);
                        // datagridviewDoamStu.Columns[i].HeaderText = s;
                    }
                    //إضافة الأيام للأسطر
                    for (int k = 0; k < 5; k++)
                    {
                        DGV_DoamSub.Rows.Add();
                        DGV_DoamSub.Rows[k].Cells[0].Value = day[k];
                        DGV_DoamSub.Rows[k].Cells[0].ReadOnly = true;
                    }
                }
                else
                {
                    MessageBox.Show("قبل إدخال برنامج الدوام يرجى إدخال الحصص أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            }

        
        private void Show_Click(object sender, EventArgs e)
        {
            string[] Material = new string[] { "Arabic", "French", "English", "programming", "algorithm" };

            //determine point to draw the material in panel in the form that is name PanelM;
            int X = 50, Y = 50;
            //declare panels must be draw dynamic in code with size default from me=50

            Panel[] Pm = new Panel[20];

            //the father
            Panel PanelM = new Panel();

            //and label for names of materials
            Label[] Lpm = new Label[20];

            for (int i = 0; i < Material.Length; i++)
            {
                Pm[i] = new Panel();
                Pm[i].AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                Pm[i].Location = new Point(X, Y);
                Pm[i].Size = new Size(100, 50);

                //   Material[matCounter].TabIndex=2;
                Pm[i].Visible = true;
                Pm[i].AllowDrop = true;
                Pm[i].Cursor = System.Windows.Forms.Cursors.SizeAll;
                Pm[i].Name = "Pm[" + i + "]";
                Pm[i].BringToFront();
               
                //Add to the father Panel
                PanelM.Controls.Add(Pm[i]);
                //Add event for panel
                Pm[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);

                //create label that represent material name

                Lpm[i] = new Label();
                Lpm[i].ForeColor = Color.Black;
                Lpm[i].Text = Material[i].ToString();
                Pm[i].Controls.Add(Lpm[i]);
                Lpm[i].Location = new System.Drawing.Point(-10, 5);
                Lpm[i].Font = new Font("Arial", 15);
                Lpm[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                Lpm[i].Cursor = System.Windows.Forms.Cursors.Arrow;
                Lpm[i].Name = "Lpm[" + i + "]";
                Lpm[i].SendToBack();

                //add the width of small panels
                X += 10;
                //default width of panelM in the form
                if (X > 1000)
                {
                    X = 0;
                    //draw panel in the new row
                    Y = +50;
                }
            

            }
        
           
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /* Drag & Drop */
        private Rectangle dragBoxFromMouseDown;
      //  private object valueFromMouseDown;
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                  //  DragDropEffects dropEffect = dataGridView1.DoDragDrop(valueFromMouseDown, DragDropEffects.Copy);
                }
            }

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
          //  var hittestInfo = dataGridView1.HitTest(e.X, e.Y);

           // if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
           // {
          //      valueFromMouseDown = dataGridView1.Rows[hittestInfo.RowIndex].Cells[hittestInfo.ColumnIndex].Value;
              //  if (valueFromMouseDown != null)
             //   {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                  //  dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
              //  }
         //   }
         //   else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
              //  dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
          //  Point clientPoint = dataGridView2.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                string cellvalue = e.Data.GetData(typeof(string)) as string;
           //     var hittest = dataGridView2.HitTest(clientPoint.X, clientPoint.Y);
             //   if (hittest.ColumnIndex != -1
                  //  && hittest.RowIndex != -1)
                //    dataGridView2[hittest.ColumnIndex, hittest.RowIndex].Value = cellvalue;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                object[] data = { i, "name" + i, i + 1000 };

             //   dataGridView1.Rows.Add(data);
             //   dataGridView2.Rows.Add();


            }
        }

        private void CategorySub_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyDoamSub.idCategory = ClassDivisionCategory.IdCategories[0];
        }

        private void DivisionSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyDoamSub.idDivision = ClassDivisionCategory.IdDivisiones[0];
        }

        private void ClassSub_SelectedIndexChanged(object sender, EventArgs e)
        {

            MyDoamSub.idClass = ClassDivisionCategory.IdClasses[0];
        }

        private void واجهة_الدوام_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoamSub.IsClosing=true;
        }
    }
}
