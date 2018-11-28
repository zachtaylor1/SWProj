using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public String messageID { get; set; }
        public TempKey(String studentAssigned, String messageID, String stuNum)
        {
            this.studentAssigned = studentAssigned;
            this.messageID = messageID;
            this.stuNum = stuNum;
            grid = new Grid();
            //grid definitions
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            TextBox text = new TextBox();
            text.Text = studentAssigned;
            Grid.SetRow(text, 0);
            Grid.SetColumn(text, 0);
            //set text into grid spots
            grid.Children.Add(text);
        }
        public void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedKey = this;
            selectedKey.grid = grid;
        }
        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = studentAssigned;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }
    }
}