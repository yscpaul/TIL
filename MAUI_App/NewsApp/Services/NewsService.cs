using Android.Views;
using Java.Lang;
using NewsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static Android.App.DownloadManager;
namespace NewsApp.Services
{
    //https://openapi.naver.com/v1/search/book.json?query=유시민&display=20&start=1&sort=sim
    internal class NewsService
    {
        List<News> newsList = new List<News>();
    }

    public class BooksService
    {
        HttpClient httpClient;
        private List<Book> bookList=new();
        public BooksService()
        {
            httpClient = new HttpClient();
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            var url = "https://openapi.naver.com/v1/search/book.json?query=유시민&display=20&start=1&sort=sim";
            var result = await httpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                bookList = await result.Content.ReadFromJsonAsync<List<Book>>();
            }
            return bookList;
        }
    }
}
