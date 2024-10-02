using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using VS2017POS.EntitiyFolder;

namespace POS.Misc {
    public class UserManager {
        public UserManager() {
            var settings = Properties.Settings.Default;

            var username = settings.Login_Username;
            var password = settings.Login_Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                return;
            }

            using (var context = new POSEntities()) {
                CurrentLogin = context.Logins.FirstOrDefault(x => x.Username == username && x.Password == password);
            }
        }
        public static UserManager instance;
        public Login CurrentLogin { get; private set; }
        public bool IsLoggedIn => CurrentLogin != null;
        public bool IsAdmin => CurrentLogin.Username.Equals("admin", StringComparison.OrdinalIgnoreCase);

        public bool Login(string username, string password) {
            string un = username.Trim();
            string pw = password.Trim();
            using (var p = new POSEntities()) {
                try {
                    CurrentLogin = p.Logins.FirstOrDefault(x => x.Username == un && x.Password == pw);
                    if (CurrentLogin != null)
                        return true;
                }
                catch {
                    // MessageBox.Show("Cannot connect to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
    }
}
