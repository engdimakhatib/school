namespace MYSCHOOLFINAL
{
    partial class واجهة_إدارة_الفئات
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(واجهة_إدارة_الفئات));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NameCategory = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DGV_Category = new System.Windows.Forms.DataGridView();
            this.زر_حذف_فئة = new System.Windows.Forms.Button();
            this.زر_إضافة_فئة = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Category)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.DGV_Category, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.NameCategory, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // NameCategory
            // 
            resources.ApplyResources(this.NameCategory, "NameCategory");
            this.NameCategory.Name = "NameCategory";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.زر_حذف_فئة, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.زر_إضافة_فئة, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // DGV_Category
            // 
            resources.ApplyResources(this.DGV_Category, "DGV_Category");
            this.DGV_Category.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Category.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Category.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Category.Name = "DGV_Category";
            this.DGV_Category.DoubleClick += new System.EventHandler(this.DGV_Category_DoubleClick);
            // 
            // زر_حذف_فئة
            // 
            resources.ApplyResources(this.زر_حذف_فئة, "زر_حذف_فئة");
            this.زر_حذف_فئة.BackColor = System.Drawing.Color.White;
            this.زر_حذف_فئة.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._4672826;
            this.زر_حذف_فئة.FlatAppearance.BorderSize = 0;
            this.زر_حذف_فئة.Name = "زر_حذف_فئة";
            this.زر_حذف_فئة.UseVisualStyleBackColor = false;
            this.زر_حذف_فئة.Click += new System.EventHandler(this.زر_حذف_فئة_Click);
            // 
            // زر_إضافة_فئة
            // 
            resources.ApplyResources(this.زر_إضافة_فئة, "زر_إضافة_فئة");
            this.زر_إضافة_فئة.BackColor = System.Drawing.Color.White;
            this.زر_إضافة_فئة.BackgroundImage = global::MYSCHOOLFINAL.Properties.Resources._31148242;
            this.زر_إضافة_فئة.FlatAppearance.BorderSize = 0;
            this.زر_إضافة_فئة.Name = "زر_إضافة_فئة";
            this.زر_إضافة_فئة.UseVisualStyleBackColor = false;
            this.زر_إضافة_فئة.Click += new System.EventHandler(this.زر_إضافة_فئة_Click);
            // 
            // واجهة_إدارة_الفئات
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "واجهة_إدارة_الفئات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.واجهة_إدارة_الفئات_FormClosing);
            this.Load += new System.EventHandler(this.واجهة_إدارة_الفئات_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Category)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button زر_حذف_فئة;
        private System.Windows.Forms.Button زر_إضافة_فئة;
        private System.Windows.Forms.DataGridView DGV_Category;
        private System.Windows.Forms.TextBox NameCategory;
    }
}