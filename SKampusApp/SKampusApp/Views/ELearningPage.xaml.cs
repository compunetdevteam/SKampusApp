using SKampusApp.Models;
using SKampusApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ELearningPage : ContentPage
    {
        private readonly MyCourseViewModel model;
        public ELearningPage()
        {
            InitializeComponent();
            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("StudentId"))
            {
                studentId = App.Current.Properties["StudentId"] as string;
            }
            model = new MyCourseViewModel(studentId);
            BindingContext = model;
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var course = MyCourseList.SelectedItem as MyCourseModel;
            if (course != null)
            {
                var myCourseViewModel = BindingContext as MyCourseViewModel;
                if (myCourseViewModel != null)
                {
                    myCourseViewModel.SelectedCourse = course;
                    await Navigation.PushAsync(new ModulePage(course));
                }
            }
        }
    }
}