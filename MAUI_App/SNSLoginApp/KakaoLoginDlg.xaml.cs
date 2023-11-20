using CommunityToolkit.Maui.Views;
using SNSLoginApp.WebManager;

namespace SNSLoginApp;

public partial class KakaoLoginDlg : Popup
{
    ISNSManager snsManager = null;
    public KakaoLoginDlg()
    {
        InitializeComponent();

        snsManager = new KakaoManager();
        Size = new(600, 800);
        webView.Source = KakaoAPIEndPoint.KakaoLogInUrl;
        webView.Navigated += WebView_Navigated;
    }

    private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
    {
        if (snsManager.InitUserToken(e.Url)) // 유저 토큰을 성공적으로 받은 경우
        {
            // 폼 닫기
            Console.WriteLine("액세스 토큰 얻기 시도");
            if (snsManager.GetToken())
            {
                //액세스 토큰까지 처리 완료
                this.Close();
            }
        }
    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}