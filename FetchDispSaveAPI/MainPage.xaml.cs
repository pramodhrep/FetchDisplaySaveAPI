using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using FetchDispSaveAPI.Models;
using System.IO;
using SQLite;

namespace FetchDispSaveAPI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string url = "https://jsonplaceholder.typicode.com/photos";
        private HttpClient _Client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            var content = await _Client.GetStringAsync(url);
            //Deserializes or converts JSON String into a collection of Post
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(content);
            //Assigning the ObservableCollection to MyListView in the XAML of this file
            Post_List.ItemsSource = posts;

            base.OnAppearing();

        }

        private void Post_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post post = (Post)e.SelectedItem;

            if (e.SelectedItem != null)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
                {
                    conn.CreateTable<Post>();
                    int postInserted = conn.Insert(post);

                    if (postInserted > 0)
                    {
                        DisplayAlert("Success", "Post Saved!!!", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Error", "Error in Saving Selected Post", "Try Again!");
                    }
                }

            }
        }

        private void Saved_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SavedPosts());
        }

        private void Clean_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DBPath))
            {
                conn.DeleteAll<Post>();
            }
            DisplayAlert("Success", "All Saved Posts are Now Empty", "Ok");
        }
    }
}
