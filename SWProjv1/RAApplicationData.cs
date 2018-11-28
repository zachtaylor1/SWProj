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
    public class RAApplicationData
    {
        public static RAApplicationData selectedApplication { get; set; }
        public ListBoxItem listboxitem { get; set; }
        public Grid grid { get; set; }
        public String Name { get; set; }
        public Button accept { get; set; }
        public Button Deny { get; set; }
        public Boolean isAck { get; set; }
        public Boolean isAcc { get; set; }
        public int ID { get; set; }
        public String stuID { get; set; }
        public RAApplicationData(String name, Boolean isAck, Boolean isAcc, int ID, String stuID)
        {
            this.stuID = stuID;
            this.Name = name;
            this.isAck = isAck;
            this.isAcc = isAcc;
            this.ID = ID;
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            accept = new Button();
            accept.Content = "Accept";
            accept.Height = 30;
            Grid.SetRow(accept, 1);
            Grid.SetColumn(accept, 0);
            Deny = new Button();
            Deny.Height = 30;
            Deny.Content = "Deny";
            Grid.SetRow(Deny, 2);
            Grid.SetColumn(Deny, 0);
            TextBox textbox = new TextBox();
            Grid.SetRow(textbox, 0);
            Grid.SetColumn(textbox, 0);
            textbox.TextWrapping = System.Windows.TextWrapping.Wrap;
            textbox.Text = Name;
            grid.Children.Add(textbox);
            grid.Children.Add(accept);
            grid.Children.Add(Deny);
        }
        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedApplication = this;
            selectedApplication.grid = grid;
        }
        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = this.Name;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
            accept.Click += accept_click;
            Deny.Click += deny_click;
        }
        private void deny_click(object sender, RoutedEventArgs e)
        {
            Server.Executer("UPDATE RAApplication SET isAcknowledged = 1, isAccepted = 0 WHERE RAApplicationID = " + ID.ToString());
        }
        private void accept_click(object sender, RoutedEventArgs e)
        {
            Server.Executer("UPDATE RAApplication SET isAcknowledged = 1, isAccepted = 1 WHERE RAApplicationID = " + ID.ToString());
            Server.Executer("INSERT INTO RA VALUES('" + stuID + "', '" + stuID + "')");
        }
    }
}