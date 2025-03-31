using OfficeOpenXml;
using POS.Forms;
using POS.Misc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            ConnectionConfiguration_Source.Initialize();
            WindowConfiguration.Initialize();

            //test for showing the installation path
            /*
             * string installPath = Assembly.GetExecutingAssembly().Location;
            MessageBox.Show(installPath);
            */

            bool performBackup = false;
            UserManager.instance = new UserManager();

            //bool signedOut;

            do
            {

                var settings = Properties.Settings.Default;

                if (!string.IsNullOrEmpty(settings.Login_Username))
                {
                    if (!UserManager.instance.Login(settings.Login_Username))
                    {
                        MessageBox.Show("Saved Log In is no longer Available", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ///if the automatic login is not successful, show login form
                if (!UserManager.instance.IsLoggedIn)
                    Application.Run(new LoginForm());


                if (UserManager.instance.IsLoggedIn)
                {
                    var main = new Main();
                    if (WindowConfiguration.Instance != null)
                    {
                        main.WindowState = WindowConfiguration.Instance.WindowState;
                    }
                    Application.Run(main);
                    main.Dispose();
                }
                /// terminate loop when there is no login
                else break;

                //GC.Collect();
            }
            while (!UserManager.instance.IsLoggedIn);

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
