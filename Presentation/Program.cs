using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            //frmLogin loginForm = new frmLogin();
            //frmMainMenue mainMenue = new frmMainMenue();
            while (true)
            {
                using (frmLogin loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                        break;
                }

                using (frmMainMenue mainMenue = new frmMainMenue())
                {
                    if (mainMenue.ShowDialog() != DialogResult.Abort)
                        break;
                }
            }
            
        }
    }
}
