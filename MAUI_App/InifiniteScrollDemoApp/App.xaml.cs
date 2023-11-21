using InifiniteScrollDemoApp.Services;

namespace InifiniteScrollDemoApp
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage= mainPage;
        }
    }
}
