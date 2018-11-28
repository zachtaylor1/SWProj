using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SWProjv1
{
    class Furniture
    {
        public String serialNum { get; set; }
        public String name { get; set; }
        public CheckBox removeMe { get; set; }
        String roomID;
        public Furniture(String serialNum, String name, String roomID)
        {
            this.serialNum = serialNum;
            this.name = name;
            this.roomID = roomID;
            removeMe = new CheckBox();
        }
        public Furniture() { }
    }
}
