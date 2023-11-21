using InifiniteScrollDemoApp.Models;

namespace InifiniteScrollDemoApp.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetDotos();
    }
}
