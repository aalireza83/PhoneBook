using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//////
using System.Data.OleDb;
using System.Diagnostics;

namespace PhoneBook
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
//================================================================================ Variable & Functions
        
        string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\TelDB.mdb";
        
        string FName = "";
        string LName = "";

        public bool blEdit = false;
        public string FNameEdited = "";
        public string LNameEdited = "";

        //--------------------------------------------------------------- Fill dgv
        private void Filldgv(string strSqlQuery)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                OleDbConnection ocn = new OleDbConnection(ConnectionString);
                OleDbDataAdapter oda = new OleDbDataAdapter(strSqlQuery, ocn);
                DataTable dt = new DataTable();

                dt.Clear();
                oda.Fill(dt);


                /////
                dgv.Columns.Clear();

                dgv.DataSource = null;
                dgv.DataSource = dt;

                dgv.Columns[0].HeaderText = "نام خانوادگی";
                dgv.Columns[0].Width =180;
                dgv.Columns[0].Name = "LN";

                dgv.Columns[1].HeaderText = "نام";
                dgv.Columns[1].Width = 80;
                dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[1].Name = "FN";
                //////  

                dt.Dispose();
                oda.Dispose();
                ocn.Dispose();

                if (dgv.Rows.Count > 0)
                {
                    btnShow.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                }
                else
                {
                    btnShow.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
        }
        //---------------------------------------------------------------

