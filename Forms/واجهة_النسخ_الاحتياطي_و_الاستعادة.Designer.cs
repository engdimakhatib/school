namespace MYSCHOOLFINAL
{
    partial class واجهة_النسخ_الاحتياطي_و_الاستعادة
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(واجهة_النسخ_الاحتياطي_و_الاستعادة));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.زر_استعادة_نسخة_احتياطية = new System.Windows.Forms.Button();
            this.زر = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.زر_استعادة_نسخة_احتياطية, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.زر, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // زر_استعادة_نسخة_احتياطية
            // 
            resources.ApplyResources(this.زر_استعادة_نسخة_احتياطية, "زر_استعادة_نسخة_احتياطية");
            this.زر_استعادة_نسخة_احتياطية.BackColor = System.Drawing.Color.White;
            this.زر_استعادة_نسخة_احتياطية.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._2920107;
            this.زر_استعادة_نسخة_احتياطية.FlatAppearance.BorderSize = 0;
            this.زر_استعادة_نسخة_احتياطية.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.زر_استعادة_نسخة_احتياطية.Name = "زر_استعادة_نسخة_احتياطية";
            this.زر_استعادة_نسخة_احتياطية.UseVisualStyleBackColor = false;
            this.زر_استعادة_نسخة_احتياطية.Click += new System.EventHandler(this.زر_إنشاء_نسخة_احتياطية_Click);
            // 
            // زر
            // 
            resources.ApplyResources(this.زر, "زر");
            this.زر.BackColor = System.Drawing.Color.White;
            this.زر.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._2818765;
            this.زر.FlatAppearance.BorderSize = 0;
            this.زر.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.زر.Name = "زر";
            this.زر.UseVisualStyleBackColor = false;
            this.زر.Click += new System.EventHandler(this.زر_استعادة_نسخة_احتياطية_Click);
            // 
            // واجهة_النسخ_الاحتياطي_و_الاستعادة
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "واجهة_النسخ_الاحتياطي_و_الاستعادة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.واجهة_النسخ_الاحتياطي_و_الاستعادة_FormClosing);
            this.Load += new System.EventHandler(this.واجهة_النسخ_الاحتياطي_و_الاستعادة_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button زر_استعادة_نسخة_احتياطية;
        private System.Windows.Forms.Button زر;
    }
}