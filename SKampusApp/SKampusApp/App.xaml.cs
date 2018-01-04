using SKampusApp.Views;
using Xamarin.Forms;

namespace SKampusApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("LoginStatus"))
            {
                studentId = App.Current.Properties["LoginStatus"] as string;
            }
            if (!string.IsNullOrEmpty(studentId) && studentId.Equals("true"))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
