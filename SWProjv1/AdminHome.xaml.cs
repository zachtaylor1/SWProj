using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Page
    {
        public Admin admin;
        public AdminHome(Admin admin)
        {
            InitializeComponent();
            try
            {
                String[] result = Server.adminHomeQuery(admin);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Retrieving Data");
            }
            /*InitializeComponent();
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
				}*/
        }
        private void roomSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Room"));
        }
        private void msg_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Message"));
        }
        private void KeyReview_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Key"));
        }
        private void searchStdnt_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Student"));
        }
        private void RAReview_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("RA Application"));
        }

        private void audit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SearchPage("Audit"));
        }

        private void roommate_btn_Click(object sender, RoutedEventArgs e)
        {
            /*DateTime dt = DateTime.Now;
            int year = dt.Year;
            if (MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MessageBox.Show(StudentAssignment.assign(Server.runQueryApplication(year), year));
            }
            else
            {
                
            }*/
            Server.getRoommateName("123");
        }
    }
}