namespace MYSCHOOLFINAL.Forms
{
    partial class واجهة_إضافة_مستخدم_جديد
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.cmb_userrole = new System.Windows.Forms.ComboBox();
            this.txtuser_pass = new System.Windows.Forms.TextBox();
            this.txtuser_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.زر_بحث_عن_مستخدم = new System.Windows.Forms.Button();
            this.زر_تعديل_مستخدم = new System.Windows.Forms.Button();
            this.زر_حفظ_مستخدم = new System.Windows.Forms.Button();
            this.زر_حذف_مستخدم = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuser_search = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.88889F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 593);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.panel2.Controls.Add(this.dataGridViewUser);
            this.panel2.Controls.Add(this.cmb_userrole);
            this.panel2.Controls.Add(this.txtuser_pass);
            this.panel2.Controls.Add(this.txtuser_name);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 587);
            this.panel2.TabIndex = 7;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUser.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 14.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewUser.EnableHeadersVisualStyles = false;
            this.dataGridViewUser.GridColor = System.Drawing.Color.Black;
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 154);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUser.Name = "dataGridViewUser";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridViewUser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.Size = new System.Drawing.Size(430, 433);
            this.dataGridViewUser.TabIndex = 53;
            this.dataGridViewUser.SelectionChanged += new System.EventHandler(this.DataGridViewUser_SelectionChanged);
            // 
            // cmb_userrole
            // 
            this.cmb_userrole.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_userrole.FormattingEnabled = true;
            this.cmb_userrole.Location = new System.Drawing.Point(9, 105);
            this.cmb_userrole.Name = "cmb_userrole";
            this.cmb_userrole.Size = new System.Drawing.Size(270, 26);
            this.cmb_userrole.TabIndex = 11;
            // 
            // txtuser_pass
            // 
            this.txtuser_pass.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser_pass.Location = new System.Drawing.Point(9, 57);
            this.txtuser_pass.Name = "txtuser_pass";
            this.txtuser_pass.Size = new System.Drawing.Size(270, 27);
            this.txtuser_pass.TabIndex = 10;
            this.txtuser_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtuser_name
            // 
            this.txtuser_name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser_name.Location = new System.Drawing.Point(9, 15);
            this.txtuser_name.Name = "txtuser_name";
            this.txtuser_name.Size = new System.Drawing.Size(270, 27);
            this.txtuser_name.TabIndex = 9;
            this.txtuser_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(285, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "المنصب";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(285, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "كلمة المرور";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(285, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "اسم المستخدم";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtuser_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(439, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 587);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.زر_بحث_عن_مستخدم, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.زر_تعديل_مستخدم, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.زر_حفظ_مستخدم, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.زر_حذف_مستخدم, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 154);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 433);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // زر_بحث_عن_مستخدم
            // 
            this.زر_بحث_عن_مستخدم.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.زر_بحث_عن_مستخدم.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.زر_بحث_عن_مستخدم.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.زر_بحث_عن_مستخدم.FlatAppearance.BorderSize = 0;
            this.زر_بحث_عن_مستخدم.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.زر_بحث_عن_مستخدم.ForeColor = System.Drawing.Color.White;
            this.زر_بحث_عن_مستخدم.Location = new System.Drawing.Point(70, 12);
            this.زر_بحث_عن_مستخدم.Margin = new System.Windows.Forms.Padding(4);
            this.زر_بحث_عن_مستخدم.Name = "زر_بحث_عن_مستخدم";
            this.زر_بحث_عن_مستخدم.Size = new System.Drawing.Size(100, 98);
            this.زر_بحث_عن_مستخدم.TabIndex = 0;
            this.زر_بحث_عن_مستخدم.Text = "بحث";
            this.زر_بحث_عن_مستخدم.UseVisualStyleBackColor = false;
            this.زر_بحث_عن_مستخدم.Click += new System.EventHandler(this.زر_بحث_عن_مستخدم_Click);
            // 
            // زر_تعديل_مستخدم
            // 
            this.زر_تعديل_مستخدم.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.زر_تعديل_مستخدم.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(165)))), ((int)(((byte)(161)))));
            this.زر_تعديل_مستخدم.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.زر_تعديل_مستخدم.FlatAppearance.BorderSize = 0;
            this.زر_تعديل_مستخدم.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.زر_تعديل_مستخدم.ForeColor = System.Drawing.Color.White;
            this.زر_تعديل_مستخدم.Location = new System.Drawing.Point(70, 118);
            this.زر_تعديل_مستخدم.Margin = new System.Windows.Forms.Padding(4);
            this.زر_تعديل_مستخدم.Name = "زر_تعديل_مستخدم";
            this.زر_تعديل_مستخدم.Size = new System.Drawing.Size(100, 98);
            this.زر_تعديل_مستخدم.TabIndex = 1;
            this.زر_تعديل_مستخدم.Text = "تعديل";
            this.زر_تعديل_مستخدم.UseVisualStyleBackColor = false;
            this.زر_تعديل_مستخدم.Click += new System.EventHandler(this.زر_تعديل_مستخدم_Click);
            // 
            // زر_حفظ_مستخدم
            // 
            this.زر_حفظ_مستخدم.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.زر_حفظ_مستخدم.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(169)))), ((int)(((byte)(180)))));
            this.زر_حفظ_مستخدم.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.زر_حفظ_مستخدم.FlatAppearance.BorderSize = 0;
            this.زر_حفظ_مستخدم.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.زر_حفظ_مستخدم.ForeColor = System.Drawing.Color.White;
            this.زر_حفظ_مستخدم.Location = new System.Drawing.Point(70, 224);
            this.زر_حفظ_مستخدم.Margin = new System.Windows.Forms.Padding(4);
            this.زر_حفظ_مستخدم.Name = "زر_حفظ_مستخدم";
            this.زر_حفظ_مستخدم.Size = new System.Drawing.Size(100, 98);
            this.زر_حفظ_مستخدم.TabIndex = 2;
            this.زر_حفظ_مستخدم.Text = "حفظ";
            this.زر_حفظ_مستخدم.UseVisualStyleBackColor = false;
            this.زر_حفظ_مستخدم.Click += new System.EventHandler(this.زر_حفظ_مستخدم_Click);
            // 
            // زر_حذف_مستخدم
            // 
            this.زر_حذف_مستخدم.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.زر_حذف_مستخدم.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(116)))), ((int)(((byte)(129)))));
            this.زر_حذف_مستخدم.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.زر_حذف_مستخدم.FlatAppearance.BorderSize = 0;
            this.زر_حذف_مستخدم.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.زر_حذف_مستخدم.ForeColor = System.Drawing.Color.White;
            this.زر_حذف_مستخدم.Location = new System.Drawing.Point(70, 330);
            this.زر_حذف_مستخدم.Margin = new System.Windows.Forms.Padding(4);
            this.زر_حذف_مستخدم.Name = "زر_حذف_مستخدم";
            this.زر_حذف_مستخدم.Size = new System.Drawing.Size(100, 99);
            this.زر_حذف_مستخدم.TabIndex = 3;
            this.زر_حذف_مستخدم.Text = "مسح";
            this.زر_حذف_مستخدم.UseVisualStyleBackColor = false;
            this.زر_حذف_مستخدم.Click += new System.EventHandler(this.زر_حذف_مستخدم_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(176, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "بحث";
            // 
            // txtuser_search
            // 
            this.txtuser_search.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser_search.Location = new System.Drawing.Point(11, 104);
            this.txtuser_search.Name = "txtuser_search";
            this.txtuser_search.Size = new System.Drawing.Size(229, 27);
            this.txtuser_search.TabIndex = 4;
            this.txtuser_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.379727F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.62027F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(688, 661);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(173, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 62);
            this.label5.TabIndex = 6;
            this.label5.Text = "واجهة إضافة مستخدم جديد";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // واجهة_إضافة_مستخدم_جديد
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(94)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(688, 661);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "واجهة_إضافة_مستخدم_جديد";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "واجهة سنضيف فيها مستخدم جديد مع تحديد المنصب أو الوظيفة التي سيشغلها";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.واجهة_إضافة_مستخدم_جديد_FormClosing);
            this.Load += new System.EventHandler(this.واجهة_إضافة_مستخدم_جديد_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmb_userrole;
        private System.Windows.Forms.TextBox txtuser_pass;
        private System.Windows.Forms.TextBox txtuser_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuser_search;
        private System.Windows.Forms.Button زر_بحث_عن_مستخدم;
        private System.Windows.Forms.Button زر_تعديل_مستخدم;
        private System.Windows.Forms.Button زر_حذف_مستخدم;
        private System.Windows.Forms.Button زر_حفظ_مستخدم;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
    }
}