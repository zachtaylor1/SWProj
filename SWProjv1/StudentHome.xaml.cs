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
