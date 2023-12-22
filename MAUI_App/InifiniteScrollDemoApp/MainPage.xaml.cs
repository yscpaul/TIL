using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InifiniteScrollDemoApp.Models;
using InifiniteScrollDemoApp.Services;
using MvvmHelpers;

namespace InifiniteScrollDemoApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage( MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
              
        }
    }

}
