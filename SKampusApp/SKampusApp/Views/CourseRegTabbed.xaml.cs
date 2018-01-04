using SKampusApp.Models;
using SKampusApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseRegTabbed : TabbedPage
    {
        private readonly CourseRegViewModel model;
        public CourseRegTabbed()
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
            var myModel = new CourseRegApi()
            {
                StudentId = model.StudentId,
                Courses = new List<CourseReg>(model.SelectedCourseRegs),
                AvailableCredit = model.AvailableCredit
            };

            await Navigation.PushAsync(new ConfirmCourseRegView(myModel));
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
                DisplayAlert("Action", "CourseName (" + item.CourseName + ") Added to Selected Courses", "OK");
            }


            BindingContext = model;

            //((ListView)sender).SelectedItem = null;
        }

        private void SelectedCourseTapped(object sender, ItemTappedEventArgs e)
        {
            if (navigationDrawerList2.SelectedItem is CourseReg item)
            {
                if (BindingContext is CourseRegViewModel courseRegVm)
                {
                    courseRegVm.DeSelectedCourseReg = item;
                }
                DisplayAlert("Action", item.CourseName + "Removed From Selected Courses", "OK");
            }

            BindingContext = model;
            //navigationDrawerList2.SelectedItem = null;
        }
    }
}