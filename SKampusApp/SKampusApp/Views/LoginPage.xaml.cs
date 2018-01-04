using SKampusApp.Models;
using SKampusApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = this;

        }

        private async void BtnLogin(object sender, EventArgs e)
        {

            loading.IsVisible = true;
            if (string.IsNullOrEmpty(EmailEntry.Text)
                || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Validation Error", "Please fill both username or password", "Ok");
                this.IsBusy = false;
            }
            else
            {
                var loginModel = new LoginModel()
                {
                    Email = EmailEntry.Text.Trim(),
                    Password = PasswordEntry.Text.Trim()
                };

                var respose = await _loginViewModel.MakeLogin(loginModel);

                if (string.IsNullOrEmpty(respose.StudentId))
                {
                    await DisplayAlert("Validation Error", respose.Message, "Ok");
                    loading.IsVisible = false;
                }
                else
                {
                    if (App.Current.Properties.ContainsKey("StudentId"))
                    {
                        App.Current.Properties["StudentId"] = respose.StudentId;
                        App.Current.Properties["LoginStatus"] = "true";
                    }
                    else
                    {
                        App.Current.Properties.Add("StudentId", respose.StudentId);
                        App.Current.Properties["LoginStatus"] = "true";
                    }

                    await App.Current.SavePropertiesAsync();

                    loading.IsVisible = false;
                    Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    //Application.Current.MainPage = new MainPage();
                    Application.Current.MainPage.Navigation.RemovePage(originalPage);

                }
            }


            // }
        }

        private async void BtnSignUp(object sender, EventArgs e)
        {

            Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
            Application.Current.MainPage.Navigation.RemovePage(originalPage);

        }
    }
}