//================================================================================ Variable & Functions
        //--------------------------------------------------------------- this_Load
        private void frmMain_Load(object sender, EventArgs e)
        {

            Filldgv("SELECT LName,FName FROM tblTel ORDER BY LName ASC,FName ASC");

            this.KeyPreview = true;
        }
        //--------------------------------------------------------------- this_KeyDown
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)//Del
            {
                if (btnDel.Enabled == true && txtFName.Focused == false && txtLName.Focused == false)
                    btnDel_Click(this, EventArgs.Empty);
            }
            if (e.KeyCode == Keys.Insert)//Insert
            {
                btnAdd_Click(this, EventArgs.Empty);
            }
        }
        //--------------------------------------------------------------- Filter By LName & FName
        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            Filldgv("SELECT LName,FName FROM tblTel WHERE LName LIKE '" + txtLName.Text + "%' AND FName LIKE '" + txtFName.Text + "%' ORDER BY LName ASC,FName ASC");
        }
        //--------------------------------------------------------------- Filter By LName & FName
        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            Filldgv("SELECT LName,FName FROM tblTel WHERE LName LIKE '" + txtLName.Text + "%' AND FName LIKE '" + txtFName.Text + "%' ORDER BY LName ASC,FName ASC");
        }
        //--------------------------------------------------------------- for Show
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnShow_Click(this, EventArgs.Empty);
            }
        }
        //--------------------------------------------------------------- Show
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                LName = dgv.CurrentRow.Cells["LN"].Value.ToString();
                FName = dgv.CurrentRow.Cells["FN"].Value.ToString();

                OleDbConnection ocn = new OleDbConnection(ConnectionString);
                
                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT PN,Mobile,Tozih FROM tblTel WHERE LName=@p1 AND FName=@p2",ocn);
                oda.SelectCommand.Parameters.Clear();
                oda.SelectCommand.Parameters.AddWithValue("@p1", LName);
                oda.SelectCommand.Parameters.AddWithValue("@p2", FName);
                
                DataTable dt = new DataTable();

                dt.Clear();
                oda.Fill(dt);
                
                object[] t = dt.Rows[0].ItemArray;

                dt.Dispose();
                oda.Dispose();
                ocn.Dispose();

                frmShow fs = new frmShow();
                 fs.LName = LName;
                 fs.FName = FName;
                 fs.PN = t[0].ToString();
                 fs.Mobile = t[1].ToString();
                 fs.Tozih = t[2].ToString();
                 fs.Text = "Show...";
                fs.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------- Edit

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LName = dgv.CurrentRow.Cells["LN"].Value.ToString();
                FName = dgv.CurrentRow.Cells["FN"].Value.ToString();

                OleDbConnection ocn = new OleDbConnection(ConnectionString);

                OleDbDataAdapter oda = new OleDbDataAdapter("SELECT PN,Mobile,Tozih FROM tblTel WHERE LName=@p1 AND FName=@p2", ocn);
                oda.SelectCommand.Parameters.Clear();
                oda.SelectCommand.Parameters.AddWithValue("@p1", LName);
                oda.SelectCommand.Parameters.AddWithValue("@p2", FName);

                DataTable dt = new DataTable();

                dt.Clear();
                oda.Fill(dt);

                object[] t = dt.Rows[0].ItemArray;

                dt.Dispose();
                oda.Dispose();
                ocn.Dispose();

                blEdit = false;

                frmEdit fe = new frmEdit();
                 fe.LName = LName;
                 fe.FName = FName;
                 fe.PN = t[0].ToString();
                 fe.Mobile = t[1].ToString();
                 fe.Tozih = t[2].ToString();
                 fe.Text = "Edit...";
                fe.ShowDialog();

                if (blEdit == true)
                {
                    Filldgv("SELECT LName,FName FROM tblTel ORDER BY LName ASC,FName ASC");

                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (dgv.Rows[i].Cells["LN"].Value.ToString() == LNameEdited &&
                            dgv.Rows[i].Cells["FN"].Value.ToString() == FNameEdited)
                        {
                            dgv.Rows[i].Selected = true;
                            dgv.CurrentCell = dgv.Rows[i].Cells[0];
                            break;
                        }
                    }

                    txtFName.Text = "";
                    txtLName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------- Del
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایلید مورد انتخاب شده حذف شود؟", "سوال(حذف)؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    LName = dgv.CurrentRow.Cells["LN"].Value.ToString();
                    FName = dgv.CurrentRow.Cells["FN"].Value.ToString();

                    OleDbConnection ocn = new OleDbConnection(ConnectionString);
                    OleDbCommand ocm = new OleDbCommand();

                    ocm.CommandText = "DELETE FROM tblTel WHERE LName=@p1 AND FName=@p2";
                    ocm.Parameters.Clear();
                    ocm.Parameters.AddWithValue("@p1", LName);
                    ocm.Parameters.AddWithValue("@p2", FName);

                    ocm.Connection = null;
                    ocm.Connection = ocn;

                    ocn.Open();
                     ocm.ExecuteNonQuery();
                    ocn.Close();

                    ocm.Dispose();
                    ocn.Dispose();

                    Filldgv("SELECT LName,FName FROM tblTel ORDER BY LName ASC,FName ASC");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------- Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            blEdit = false;//For Add
            
            frmAdd fa = new frmAdd();
            fa.ShowDialog();

            if (blEdit == true)
            {
                Filldgv("SELECT LName,FName FROM tblTel ORDER BY LName ASC,FName ASC");

                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Rows[i].Cells["LN"].Value.ToString() == LNameEdited &&
                        dgv.Rows[i].Cells["FN"].Value.ToString() == FNameEdited)
                    {
                        dgv.Rows[i].Selected = true;
                        dgv.CurrentCell = dgv.Rows[i].Cells[0];
                        break;
                    }
                }

                txtFName.Text = "";
                txtLName.Text = "";
            }
        }
        //--------------------------------------------------------------- About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmer: http://Open-Source.blogfa.com"
                +"\r\n\r\n"
                +"Email: Open_Source@ymail.com"
                +"\r\n\r\n"
                +"Mobile: ++989369073055"
                , "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //--------------------------------------------------------------- Backup
        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBR fbr = new frmBR();
             fbr.b = 'b';
            fbr.ShowDialog();
        }
        //--------------------------------------------------------------- Restore
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blEdit = false;//For Restore

            frmBR fbr = new frmBR();
             fbr.b = 'r';
            fbr.ShowDialog();

            if (blEdit == true)
                Filldgv("SELECT LName,FName FROM tblTel ORDER BY LName ASC,FName ASC");
        }
        //--------------------------------------------------------------- Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //---------------------------------------------------------------


       



    }
}
