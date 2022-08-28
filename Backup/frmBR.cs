using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
////
using System.IO;

namespace PhoneBook
{
    public partial class frmBR : Form
    {
        public frmBR()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------
        public Char b = 'b';//'b'=backup  'r'=restore
        
        //--------------------------------------------------------------- Load
        private void frmBR_Load(object sender, EventArgs e)
        {
            if (b == 'b')
                button1.Text = "Backup...";
            else
                button1.Text = "Restore...";

            this.KeyPreview = true;
        }
        //--------------------------------------------------------------- Backup & Restore
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == 'b') //Backup
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.BKSenTel |*.BKSenTel";
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName != "")
                    {
                        try
                        {
                            if (File.Exists(sfd.FileName) == true)
                                File.Delete(sfd.FileName);
                            File.Copy(Application.StartupPath + "\\TelDB.mdb", sfd.FileName);
                            MessageBox.Show("از بانک برنامه با موفقیت کپی پشتیبان گرفته شد", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else //Restore
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*.BKSenTel |*.BKSenTel";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName != "")
                    {
                        try
                        {
                            if (MessageBox.Show("آیا میخواهید فایل پشتیبان، جایگزین بانک فعلی برنامه شود؟؟؟(!!! توجه: بانک فعلی کامل از بین میرود !!!)؟؟؟", "سوال خیلی مهم؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                File.Delete(Application.StartupPath + "\\TelDB.mdb");
                                File.Copy(ofd.FileName, Application.StartupPath + "\\TelDB.mdb");
                                MessageBox.Show("بانک برنامه با موفقیت بازیابی شد", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                frmMain fm = (frmMain)Application.OpenForms["frmMain"];
                                fm.blEdit = true;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        //---------------------------------------------------------------
        private void frmBR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        //--------------------------------------------------------------- 
    }
}
