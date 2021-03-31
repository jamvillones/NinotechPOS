using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            Interfaces.IMainWindow mainWindow = null;
            bool backup = false;
            UserManager.instance = new UserManager();

            do
            {
                var login = new Forms.LoginForm();
                Application.Run(login);

                if (login.LoginSuccessful)
                {
                    backup = true;

                    var main = new Main();

                    mainWindow = main;

                    Application.Run(main);
                }
            }
            while (mainWindow?.IsSignout() ?? false);

            if (backup)
            {
                try
                {
                    using (var p = new POSEntities())
                        p.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"EXEC [dbo].[sp_backup]");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Backup failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
