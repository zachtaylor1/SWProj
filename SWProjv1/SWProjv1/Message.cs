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
    public class Message
    {
        /*
		 * TODO://Allow reply
		 * 
		 */
        public static Message selectedMessage { get; set; }
        public String Text { get; set; }
        public String senderID { get; set; }
        public String recieverID { get; set; }
        public String dateSent { get; set; }
        public Grid grid;
        public String senderName { get; set; }
        public Button accept { get; set; }
        public String mID { get; set; }
        public ListBoxItem listboxitem;
        public bool messageAcknowledged { get; set; }
        public Message(String Text, String senderID, String recieverID, String dateSent, String senderName, String mID)
        {
            this.mID = mID;
            this.Text = Text;
            this.senderID = senderID;
            this.recieverID = recieverID;
            this.dateSent = dateSent;
            this.senderName = senderName;
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
            TextBox textbox = new TextBox();
            Grid.SetRow(textbox, 0);
            Grid.SetColumn(textbox, 0);
            textbox.TextWrapping = TextWrapping.Wrap;
            textbox.Text = Text;
            grid.Children.Add(textbox);
            grid.Children.Add(accept);
        }
        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedMessage = this;
            selectedMessage.grid = grid;
        }
        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = this.senderName;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
            accept.Click += accept_click;
        }
        private void accept_click(object sender, RoutedEventArgs e)
        {
            Server.Executer("UPDATE Message SET messageAcknowledge = 1 WHERE messageID = '" + mID + "'");
        }
    }
}