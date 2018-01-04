using SKampusApp.MenuItems;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SKampusApp.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Navigation.RemovePage(new Login());



            menuList = new List<MasterPageItem>();
            var pageDashboard = new MasterPageItem { Title = "DashBoard", Icon = "icondashboard1", TargetType = typeof(DashboardPage) };
            var profile = new MasterPageItem { Title = "Profile", Icon = "iconprofile1", TargetType = typeof(ProfilePage) };

            var page1 = new MasterPageItem { Title = "Course Registration", Icon = "iconcourse1.png", TargetType = typeof(CourseRegTabbed) };
            var page2 = new MasterPageItem { Title = "Pay Fee", Icon = "iconmoney1.png", TargetType = typeof(FeeManagementPage) };
            var page3 = new MasterPageItem { Title = "Accommodation", Icon = "iconhouse1.png", TargetType = typeof(AccomodationPage) };
            var page4 = new MasterPageItem { Title = "Result", Icon = "iconresult1.png", TargetType = typeof(ResultPage) };
            var page5 = new MasterPageItem { Title = "E learning", Icon = "iconelearning1.png", TargetType = typeof(ELearningPage) };
            var eLibrary = new MasterPageItem { Title = "E-Library", Icon = "iconlibrary", TargetType = typeof(ELibraryPage) };

            menuList.Add(pageDashboard);
            menuList.Add(profile);
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(eLibrary);
            menuList.Add(page5);
            menuList.Add(page4);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(DashboardPage)));

            string studentId = string.Empty;

            if (App.Current.Properties.ContainsKey("StudentId"))
            {
                studentId = App.Current.Properties["StudentId"] as string;
            }

            this.BindingContext = new
            {
                Header = "",
                //Image = "schcap.jpg",
                Image = "https://ebsuportal.azurewebsites.net/Students/RenderImage?studentId=" + studentId,
                //https://ebsuportal.azurewebsites.net/Students/RenderImage?studentId
                Footer = "Welcome to SwiftKampus"

            };

        }



        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;


            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
