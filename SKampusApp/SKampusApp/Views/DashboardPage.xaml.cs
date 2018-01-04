
using SKampusApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("StudentId"))
            {
                studentId = App.Current.Properties["StudentId"] as string;
            }
            var model = new CardViewModel(studentId);
            BindingContext = model;

        }

        private async void SignOut_Clicked(object sender, EventArgs e)
        {
            if (App.Current.Properties.ContainsKey("LoginStatus"))
            {
                App.Current.Properties["LoginStatus"] = "false";
                await App.Current.SavePropertiesAsync();
            }


            Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            Application.Current.MainPage.Navigation.RemovePage(originalPage);
            //await Navigation.PushAsync(new LoginPage());
        }
    }
}