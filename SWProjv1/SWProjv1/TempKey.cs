using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
namespace SWProjv1
{
    public class TempKey
    {
        public static TempKey selectedKey { get; set; }
        public String keyID { get; set; }
        public bool isAssigned { get; set; }
        public String RAAssignedID { get; set; }
        public String RAReturnedID { get; set; }
        public String studentAssigned { get; set; }
        public String roomID { get; set; }
        public String dateAssigned { get; set; }
        public String dateRecieved { get; set; }
        public Grid grid;
        public String stuNum { get; set; }
        public ListBoxItem listboxitem;
        public String roomNum { get; set; }
        public TempKey(String studentAssigned, String roomNum, String stuNum)
        {
            this.studentAssigned = studentAssigned;
            this.roomNum = roomNum;
            this.stuNum = stuNum;
            grid = new Grid();
        }
        public void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            setGrid();
            selectedKey = this;
        }

        void setGrid()
        {
            grid.Children.Clear();
            for (int i = 0; i < 3; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(20, GridUnitType.Star);
                grid.RowDefinitions.Add(rd);
            }
            TextBlock name_lbl = new TextBlock();
            name_lbl.Text = studentAssigned;
            name_lbl.HorizontalAlignment = HorizontalAlignment.Center;
            name_lbl.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(name_lbl, 0);

            TextBlock room_lbl = new TextBlock();
            room_lbl.Text = roomNum;
            room_lbl.HorizontalAlignment = HorizontalAlignment.Center;
            room_lbl.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(room_lbl, 1);

            UniformGrid uGrid = new UniformGrid();
            uGrid.Columns = 5;
            uGrid.Rows = 2;
            uGrid.Children.Add(new TextBlock());
            Button accept_btn = new Button();
            accept_btn.Content = "Accept";
            accept_btn.Click += Accept_btn_Click;
            uGrid.Children.Add(accept_btn);
            uGrid.Children.Add(new TextBlock());
            Button deny_btn = new Button();
            deny_btn.Content = "Deny";
            deny_btn.Click += Deny_btn_Click;
            uGrid.Children.Add(deny_btn);
            uGrid.Children.Add(new TextBlock());
            Grid.SetRow(uGrid, 2);

            grid.Children.Add(name_lbl);
            grid.Children.Add(room_lbl);
            grid.Children.Add(uGrid);
        }

        private void Deny_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Request Denied");
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Request Accepted");
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = studentAssigned;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }
    }
}