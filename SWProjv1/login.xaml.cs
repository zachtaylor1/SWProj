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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        Student student;
        public login()
        {
            InitializeComponent();
            student = new Student();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            int UserType = user.VerifyLogin(username_inp.Text);
            if (UserType == 0)
            {
                Student student = new Student();
                student.name = "Plain Old Student";
                this.NavigationService.Navigate(new StudentHome(student));
            }
            else if (UserType == 1)
            {
                RA ra = new RA();
                ra.name = "Fancy RA";
                this.NavigationService.Navigate(new StudentHome(ra));
            }
            else if (UserType == 2)
            {
                Admin admin = new Admin();
                this.NavigationService.Navigate(new AdminHome());
            }
            else
            {
                String errorTitle = "Login Error";
                String errorMessage = "Login Error :(";
                MessageBox.Show(errorTitle, errorMessage);
            }
        }

        private void HelpLogin_btn_MouseEnter(object sender, MouseEventArgs e)
        {
            HelpLogin_txt.TextDecorations = TextDecorations.Underline;
        }

        private void HelpLogin_btn_MouseLeave(object sender, MouseEventArgs e)
        {
            HelpLogin_txt.TextDecorations = null;
        }

        private void HelpLogin_btn_Click(object sender, RoutedEventArgs e)
        {
            String mbTitle = "Get Help";
            String mbMessage = "Message another department to become a registered student";
            MessageBox.Show(mbMessage, mbTitle);
        }
    }
}
