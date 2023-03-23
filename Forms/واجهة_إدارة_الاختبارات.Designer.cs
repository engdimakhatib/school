namespace MYSCHOOLFINAL
{
    partial class واجهة_إدارة_الاختبارات
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(واجهة_إدارة_الاختبارات));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.زر_حذف_اختبار = new System.Windows.Forms.Button();
            this.زر_إضافة_اختبار = new System.Windows.Forms.Button();
            this.DGV_Exam = new System.Windows.Forms.DataGridView();
            this.NameExam = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Exam)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DGV_Exam, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.NameExam, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.زر_حذف_اختبار, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.زر_إضافة_اختبار, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // زر_حذف_اختبار
            // 
            resources.ApplyResources(this.زر_حذف_اختبار, "زر_حذف_اختبار");
            this.زر_حذف_اختبار.BackColor = System.Drawing.Color.White;
            this.زر_حذف_اختبار.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._4672826;
            this.زر_حذف_اختبار.FlatAppearance.BorderSize = 0;
            this.زر_حذف_اختبار.Name = "زر_حذف_اختبار";
            this.زر_حذف_اختبار.UseVisualStyleBackColor = false;
            this.زر_حذف_اختبار.Click += new System.EventHandler(this.زر_حذف_اختبار_Click);
            // 
            // زر_إضافة_اختبار
            // 
            resources.ApplyResources(this.زر_إضافة_اختبار, "زر_إضافة_اختبار");
            this.زر_إضافة_اختبار.BackColor = System.Drawing.Color.White;
            this.زر_إضافة_اختبار.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._31148242;
            this.زر_إضافة_اختبار.FlatAppearance.BorderSize = 0;
            this.زر_إضافة_اختبار.Name = "زر_إضافة_اختبار";
            this.زر_إضافة_اختبار.UseVisualStyleBackColor = false;
            this.زر_إضافة_اختبار.Click += new System.EventHandler(this.زر_إضافة_اختبار_Click);
            // 
            // DGV_Exam
            // 
            resources.ApplyResources(this.DGV_Exam, "DGV_Exam");
            this.DGV_Exam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Exam.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Exam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Exam.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Exam.Name = "DGV_Exam";
            this.DGV_Exam.DoubleClick += new System.EventHandler(this.DGV_Exam_DoubleClick);
            // 
            // NameExam
            // 
            resources.ApplyResources(this.NameExam, "NameExam");
            this.NameExam.Name = "NameExam";
            // 
            // واجهة_إدارة_الاختبارات
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "واجهة_إدارة_الاختبارات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.واجهة_إدارة_الاختبارات_FormClosing);
            this.Load += new System.EventHandler(this.واجهة_إدارة_الاختبارات_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Exam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button زر_حذف_اختبار;
        private System.Windows.Forms.Button زر_إضافة_اختبار;
        private System.Windows.Forms.DataGridView DGV_Exam;
        private System.Windows.Forms.TextBox NameExam;
    }
}