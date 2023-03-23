namespace MYSCHOOLFINAL
{
    partial class واجهة_sms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(واجهة_sms));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_from = new System.Windows.Forms.TextBox();
            this.txt_Tel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.زر_إلغاء_إرسال_sms = new System.Windows.Forms.Button();
            this.زر_إرسال_sms = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txt_message, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_title, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_from, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_Tel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_name, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // txt_message
            // 
            resources.ApplyResources(this.txt_message, "txt_message");
            this.txt_message.Name = "txt_message";
            // 
            // txt_title
            // 
            resources.ApplyResources(this.txt_title, "txt_title");
            this.txt_title.Name = "txt_title";
            // 
            // txt_from
            // 
            resources.ApplyResources(this.txt_from, "txt_from");
            this.txt_from.Name = "txt_from";
            // 
            // txt_Tel
            // 
            resources.ApplyResources(this.txt_Tel, "txt_Tel");
            this.txt_Tel.Name = "txt_Tel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.زر_إلغاء_إرسال_sms, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.زر_إرسال_sms, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // زر_إلغاء_إرسال_sms
            // 
            resources.ApplyResources(this.زر_إلغاء_إرسال_sms, "زر_إلغاء_إرسال_sms");
            this.زر_إلغاء_إرسال_sms.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources.CancelSms;
            this.زر_إلغاء_إرسال_sms.FlatAppearance.BorderSize = 0;
            this.زر_إلغاء_إرسال_sms.Name = "زر_إلغاء_إرسال_sms";
            this.زر_إلغاء_إرسال_sms.UseVisualStyleBackColor = true;
            // 
            // زر_إرسال_sms
            // 
            resources.ApplyResources(this.زر_إرسال_sms, "زر_إرسال_sms");
            this.زر_إرسال_sms.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources.SendSms;
            this.زر_إرسال_sms.FlatAppearance.BorderSize = 0;
            this.زر_إرسال_sms.Name = "زر_إرسال_sms";
            this.زر_إرسال_sms.UseVisualStyleBackColor = true;
            this.زر_إرسال_sms.Click += new System.EventHandler(this.زر_إرسال_sms_Click);
            // 
            // txt_name
            // 
            resources.ApplyResources(this.txt_name, "txt_name");
            this.txt_name.Name = "txt_name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // واجهة_sms
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "واجهة_sms";
            this.Load += new System.EventHandler(this.واجهة_sms_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button زر_إلغاء_إرسال_sms;
        private System.Windows.Forms.Button زر_إرسال_sms;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_message;
        public System.Windows.Forms.TextBox txt_title;
        public System.Windows.Forms.TextBox txt_from;
        public System.Windows.Forms.TextBox txt_Tel;
        public System.Windows.Forms.TextBox txt_name;
    }
}