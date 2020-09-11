using POS.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Interfaces.IMainWindow mainWindow;
            UserManager.instance = new UserManager();
            do
            {
                var login = new Forms.LoginForm();
                Application.Run(login);

                var main = new Main();
                mainWindow = main;
                if (login.LoginSuccessful)
                {
                    Application.Run(main);
                }

            }
            while (mainWindow.IsSignout());
        }
    }
}
