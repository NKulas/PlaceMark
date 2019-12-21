using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlaceMark
{
    public partial class App : Application
    {
        public static App Instance { get; private set; }

        public App()
        {
            InitializeComponent();

            App.Instance = this;

            //MainPage = new NavigationPage(new PlacesListPage());
            PlacesListPage listPage = new PlacesListPage();
            PlacesListViewModel viewModel = new PlacesListViewModel(listPage.Navigation);
            listPage.BindingContext = viewModel;

            MainPage = new NavigationPage(listPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
