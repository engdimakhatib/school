namespace MYSCHOOLFINAL
{
    partial class واجهة_استعادة_نسخة_احتياطية
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(واجهة_استعادة_نسخة_احتياطية));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.زر_فتح_ملف = new System.Windows.Forms.Button();
            this.زر_إنشاء_نسخة_احتياطية = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.زر_فتح_ملف, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.زر_إنشاء_نسخة_احتياطية, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // زر_فتح_ملف
            // 
            resources.ApplyResources(this.زر_فتح_ملف, "زر_فتح_ملف");
            this.زر_فتح_ملف.BackColor = System.Drawing.Color.Teal;
            this.زر_فتح_ملف.ForeColor = System.Drawing.Color.White;
            this.زر_فتح_ملف.Name = "زر_فتح_ملف";
            this.زر_فتح_ملف.UseVisualStyleBackColor = false;
            this.زر_فتح_ملف.Click += new System.EventHandler(this.زر_فتح_ملف_Click);
            // 
            // زر_إنشاء_نسخة_احتياطية
            // 
            resources.ApplyResources(this.زر_إنشاء_نسخة_احتياطية, "زر_إنشاء_نسخة_احتياطية");
            this.زر_إنشاء_نسخة_احتياطية.BackColor = System.Drawing.Color.Teal;
            this.زر_إنشاء_نسخة_احتياطية.ForeColor = System.Drawing.Color.White;
            this.زر_إنشاء_نسخة_احتياطية.Name = "زر_إنشاء_نسخة_احتياطية";
            this.زر_إنشاء_نسخة_احتياطية.UseVisualStyleBackColor = false;
            this.زر_إنشاء_نسخة_احتياطية.Click += new System.EventHandler(this.زر_إنشاء_نسخة_احتياطية_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txt_FileName, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Name = "label1";
            // 
            // txt_FileName
            // 
            resources.ApplyResources(this.txt_FileName, "txt_FileName");
            this.txt_FileName.Name = "txt_FileName";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Name = "label5";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // واجهة_استعادة_نسخة_احتياطية
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "واجهة_استعادة_نسخة_احتياطية";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.واجهة_استعادة_نسخة_احتياطية_FormClosing);
            this.Load += new System.EventHandler(this.واجهة_استعادة_نسخة_احتياطية_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button زر_فتح_ملف;
        private System.Windows.Forms.Button زر_إنشاء_نسخة_احتياطية;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}