
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("StudentId"))
            {
                studentId = App.Current.Properties["StudentId"] as string;
            }

            ProfilePic.Source = "https://ebsuportal.azurewebsites.net/Students/RenderImage?studentId=" + studentId;

        }
    }
}