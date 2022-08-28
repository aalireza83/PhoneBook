namespace PhoneBook
{
    partial class frmEdit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTozih = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtPN = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTozih);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.txtPN);
            this.groupBox1.Controls.Add(this.txtLName);
            this.groupBox1.Controls.Add(this.txtFName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 275);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtTozih
            // 
            this.txtTozih.Location = new System.Drawing.Point(20, 170);
            this.txtTozih.MaxLength = 200;
            this.txtTozih.Multiline = true;
            this.txtTozih.Name = "txtTozih";
            this.txtTozih.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTozih.Size = new System.Drawing.Size(226, 83);
            this.txtTozih.TabIndex = 16;
            this.txtTozih.Leave += new System.EventHandler(this.txtTozih_Leave);
            this.txtTozih.Enter += new System.EventHandler(this.txtTozih_Enter);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(80, 130);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(166, 22);
            this.txtMobile.TabIndex = 15;
            this.txtMobile.Leave += new System.EventHandler(this.txtMobile_Leave);
            this.txtMobile.Enter += new System.EventHandler(this.txtMobile_Enter);
            // 
            // txtPN
            // 
            this.txtPN.Location = new System.Drawing.Point(102, 90);
            this.txtPN.MaxLength = 20;
            this.txtPN.Name = "txtPN";
            this.txtPN.Size = new System.Drawing.Size(144, 22);
            this.txtPN.TabIndex = 14;
            this.txtPN.Leave += new System.EventHandler(this.txtPN_Leave);
            this.txtPN.Enter += new System.EventHandler(this.txtPN_Enter);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(43, 54);
            this.txtLName.MaxLength = 40;
            this.txtLName.Name = "txtLName";
            this.txtLName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLName.Size = new System.Drawing.Size(203, 22);
            this.txtLName.TabIndex = 13;
            this.txtLName.Leave += new System.EventHandler(this.txtLName_Leave);
            this.txtLName.Enter += new System.EventHandler(this.txtLName_Enter);
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(118, 19);
            this.txtFName.MaxLength = 25;
            this.txtFName.Name = "txtFName";
            this.txtFName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFName.Size = new System.Drawing.Size(128, 22);
            this.txtFName.TabIndex = 12;
            this.txtFName.Leave += new System.EventHandler(this.txtFName_Leave);
            this.txtFName.Enter += new System.EventHandler(this.txtFName_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 172);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "توضیحات:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 133);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "موبایل:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 93);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "تلفن:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 22);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(25, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 57);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(76, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام خانوادگی:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(265, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(4, 278);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 306);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEdit";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEdit_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTozih;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtPN;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Button btnEdit;
    }
}