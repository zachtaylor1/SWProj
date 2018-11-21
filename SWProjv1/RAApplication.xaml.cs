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
    /// Interaction logic for RAApplication.xaml
    /// </summary>
    public partial class RAApplication : Page
    {
        public RAApplication()
        {
            InitializeComponent();
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            String mbTitle = "";
            String mbMessage = "";
            if (fname_inp.Text != "" && stdNum_inp.Text != "" && lname_inp.Text != "")
            {
                mbTitle = "Success!";
                mbMessage = "Application Successful! :)";
            }
            else
            {
                mbTitle = "Fail!";
                mbMessage = "Request Denied\nFill out all fields";
            }
            MessageBox.Show(mbMessage, mbTitle);
        }
    }
}
