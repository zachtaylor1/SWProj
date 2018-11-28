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
    /// Interaction logic for ResApplication.xaml
    /// </summary>
    public partial class ResApplication : Page
    {
        public ResApplication()
        {
            InitializeComponent();
        }
        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {

            String mbTitle = "";
            String mbMessage = "";
            if (name_inp.Text != "" && stdNum_inp.Text != "" && lname_inp.Text != "" && otherName.Text != "" && schoolYear.Text != "" && gender.Text != "" && email.Text != "" && streetAddress.Text != "" && city.Text != "" && region.Text != "" && postalCode.Text != "" && phoneCountryCode.Text != "" && phoneAreaCode.Text != "" && phoneNumber.Text != "" && preferedBuilding.Text != "" && smokes.Text != "" && liveWithSmoke.Text != "" && drinks.Text != "" && marijuana.Text != "" && liveWithMarijuana.Text != "" && socialLevel.Text != "" && bedtime.Text != "" && wakeUp.Text != "" && volumeLevel.Text != "" && overnightVisitors.Text != "" && cleanliness.Text != "" && studyInRoom.Text != "" && mealPlan.Text != "")
            {
                int smoke = 0, livewithsmoke = 0, drink = 0, livewithdrink = 0, mary = 0, livewithmary = 0, roomreq = 0, studies = 0, visitors = 0;
                if (smokes.Text.Equals("Yes")) smoke = 1;
                if (liveWithSmoke.Text.Equals("Yes")) livewithsmoke = 1;
                if (drinks.Text.Equals("Yes")) drink = 1;
                if (liveWithDrink.Text.Equals("Yes")) livewithdrink = 1;
                if (marijuana.Text.Equals("Yes")) mary = 1;
                if (liveWithMarijuana.Text.Equals("Yes")) livewithmary = 1;
                if (roomateRequest.Text.Equals("Yes")) roomreq = 1;
                if (studyInRoom.Text.Equals("Yes")) studies = 1;
                if (overnightVisitors.Text.Equals("Yes")) visitors = 1;
                Server.Executer("EXEC SubmitApplication '" + stdNum_inp.Text + "', '" + name_inp.Text + "', '" + lname_inp.Text + "', '" + otherName.Text + "', " + schoolYear.Text + ", '" + gender.Text + "', '" + email.Text + "', '" + streetAddress.Text + "', '" + city.Text + "', '" + region.Text + "', '" + country.Text + "', '" + postalCode.Text + "', '" + phoneCountryCode.Text + "', '" + phoneAreaCode.Text + "', '" + phoneNumber.Text + "', '" + preferedBuilding.Text + "', " + smoke + ", " + livewithsmoke + ", " + drink + ", " + livewithdrink + ", " + mary + ", " + livewithmary + ", '" + socialLevel.Text + "', '" + bedtime.Text + "', '" + wakeUp.Text + "', '" + volumeLevel.Text + "', " + visitors + ", '" + cleanliness.Text + "', " + studies + "," + roomreq + ",'" + roomateName.Text + "','" + roomateStudentNum.Text + "','" + mealPlan.Text + "'");
                mbTitle = "Success!";
                mbMessage = "Application Successful! :)";
            }
            else
            {
                mbTitle = "Fail!";
                mbMessage = "Request Denied\nFill out all fields";
            }
            MessageBox.Show(mbTitle, mbMessage);
        }
    }
}