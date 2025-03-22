using OfficeOpenXml;
using POS.Forms;
using POS.Misc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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

            ConnectionConfiguration_Source.Initialize();

            //test for showing the installation path
            /*
             * string installPath = Assembly.GetExecutingAssembly().Location;
            MessageBox.Show(installPath);
            */

            bool performBackup = false;
            UserManager.instance = new UserManager();

            bool signedOut;

            do
            {
                signedOut = false;
                var login = new LoginForm();
                Application.Run(login);

                if (login.LoginSuccessful)
                {
                    login.Dispose();

                    performBackup = true;

                    var main = new Main();
                    Application.Run(main);

                    signedOut = main.IsLoggedOut;
                    main.Dispose();
                }
                GC.Collect();
            }
            while (signedOut);

            //#if !DEBUG
            if (performBackup)
            {
                try
                {
                    using (var p = new POSEntities()) p.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, @"EXEC [dbo].[sp_backup]");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //#endif
        }
    }
}
