using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

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
        public List<Furniture> furnitureList { get; set;}
        public ListBoxItem listboxitem;
        public Grid grid;
        DockPanel furnGrid;
        DataGrid furniture;
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
        }

        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            setGrid();
            selectedRoom = this;
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = roomNum + roomSide + " " + building;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }

        public void setGrid()
        {
            grid.Children.Clear();
            this.furnitureList = Server.getFurniture(roomID);
            //top info
            DockPanel basicInfo = GetBasicInfo();

            Grid.SetRow(basicInfo, 0);
            Grid.SetColumn(basicInfo, 0);
            grid.Children.Add(basicInfo);
            //furniture & history
            TabControl tb = new TabControl();
            Grid.SetRow(tb, 1);
            Grid.SetColumn(tb, 0);
            Grid.SetColumnSpan(tb, 2);
            grid.Children.Add(tb);

            TabItem furnitures = new TabItem();
            furnitures.Header = "Furniture";

            DockPanel someFurnOptions = new DockPanel();
            furnGrid = new DockPanel();
            /*for (int i = 0; i < 4; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(20, GridUnitType.Auto);
                furnGrid.ColumnDefinitions.Add(cd);
                furnGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }*/

            ScrollViewer scroller = new ScrollViewer();
            //Grid.SetColumn(scroller, 0);
            furniture = new DataGrid();
            furniture.ItemsSource = furnitureList;
            furniture.AutoGenerateColumns = false;

            DataGridTextColumn furnitureNames = new DataGridTextColumn();
            furnitureNames.Binding = new Binding("name");
            furnitureNames.Header = "Item";
            furnitureNames.Width = new DataGridLength(20,DataGridLengthUnitType.Star);
            furniture.Columns.Add(furnitureNames);

            DataGridTextColumn furnitureSN = new DataGridTextColumn();
            furnitureSN.Binding = new Binding("serialNum");
            furnitureSN.Header = "Serial Number";
            furnitureSN.Width = new DataGridLength(20, DataGridLengthUnitType.Star);
            furniture.Columns.Add(furnitureSN);

            scroller.Content = furniture;
            //Grid.SetColumn(scroller, 0);
            //furnGrid.Children.Add(scroller);
            furnitures.Content = furnGrid;
            tb.Items.Add(furnitures);

            Grid optionInput = new Grid();
            //Grid.SetColumn(optionInput, 1);
            for (int i = 0; i < 4; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(20, GridUnitType.Star);
                optionInput.RowDefinitions.Add(rd);
            }

            TextBlock n_lbl = new TextBlock();
            n_lbl.Text = "Enter name of furniture";
            n_lbl.HorizontalAlignment = HorizontalAlignment.Center;
            n_lbl.Padding = new Thickness(10);
            Grid.SetRow(n_lbl, 0);

            TextBox n_txt = new TextBox();
            n_txt.HorizontalAlignment = HorizontalAlignment.Center;
            n_txt.Padding = new Thickness(10);
            n_txt.MinWidth = 30;
            Grid.SetRow(n_txt, 1);

            TextBlock sn_lbl = new TextBlock();
            sn_lbl.Text = "Enter serial number of furniture";
            sn_lbl.HorizontalAlignment = HorizontalAlignment.Center;
            sn_lbl.Padding = new Thickness(10);
            Grid.SetRow(sn_lbl, 2);

            TextBox sn_txt = new TextBox();
            sn_txt.HorizontalAlignment = HorizontalAlignment.Center;
            sn_txt.Padding = new Thickness(10);
            sn_txt.MinWidth = 30;
            Grid.SetRow(sn_txt, 3);

            optionInput.Children.Add(n_lbl);
            optionInput.Children.Add(n_txt);
            optionInput.Children.Add(sn_lbl);
            optionInput.Children.Add(sn_txt);

            
            furnGrid.Children.Add(optionInput);
            furnGrid.Children.Add(scroller);
            Button rm_btn = new Button();
            rm_btn.Content = "Remove";
            rm_btn.Click += remove_furniture_btn_Click;

            TabItem history = new TabItem();
            history.Header = "Room History";
            ScrollViewer Hscroller = new ScrollViewer();
            DataGrid historyGrid = new DataGrid();
            List<List<String>> ll = Server.getRoomHistory(roomID);
            historyGrid.ItemsSource = ll;
            historyGrid.AutoGenerateColumns = false;

            DataTemplate dt = new DataTemplate();

            Hscroller.Content = historyGrid;
            history.Content = Hscroller;
            tb.Items.Add(history);

        }

        private void remove_furniture_btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public DockPanel GetBasicInfo()
        {
            DockPanel basicInfo = new DockPanel();

            StackPanel labels = new StackPanel();
            TextBox roomNumber_lbl = new TextBox();
            roomNumber_lbl.IsReadOnly = true;
            roomNumber_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roomNumber_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5")); roomNumber_lbl.Text = "Room Number:";
            labels.Children.Add(roomNumber_lbl);
            TextBox roomSide_lbl = new TextBox();
            roomSide_lbl.Text = "Room Side:";
            roomSide_lbl.IsReadOnly = true;
            roomSide_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roomSide_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            labels.Children.Add(roomSide_lbl);
            TextBox building_lbl = new TextBox();
            building_lbl.IsReadOnly = true;
            building_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            building_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            building_lbl.Text = "Room Number:";
            labels.Children.Add(building_lbl);
            TextBox mailAddress_lbl = new TextBox();
            mailAddress_lbl.IsReadOnly = true;
            mailAddress_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            mailAddress_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            mailAddress_lbl.Text = "Mailing Address:";
            labels.Children.Add(mailAddress_lbl);
            TextBox phone_lbl = new TextBox();
            phone_lbl.IsReadOnly = true;
            phone_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            phone_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            phone_lbl.Text = "Room Number:";
            labels.Children.Add(phone_lbl);
            TextBox roomID_lbl = new TextBox();
            roomID_lbl.IsReadOnly = true;
            roomID_lbl.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roomID_lbl.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFE5E5E5"));
            roomID_lbl.Text = "Room ID:";
            labels.Children.Add(roomID_lbl);
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
            TextBox roomNumber_txt = new TextBox();
            roomNumber_txt.IsReadOnly = true;
            roomNumber_txt.Text = roomNum;
            data.Children.Add(roomNumber_txt);
            TextBox roomSide_txt = new TextBox();
            roomSide_txt.IsReadOnly = true;
            roomSide_txt.Text = roomSide;
            data.Children.Add(roomSide_txt);
            TextBox building_txt = new TextBox();
            building_txt.IsReadOnly = true;
            building_txt.Text = building;
            data.Children.Add(building_txt);
            TextBox mailAddress_txt = new TextBox();
            mailAddress_txt.IsReadOnly = true;
            mailAddress_txt.Text = mailing;
            data.Children.Add(mailAddress_txt);
            TextBox phone_txt = new TextBox();
            phone_txt.IsReadOnly = true;
            phone_txt.Text = phoneNumber;
            data.Children.Add(phone_txt);
            TextBox roomID_txt = new TextBox();
            roomID_txt.IsReadOnly = true;
            roomID_txt.Text = roomID;
            data.Children.Add(roomID_txt);
            basicInfo.Children.Add(data);

            Grid.SetRow(basicInfo, 0);
            Grid.SetColumn(basicInfo, 0);
            return basicInfo;
        }
    }
}