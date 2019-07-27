using System;
using System.Collections.Generic;
using FetchDispSaveAPI.Models;
using SQLite;
using Xamarin.Forms;

namespace FetchDispSaveAPI
{
    public partial class SavedPosts : ContentPage
    {
        public SavedPosts()
        {
            InitializeComponent();
            // Load Posts
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                conn.CreateTable<Post>();
                Saved_Post_List.ItemsSource = conn.Table<Post>();
            }
        }
    }
}
