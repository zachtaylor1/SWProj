using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SWProjv1
{
    public class Admin : User
    {
        public String adminID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public Admin()
        {
        }
    }
}