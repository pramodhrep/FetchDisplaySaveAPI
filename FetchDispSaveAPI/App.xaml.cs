using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FetchDispSaveAPI
{
    public partial class App : Application
    {
        public static string DBPath = string.Empty;

        public App(String dbPath)
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            CheckInternet();
            DBPath = dbPath;
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
        public void CheckInternet()
        {
            var current = Connectivity.NetworkAccess;
            
            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                // Connection to internet is not available
                MainPage = new NavigationPage(new SavedPosts());
            }
        }
    }
}
