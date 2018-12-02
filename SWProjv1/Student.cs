using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SWProjv1
{
    public class Student : User
    {
        public static Student selectedStudent { get; set; }
        public String studentNum { get; set; }
        public bool isBlacklisted { get; set; }
        public String roommateID { get; set; }
        public String roommateName { get; set; }
        public String roomID { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public Grid grid;
        CheckBox blacklist_chk;
        Button edit_btn;
        Button save_btn;
        public ListBoxItem listboxitem;
        public Student(String studentNum, bool isBlacklisted, String roommateID, String roomID, String firstName, String lastName, String otherName, String username, String password, String DOB) : base(firstName, lastName, otherName, username, password, DOB)
        {
            this.studentNum = studentNum;
            if (studentNum.Equals(15)) this.isBlacklisted = true;
            else this.isBlacklisted = isBlacklisted;
            this.roommateID = roommateID;
            this.roomID = roomID;
            this.username = username;
            this.password = password;
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            /*TextBox textBox = new TextBox();
            textBox.Text = firstName + " " + lastName + "\n Student Number: " + studentNum;
            Grid.SetRow(textBox, 0);
            Grid.SetColumn(textBox, 0);
            grid.Children.Add(textBox);*/
        }

        public Student() { }

        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            setGrid();
            selectedStudent = this;
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = firstName + " " + lastName + " " + studentNum;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }

        public void setGrid()
        {
            grid.Children.Clear();
            DockPanel basicInfo = GetBasicInfo();
            for (int i = 0; i < 3; i++)
            {
                    ColumnDefinition rd = new ColumnDefinition();
                    rd.Width = new GridLength(20, GridUnitType.Auto);
                    grid.ColumnDefinitions.Add(rd);
            }
            for (int i = 0; i < 2; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(20, GridUnitType.Auto);
                grid.RowDefinitions.Add(rd);
            }

            Grid.SetRow(basicInfo, 0);
            Grid.SetColumn(basicInfo, 0);
            grid.Children.Add(basicInfo);

            edit_btn = new Button();
            Grid.SetRow(edit_btn, 0);
            Grid.SetColumn(edit_btn, 2);
            edit_btn.Content = "Edit";
            edit_btn.Click += edit_btn_click;
            edit_btn.VerticalAlignment = VerticalAlignment.Top;
            edit_btn.HorizontalAlignment = HorizontalAlignment.Right;

            save_btn = new Button();
            Grid.SetRow(save_btn, 0);
            Grid.SetColumn(save_btn, 2);
            save_btn.Content = "Save";
            save_btn.Visibility = Visibility.Hidden;
            save_btn.VerticalAlignment = VerticalAlignment.Top;
            save_btn.HorizontalAlignment = HorizontalAlignment.Right;
            save_btn.Click += save_btn_click;

            grid.Children.Add(edit_btn);
            grid.Children.Add(save_btn);

            ScrollViewer scroller = new ScrollViewer();
            Grid.SetRow(scroller, 1);
            Grid.SetColumnSpan(scroller, 2);
            ListBox lb = new ListBox();
            lb.ItemsSource = Server.getStudentHistory(studentNum);
            scroller.Content = lb;
            grid.Children.Add(scroller);
        }

        private void save_btn_click(object sender, RoutedEventArgs e)
        {
            edit_btn.Visibility = Visibility.Visible;
            save_btn.Visibility = Visibility.Hidden;
            Server.Blacklist(studentNum, (bool)blacklist_chk.IsChecked);
            blacklist_chk.IsEnabled = false;
        }

        private void edit_btn_click(object sender, RoutedEventArgs e)
        {
            edit_btn.Visibility = Visibility.Hidden;
            save_btn.Visibility = Visibility.Visible;

            blacklist_chk.IsEnabled = true;
        }
        //query for student history
        //SELECT * FROM RoomHistory, Student WHERE RoomHistory.studentID = Student.studentID and RoomHistory.studentID=1;
        public DockPanel GetBasicInfo()
        {
            DockPanel basicInfo = new DockPanel();

            StackPanel labels = new StackPanel();
            TextBox stdName_lbl = new TextBox();
            stdName_lbl.IsReadOnly = true;
            stdName_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            stdName_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            stdName_lbl.Text = "Name:";
            labels.Children.Add(stdName_lbl);
            TextBox stdNum_lbl = new TextBox();
            stdNum_lbl.Text = "Student Number:";
            stdNum_lbl.IsReadOnly = true;
            stdNum_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            stdNum_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            labels.Children.Add(stdNum_lbl);
            TextBox roommate_lbl = new TextBox();
            roommate_lbl.IsReadOnly = true;
            roommate_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roommate_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roommate_lbl.Text = "Roommate:";
            labels.Children.Add(roommate_lbl);
            TextBox blacklist_lbl = new TextBox();
            blacklist_lbl.IsReadOnly = true;
            blacklist_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            blacklist_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            blacklist_lbl.Text = "Blacklisted:";
            labels.Children.Add(blacklist_lbl);
            basicInfo.Children.Add(labels);

            StackPanel spacer = new StackPanel();
            for (int i = 0; i < labels.Children.Count; i++)
            {
                TextBlock block = new TextBlock();
                block.Text = "  ";
                spacer.Children.Add(block);
            }
            basicInfo.Children.Add(spacer);

            StackPanel data = new StackPanel();
            TextBox stdName_txt = new TextBox();
            stdName_txt.IsReadOnly = true;
            stdName_txt.Text = firstName + " " + otherName + " " + lastName;
            data.Children.Add(stdName_txt);
            TextBox stdNum_txt = new TextBox();
            stdNum_txt.IsReadOnly = true;
            stdNum_txt.Text = studentNum;
            data.Children.Add(stdNum_txt);
            TextBox roommateName_txt = new TextBox();
            roommateName_txt.IsReadOnly = true;
            if (!roommateID.Equals(""))
                roommateName_txt.Text = Server.getRoommateName(roommateID);
            data.Children.Add(roommateName_txt);
            basicInfo.Children.Add(data);
            blacklist_chk = new CheckBox();
            blacklist_chk.IsChecked = isBlacklisted;
            blacklist_chk.IsEnabled = false;
            data.Children.Add(blacklist_chk);

            Grid.SetRow(basicInfo, 0);
            Grid.SetColumn(basicInfo, 0);
            Grid.SetColumnSpan(basicInfo, 2);
            return basicInfo;
        }


    }
}