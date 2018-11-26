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
        public String lastName { get; set; }
        public String otherName { get; set; }
        public String DOB { get; set; }
        public User()
        {

        }

        public User(String firstName, String lastname, String otherName, String username, String password, String DOB)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.otherName = otherName;
            this.username = username;
            this.password = password;
            this.DOB = DOB;
        }
    }
}
