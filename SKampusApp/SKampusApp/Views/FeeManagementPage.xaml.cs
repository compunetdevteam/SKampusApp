
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeeManagementPage : ContentPage
    {
        public FeeManagementPage()
        {
            InitializeComponent();
            FeeBrowser.Source = "https://ebsuportal.azurewebsites.net/SchoolFeepayments/MakePayment";

        }


        private void WebOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            loading.IsVisible = true;

        }

        private void WebOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            loading.IsVisible = false;
        }


    }
}