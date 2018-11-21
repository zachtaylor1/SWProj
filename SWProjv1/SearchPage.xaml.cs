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
        public SearchPage(String type)
        {
            try
            {
                Server.Init();
            }
            catch (Exception e) { }
            InitializeComponent();
            this.type = type;
            type_txt.Text = type+"s";
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Server.setCommand(type, "");
                searchItems.ItemsSource = Server.runQuery("SWProjv1." + type);
            }
            catch (Exception exceptyone)
            {
                searchText_test.Text = exceptyone.ToString();
            }
        }
    }
}
