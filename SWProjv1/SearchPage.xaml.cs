using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace SWProjv1
{
    //look into using gridform instead of listbox
    ///.Add to add to list
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        String type;
        String uID;
        public SearchPage(String type)
        {
            try
            {
                Server.Init();
            }
            catch (Exception e) { }
            InitializeComponent();
            CreateButton.Click += newmessage_click;
            this.type = type;
            type_txt.Text = type + "s";
            if (type == "Message")
            {
                CreateButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageText.Visibility = Visibility.Hidden;
                Student_Number.Visibility = Visibility.Hidden;
                CreateButton.Visibility = Visibility.Hidden;
                Send.Visibility = Visibility.Hidden;
            }
        }
        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Server.setCommand(type, "");
                List<ListBoxItem> listy = Server.runQuery("SWProjv1." + type);
                foreach (ListBoxItem lbi in listy)
                {
                    lbi.PreviewMouseDown += Item_PreviewMouseDown2;
                }
                searchItems.ItemsSource = listy;
            }
            catch (Exception exceptyone)
            {
                MessageBox.Show(exceptyone.ToString());
                //searchText_test.Text = exceptyone.ToString();
            }
        }
        private void Item_PreviewMouseDown2(object sender, MouseButtonEventArgs e)
        {
            //searchItem.Visibility=Visibility.Visible;
            try
            {
                Grid searchItem;
                int maxCount = 4;
                switch (type)
                {
                    case "Room":
                        searchItem = Room.selectedRoom.grid;
                        break;
                    case "Student":
                        searchItem = Student.selectedStudent.grid;
                        break;
                    case "Message":
                        maxCount = 8;
                        searchItem = Message.selectedMessage.grid;
                        break;
                    case "Key":
                        searchItem = TempKey.selectedKey.grid;
                        break;
                    case "RA Application":
                        searchItem = RAApplicationData.selectedApplication.grid;
                        break;
                    default:
                        searchItem = new Grid();
                        break;
                }
                Grid.SetColumn(searchItem, 1);
                Grid.SetRow(searchItem, 3);
                while (grid.Children.Count > maxCount)
                    grid.Children.RemoveAt(grid.Children.Count - 1);
                grid.Children.Add(searchItem);
            }
            catch (Exception)
            {
            }
            MessageText.Visibility = Visibility.Hidden;
            Student_Number.Visibility = Visibility.Hidden;
            Send.Visibility = Visibility.Hidden;
        }
        private void newmessage_click(object sender, RoutedEventArgs e)
        {
            MessageText.Visibility = Visibility.Visible;
            Student_Number.Visibility = Visibility.Visible;
            Send.Visibility = Visibility.Visible;
            Grid.SetColumn(Student_Number, 1);
            Grid.SetRow(Student_Number, 1);
            Grid.SetColumn(MessageText, 1);
            Grid.SetRow(MessageText, 3);
            Grid.SetColumn(Send, 1);
            Grid.SetRow(Send, 2);
            while (grid.Children.Count > 8)
                grid.Children.RemoveAt(grid.Children.Count - 1);
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (MessageText.Text != "Message Text" && Student_Number.Text != "UserNumber")
            {
                try
                {
                    Server.SendMessage(Student_Number.Text, MessageText.Text, User.userID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, Wrong input" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error, Inputs invalid");
            }
        }
    }
}
