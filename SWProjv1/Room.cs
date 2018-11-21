using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWProjv1
{
    class Room
    {
        public String roomNum { get; set; }
        public String roomSide { get; set; }
        public String building { get; set; }
        public String phoneNumber { get; set; }
        public String mailing { get; set; }
        public String roomID { get; set; }
        public ListBoxItem listboxitem;
        public Room(String roomID, String roomSide, String building, String phoneNumber, String mailing, String roomNum)
        {
            this.roomID = roomID;
            this.roomSide = roomSide;
            this.roomNum = roomNum;
            this.building = building;
            this.phoneNumber = phoneNumber;
            this.mailing = mailing;
        }

        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = roomNum + roomSide + " " + building;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }

    }
}
