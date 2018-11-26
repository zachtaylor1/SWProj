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
        public login()
        {
            InitializeComponent();
        }
        public void login_btn_Click(object sender, RoutedEventArgs e)
        {
            int UserType = Server.LogInQuery(username_inp.Text, password_inp.Text);
            if (UserType == 1)//Student
            {
                Student student = new Student();
                this.NavigationService.Navigate(new StudentHome(student));
            }
            else if (UserType == 3)
            {//RA
                RA ra = new RA();
                this.NavigationService.Navigate(new StudentHome(ra));
            }
            else if (UserType == 2)
            {//Admin
                this.NavigationService.Navigate(new AdminHome());
            }
            else
            {//Error
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
