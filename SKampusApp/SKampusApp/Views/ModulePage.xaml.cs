using SKampusApp.Models;
using SKampusApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulePage : ContentPage
    {
        private readonly ModuleViewModel model;
        public ModulePage(MyCourseModel courseModel)
        {
            InitializeComponent();
            if (courseModel != null)
            {
                model = new ModuleViewModel(courseModel.CourseId);
                coursecode.Text = courseModel.CourseCode;
                courseName.Text = courseModel.CourseName;
            }

            BindingContext = model;
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var module = ModuleList.SelectedItem as ModuleModel;
            if (module != null)
            {
                var moduleViewModel = BindingContext as ModuleViewModel;
                if (moduleViewModel != null)
                {
                    moduleViewModel.SelectedModule = module;
                    await Navigation.PushAsync(new TopicPage(module));


                }
            }
        }
    }
}