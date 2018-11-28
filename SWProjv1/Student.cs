using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWProjv1
{
    public class Student : User
    {
        public static Student selectedStudent { get; set; }
        public String studentNum { get; set; }
        public bool isBlacklisted { get; set; }
        public String roommateID { get; set; }
        public String roomID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public Grid grid;
        public ListBoxItem listboxitem;
        public Student(String studentNum, bool isBlacklisted, String roommateID, String roomID, String firstName, String lastName, String otherName, String username, String password, String DOB) : base(firstName, lastName, otherName, username, password, DOB)
        {
            this.studentNum = studentNum;
            
            this.isBlacklisted = isBlacklisted;
            this.roommateID = roommateID;
            this.roomID = roomID;
            this.username = username;
            this.password = password;
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            TextBox textBox = new TextBox();
            textBox.Text = firstName + " " + lastName + "\n Student Number: " + studentNum;
            Grid.SetRow(textBox, 0);
            Grid.SetColumn(textBox, 0);
            grid.Children.Add(textBox);
        }

        public Student() { }

        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedStudent = this;
            selectedStudent.grid = grid;
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = firstName + " " + lastName + " " + studentNum;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }
    }
}
