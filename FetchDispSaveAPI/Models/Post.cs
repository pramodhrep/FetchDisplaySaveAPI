using System;
using SQLite;

namespace FetchDispSaveAPI.Models
{
    public class Post
    {
        /*
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; } */

        [PrimaryKey, AutoIncrement]
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        //empty contructor to use if no data is available to import
        public Post()
        {
        }
    }
}
