using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using VS2017POS.EntitiyFolder;

namespace POS.Misc
{
    public class UserManager
    {
        public UserManager()
        {
            //var settings = Properties.Settings.Default;

            //var username = settings.Login_Username;
            //var password = settings.Login_Password;

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //{
            //    return;
            //}

            //using (var context = POSEntities.Create())
            //{
            //    CurrentLogin = context.Logins.FirstOrDefault(x => x.Username == username && x.Password == password);
            //}
        }
        public static UserManager instance;
        public Login CurrentLogin { get; private set; }
        public bool IsLoggedIn => CurrentLogin != null;
        public bool IsAdmin => CurrentLogin?.Username.Equals("admin", StringComparison.OrdinalIgnoreCase) ?? false;

        public void LogOut()
        {
            CurrentLogin = null;
            var settings = Properties.Settings.Default;
            settings.Login_Username = null;
            settings.Save();
        }

        public async Task<bool> Login_Async(string username, string password, bool stayLoggedIn = false)
        {
            var settings = Properties.Settings.Default;
            string un = username.Trim();
            string pw = password.Trim();
            using (var p = POSEntities.Create())
            {
                try
                {
                    var login = await p.Logins.FirstOrDefaultAsync(x => x.Username == un && x.Password == pw);

                    if (login != null)
                    {
                        if (!login.CanEditProduct)
                            throw new LoginNotAuthorized();

                        if (stayLoggedIn)
                        {
                            settings.Login_Username = login.Username;
                            settings.Login_Password = login.Password;
                            settings.Save();
                        }


                        CurrentLogin = login;
                        return true;

                    }
                }
                catch (LoginNotAuthorized)
                {
                    MessageBox.Show("Login Not Authorized By Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public bool Login(string username)
        {

            string un = username.Trim();
            using (var p = POSEntities.Create())
            {
                try
                {
                    var login = p.Logins.FirstOrDefault(x => x.Username == un);

                    if (!login.CanEditProduct)
                        throw new LoginNotAuthorized();

                    if (login != null)
                    {
                        CurrentLogin = login;
                        return true;
                    }
                }
                catch (LoginNotAuthorized)
                {
                    MessageBox.Show("Login Not Authorized By Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    var settings = Properties.Settings.Default;
                    settings.Login_Username = null;
                    settings.Save();

                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
    public class LoginNotAuthorized : Exception
    {

    }
}
