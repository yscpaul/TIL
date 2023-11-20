using CommunityToolkit.Maui.Views;

namespace SNSLoginApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            webView.Source = "https://www.ziller.co.kr/Main.tjc?mp=login&accessRoute=WINDOWS";
        }

        private async void btnKakao_Clicked(object sender, EventArgs e)
        {
            var popup = new KakaoLoginDlg();
            await this.ShowPopupAsync(popup);
        }

        private void btnNaver_Clicked(object sender, EventArgs e)
        {

        }

        private void btnTJ_Clicked(object sender, EventArgs e)
        {
            //var popup = new TJLoginDlg();
            //await this.ShowPopupAsync(popup);
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {

        }
    }

}
