using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class frmShow : Form
    {
        public frmShow()
        {
            InitializeComponent();
        }
//================================================================================ Variable & Functions

        public string LName = "";
        public string FName = "";
        public string PN = "";
        public string Mobile = "";
        public string Tozih = "";

//================================================================================ 
        //---------------------------------------------------------------
        private void frmShow_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            lblFName.Text = FName;
            lblLName.Text = LName;
            lblPN.Text = PN;
            lblMobile.Text = Mobile;
            lblTozih.Text = Tozih;
        }
        //---------------------------------------------------------------
        private void frmShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        //---------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
