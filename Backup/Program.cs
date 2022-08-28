using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/////
using System.Threading;

namespace PhoneBook
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true,Application.ProductName, out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("این برنامه قبلا اجرا شده است", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
