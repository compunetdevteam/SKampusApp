﻿using SKampusApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {

        private readonly SignUpViewModel _signUpViewModel = new SignUpViewModel();
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void BtnSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchEntry.Text))
            {
                await DisplayAlert("Validation Error", "Please type in your MatricNo/JambReg No", "Ok");
            }
            var respose = await _signUpViewModel.SearchStudent(SearchEntry.Text.Trim());

            if (string.IsNullOrEmpty(respose.UserId))
            {
                await DisplayAlert("Validation Error", respose.Message, "Ok");
            }
            else
            {
                //await Navigation.PushAsync(new MainPage());
                Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage(respose));
                //Application.Current.MainPage = new MainPage();
                Application.Current.MainPage.Navigation.RemovePage(originalPage);
            }

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());
            Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            //Application.Current.MainPage = new MainPage();
            Application.Current.MainPage.Navigation.RemovePage(originalPage);
        }
    }
}