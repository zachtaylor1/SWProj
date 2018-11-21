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
        public AdminHome()
        {
            InitializeComponent();
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
    }
}
