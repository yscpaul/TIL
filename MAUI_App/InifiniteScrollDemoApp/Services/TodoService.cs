﻿using InifiniteScrollDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InifiniteScrollDemoApp.Services
{

    public class TodoService : ITodoService
    {
        private readonly HttpClient httpClient;
        public TodoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Todo>> GetDotos()
        {
            var result = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
            var response = await result.Content.ReadFromJsonAsync<List<Todo>>();
            return response;
        }
    }
}
