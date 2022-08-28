using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/////
using System.Data.OleDb;

namespace PhoneBook
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }
//================================================================================ Variable & Functions

        string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\TelDB.mdb";

//================================================================================ 
        //--------------------------------------------------------------- Load
        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        //--------------------------------------------------------------- Close
        private void frmAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        //--------------------------------------------------------------- Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------- Add
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtFName.Text == "" || txtLName.Text == "" || txtPN.Text == "" || txtMobile.Text == "" || txtTozih.Text == "")
            {
                MessageBox.Show("لطفا همه موارد خواسته شده را پر کنید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    OleDbConnection ocn = new OleDbConnection(ConnectionString);
                    
                    OleDbDataAdapter oda = new OleDbDataAdapter("SELECT FName,LName FROM tblTel WHERE FName=@p1 AND LName=@p2", ocn);
                    oda.SelectCommand.Parameters.Clear();
                    oda.SelectCommand.Parameters.AddWithValue("@p1", txtFName.Text);
                    oda.SelectCommand.Parameters.AddWithValue("@p2", txtLName.Text);
                    
                    DataTable dt = new DataTable();
                                        
                    dt.Clear();
                    oda.Fill(dt);
                    
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("این شخص قبلا در بانک ثبت شده؛ لطفا شخص غیر تکراری وارد کنید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFName.Focus();
                    }
                    else
                    {
                        OleDbCommand ocm = new OleDbCommand();

                        ocm.CommandText = "INSERT INTO tblTel (FName,LName,PN,Mobile,Tozih) VALUES (@p1,@p2,@p3,@p4,@p5)";
                        ocm.Parameters.Clear();
                        ocm.Parameters.AddWithValue("@p1", txtFName.Text);
                        ocm.Parameters.AddWithValue("@p2", txtLName.Text);
                        ocm.Parameters.AddWithValue("@p3", txtPN.Text);
                        ocm.Parameters.AddWithValue("@p4", txtMobile.Text);
                        ocm.Parameters.AddWithValue("@p5", txtTozih.Text);

                        ocm.Connection = null;
                        ocm.Connection = ocn;

                        ocn.Open();
                         ocm.ExecuteNonQuery();
                        ocn.Close();

                        ocm.Dispose();
                        
                        MessageBox.Show("شخص مورد نظر با موفقیت اضافه شد", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmMain fm = (frmMain)Application.OpenForms["frmMain"];
                        fm.blEdit = true;
                        fm.LNameEdited = txtLName.Text;
                        fm.FNameEdited = txtFName.Text;

                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtPN.Text = "";
                        txtMobile.Text = "";
                        txtTozih.Text = "";
                        txtFName.Focus();
                    }

                    dt.Dispose();
                    oda.Dispose();
                    ocn.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //----------------------------------------------------------------

        #region "TextBox Color"

        private void txtFName_Enter(object sender, EventArgs e)
        {
            txtFName.ForeColor = System.Drawing.Color.Blue;
            txtFName.BackColor = System.Drawing.Color.LightYellow;
        }
        private void txtFName_Leave(object sender, EventArgs e)
        {
            txtFName.ForeColor = System.Drawing.SystemColors.WindowText;
            txtFName.BackColor = System.Drawing.SystemColors.Window;
        }
        //----------
        private void txtLName_Enter(object sender, EventArgs e)
        {
            txtLName.ForeColor = System.Drawing.Color.Blue;
            txtLName.BackColor = System.Drawing.Color.LightYellow;
        }
        private void txtLName_Leave(object sender, EventArgs e)
        {
            txtLName.ForeColor = System.Drawing.SystemColors.WindowText;
            txtLName.BackColor = System.Drawing.SystemColors.Window;
        }
        //----------
        private void txtPN_Enter(object sender, EventArgs e)
        {
            txtPN.ForeColor = System.Drawing.Color.Blue;
            txtPN.BackColor = System.Drawing.Color.LightYellow;
        }
        private void txtPN_Leave(object sender, EventArgs e)
        {
            txtPN.ForeColor = System.Drawing.SystemColors.WindowText;
            txtPN.BackColor = System.Drawing.SystemColors.Window;
        }
        //----------
        private void txtMobile_Enter(object sender, EventArgs e)
        {
            txtMobile.ForeColor = System.Drawing.Color.Blue;
            txtMobile.BackColor = System.Drawing.Color.LightYellow;
        }
        private void txtMobile_Leave(object sender, EventArgs e)
        {
            txtMobile.ForeColor = System.Drawing.SystemColors.WindowText;
            txtMobile.BackColor = System.Drawing.SystemColors.Window;
        }
        //----------
        private void txtTozih_Enter(object sender, EventArgs e)
        {
            txtTozih.ForeColor = System.Drawing.Color.Blue;
            txtTozih.BackColor = System.Drawing.Color.LightYellow;
        }
        private void txtTozih_Leave(object sender, EventArgs e)
        {
            txtTozih.ForeColor = System.Drawing.SystemColors.WindowText;
            txtTozih.BackColor = System.Drawing.SystemColors.Window;
        }

        #endregion

    }
}
