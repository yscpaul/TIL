using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InifiniteScrollDemoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string title { get; set; }
        public bool Completed { get; set; }
    }
}
