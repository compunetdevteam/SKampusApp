using SKampusApp.Models;
using SKampusApp.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmCourseRegView : ContentPage
    {
        private readonly CourseRegApi _model;
        public ConfirmCourseRegView(CourseRegApi model)
        {
            InitializeComponent();

            _model = model;
            ConfirmCourseList.ItemsSource = model.Courses;
            this.BindingContext = this;
            this.IsBusy = false;
        }

        private void OnMenuItemSelected(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {

        }

        private async void SubmitCourse(object sender, EventArgs e)
        {
            this.IsBusy = true;
            var service = new CourseRegService();
            var result = await service.RegisterCourseRegAsync(_model);
            if (result.ToUpper().Equals("OK") || result.ToUpper().Equals("TRUE") || result.ToUpper().Equals("200"))
            {
                await DisplayAlert("Alert", "Course has been Registered Successfully" + "", "OK");
                Page originalPage = Application.Current.MainPage.Navigation.NavigationStack.Last();
                await Application.Current.MainPage.Navigation.PushAsync(new DashboardPage());
                Application.Current.MainPage.Navigation.RemovePage(originalPage);
                this.IsBusy = false;
            }
            else
            {
                await DisplayAlert("Alert", "Error submitting Course Registration" + result, "OK");
                this.IsBusy = false;
            }
        }
    }
}