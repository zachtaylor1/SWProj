using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProjv1
{
    public class User
    {
        private String username;
        private String password;
        public String firstName { get; set; }
        String lastName { get; set; }
        public User()
        {

        }
        public int VerifyLogin(String username)
        {
            if (username.Equals("student")) return 0;
            else if (username.Equals("RA") || username.Equals("ra")) return 1;
            else if (username.Equals("admin")) return 2;
            else return 10;
        }
    }
}
