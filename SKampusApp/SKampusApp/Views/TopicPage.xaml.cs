using SKampusApp.Models;
using SKampusApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicPage : ContentPage
    {
        private readonly TopicViewModel model;
        public TopicPage(ModuleModel myModule)
        {
            InitializeComponent();
            if (myModule != null)
            {
                model = new TopicViewModel(myModule.ModuleId);
                moduleName.Text = myModule.ModuleName;
            }

            BindingContext = model;
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var topic = TopicList.SelectedItem as TopicModel;
            if (topic != null)
            {
                var topicsViewModel = BindingContext as TopicViewModel;
                if (topicsViewModel != null)
                {
                    topicsViewModel.SelectedModule = topic;
                    await Navigation.PushAsync(new TopicDetalPage());


                }
            }
        }
    }
}