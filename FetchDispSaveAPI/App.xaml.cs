using System;
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

            MainPage = new NavigationPage(new MainPage());
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
    }
}
