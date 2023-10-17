using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Model
{
    internal class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }       

    }

    public partial class NaverResult
    {
        public string LastBuildDate { get; set; }
        public long Total { get; set; }
        public long Start { get; set; }
        public long Display { get; set; }
        public Book[] Books { get; set; }
    }

    public partial class Book
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public Uri Image { get; set; }
        public string Author { get; set; }
        public long Discount { get; set; }
        public string Publisher { get; set; }
        public string Pubdate { get; set; }
        public string Isbn { get; set; }
        public string Description { get; set; }
    }
}
