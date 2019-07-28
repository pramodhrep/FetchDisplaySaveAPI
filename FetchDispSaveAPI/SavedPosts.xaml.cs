using System;
using System.Collections.Generic;
using FetchDispSaveAPI.Models;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FetchDispSaveAPI
{
    public partial class SavedPosts : ContentPage
    {
        public SavedPosts()
        {
            InitializeComponent();

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                loadPosts();
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Alert", "No Internet Connection Available Now. View Only Saved Posts... ", "Ok");
                    loadPosts();
                });
            }

        }
        public void loadPosts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                    conn.CreateTable<Post>();
                    Saved_Post_List.ItemsSource = conn.Table<Post>();
            }    
        }
    }
}
