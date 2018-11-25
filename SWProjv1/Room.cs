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
        public static Room selectedRoom { get; set; }
        public String roomNum { get; set; }
        public String roomSide { get; set; }
        public String building { get; set; }
        public String phoneNumber { get; set; }
        public String mailing { get; set; }
        public String roomID { get; set; }
        public ListBoxItem listboxitem;
        public Grid grid;
        //public TextBox textBox;
        public Room(String roomID, String roomSide, String building, String phoneNumber, String mailing, String roomNum)
        {
            this.roomID = roomID;
            this.roomSide = roomSide;
            this.roomNum = roomNum;
            this.building = building;
            this.phoneNumber = phoneNumber;
            this.mailing = mailing;
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            TextBox textBox = new TextBox();
            textBox.Text = roomNum + roomSide + " " + building + "\nPhone Number: " + phoneNumber + "\nMailing Address: " + mailing;
            Grid.SetRow(textBox, 0);
            Grid.SetColumn(textBox, 0);
            grid.Children.Add(textBox);
        }

        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedRoom = new Room(roomID, roomSide, building, phoneNumber, mailing, roomNum);
            selectedRoom.grid = grid;
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = roomNum + roomSide + " " + building;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }
    }
}
