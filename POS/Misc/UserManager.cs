using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VS2017POS.EntitiyFolder;

namespace POS.Misc
{
    public class UserManager
    {
        public static UserManager instance;
        public Login currentLogin { get; private set; }

        public bool Login(string username, string password)
        {
            string un = username.Trim(' ');
            string pw = password.Trim(' ');
            using (var p = new POSEntities())
            {
                currentLogin = p.Logins.FirstOrDefault(x => x.Username == un && x.Password == pw);
                if (currentLogin != null)
                    return true;
            }
            return false;
        }
    }
}
