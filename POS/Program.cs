using OfficeOpenXml;
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
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            bool backup = false;
            bool signedOut = false;

            UserManager.instance = new UserManager();

            do
            {
                signedOut = false;

                var login = new Forms.LoginForm();
                Application.Run(login);

                if (login.LoginSuccessful)
                {
                    login.Dispose();
                    backup = true;

                    var main = new Main();

                    Application.Run(main);

                    signedOut = main.IsSigneout;
                    main.Dispose();
                }
                GC.Collect();
            }
            while (signedOut);

            if (backup)
            {
                try
                {
                    using (var p = new POSEntities())
                        p.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"EXEC [dbo].[sp_backup]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Application.Run(new SellItem());
        }
    }
}
