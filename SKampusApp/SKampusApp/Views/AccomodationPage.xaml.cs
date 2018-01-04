
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccomodationPage : ContentPage
    {
        public AccomodationPage()
        {
            InitializeComponent();
            hostelBrower.Source = "https://ebsuportal.azurewebsites.net/AssignedRoomsHostelApplication/";
        }

        private void IsNavigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsVisible = false;
        }

        private void IsNavigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsVisible = true;
        }
    }
}