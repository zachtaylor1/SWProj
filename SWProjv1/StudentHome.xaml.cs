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
    /// <summary>
    /// Interaction logic for StudentHome.xaml
    /// </summary>
    public partial class StudentHome : Page
    {
        public StudentHome(Student student)
        {
            InitializeComponent();
            if (student.GetType().ToString().Equals("SWProjv1.RA"))
            {
                KeyReview_btn.Visibility = Visibility.Visible;
            }
            try
            {
                String[] roomData = Server.studentHomeQuery(student);
                tb3.Text = "Residence: " + roomData[0];
                tb2.Text = "Room: " + roomData[1];
                tb4.Text = "Date Entered: " + roomData[2];
                tb5.Text = "Phone Number: " + roomData[3];
                tb6.Text = "Mailing Address: " + roomData[4];
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: No Data For This Student");
            }
            //TODO parse all useful data from here and add to screen;
        }
        private void KeyRequest_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new KeyRequest());
        }
        private void RAapplication_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RAApplication());
        }
        private void resApplication_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ResApplication());
        }
        private void KeyReview_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Key"));
        }
        private void msg_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Message"));
        }
    }
}
