using SKampusApp.Models;
using SKampusApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseRegPage : ContentPage
    {
        private readonly CourseRegViewModel model;
        public CourseRegPage()
        {
            InitializeComponent();
            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("StudentId"))
            {
                studentId = App.Current.Properties["StudentId"] as string;
            }
            model = new CourseRegViewModel(studentId);
            BindingContext = model;
        }


        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (CourseReg)e.SelectedItem;
            if (item != null)
            {
                var courseRegVm = BindingContext as CourseRegViewModel;
                if (courseRegVm != null)
                {
                    courseRegVm.SelectedCourseReg = item;

                }
            }
            BindingContext = model;
        }

        private async void NextCourseReg(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ConfirmCourseRegView(model.SelectedCourseRegs));
        }




        private void Add(object sender, EventArgs e)
        {
            if (sender is MenuItem mi)
            {
                var name = mi.BindingContext as string;
                DisplayAlert("More Context Action", name + " more context action", "OK");
            }
        }

        private void Remove(object sender, EventArgs e)
        {
            if (sender is MenuItem mi)
            {
                var name = mi.BindingContext as string;
                DisplayAlert("More Context Action", name + " more context action", "OK");
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (navigationDrawerList.SelectedItem is CourseReg item)
            {
                if (BindingContext is CourseRegViewModel courseRegVm)
                {
                    courseRegVm.SelectedCourseReg = item;
                }
            }
            BindingContext = model;
        }
    }

}