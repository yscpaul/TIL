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
        if (snsManager.InitUserToken(e.Url)) // ���� ��ū�� ���������� ���� ���
        {
            // �� �ݱ�
            Console.WriteLine("�׼��� ��ū ��� �õ�");
            if (snsManager.GetToken())
            {
                //�׼��� ��ū���� ó�� �Ϸ�
                this.Close();
            }
        }
    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}