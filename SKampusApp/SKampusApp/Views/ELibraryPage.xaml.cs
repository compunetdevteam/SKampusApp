
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SKampusApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ELibraryPage : TabbedPage
    {
        public ELibraryPage()
        {
            InitializeComponent();
            ScienceBrower.Source = "http://www.sciencedirect.com/";
            EbscoBrower.Source = "http://search.ebscohost.com/login.aspx?authtype=ip,uid&profile=ehost&gg";
            GlownBrower.Source = "http://glown.com/";
        }

        private void ScienceIsNavigated(object sender, WebNavigatedEventArgs e)
        {
            Scienceloading.IsVisible = false;
        }

        private void ScienceIsNavigating(object sender, WebNavigatingEventArgs e)
        {
            Scienceloading.IsVisible = false;
        }

        private void EbscoIsNavigated(object sender, WebNavigatedEventArgs e)
        {
            Ebscoloading.IsVisible = false;
        }

        private void EbscoIsNavigating(object sender, WebNavigatingEventArgs e)
        {
            Ebscoloading.IsVisible = true;
        }

        private void GlownIsNavigating(object sender, WebNavigatingEventArgs e)
        {
            Glownloading.IsVisible = true;
        }

        private void GlownIsNavigated(object sender, WebNavigatedEventArgs e)
        {
            Glownloading.IsVisible = false;
        }
    }
}