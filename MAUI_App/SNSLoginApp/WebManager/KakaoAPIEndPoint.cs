using Newtonsoft.Json.Linq;
using RestSharp;
using System.Drawing;

namespace SNSLoginApp.WebManager
{
    internal interface ISNSManager
    {
        bool GetToken();
        void GetUserData();
        Bitmap GetWebImageAsync(string url);
        bool InitUserToken(string cur_url);
        int Logout();
    }

    class KakaoAPIEndPoint
    {
        // API 정보
        public const string RestAPIKey = "dd12c45205dbcc47295ace45508eead5";

        // Redirect URL
        public const string KakaoRedirectUrl = "http://fseason.info/posts";

        // 로그인 url
        public const string KakaoLogInUrl = "https://kauth.kakao.com/oauth/authorize?client_id=" + RestAPIKey + "&redirect_uri=" + KakaoRedirectUrl + "&response_type=code";

        // 루트 url
        public const string KakaoHostOAuthUrl = "https://kauth.kakao.com";
        public const string KakaoHostApiUrl = "https://kapi.kakao.com";

        // 이벤트 url
        public const string KakaoOAuthUrl = "/oauth/token"; // AccessToken
        public const string KakaoUnlinkUrl = "/v1/user/unlink"; // LogOut 
        public const string KakaoUserDataUrl = "/v2/user/me"; // 사용자 데이터
    }
    class KakaoData
    {
        // 유저 데이터
        public static string UserToken; // 유저 토큰
        public static string accessToken; // 에셋 토큰
        public static string UserNickName; // 사용자 이름
        public static Bitmap UserImg; // 사용자 이미지
    }
    class KakaoManager : ISNSManager
    {
        /// <summary>
        /// 유저 토큰 얻기
        /// </summary>
        /// <param name="cur_url">token url</param>
        /// <returns>성공 여부 true, false</returns>
        public bool InitUserToken(string cur_url)
        {
            string redirectURI = cur_url;
            if (redirectURI.IndexOf("access_denied") != -1)
                return false;

            int tokenIdx = redirectURI.IndexOf("code=");
            if (tokenIdx == -1)
                return false;

            string userToken = redirectURI.Substring(tokenIdx + ("code=").Length);
            Console.WriteLine($"redirectURI: [{redirectURI}]");
            Console.WriteLine("userToken: " + userToken);
            KakaoData.UserToken = userToken;
            return true;
        }

        public bool GetToken()
        {
            var client = new RestClient(KakaoAPIEndPoint.KakaoHostOAuthUrl);

            var req = new RestRequest(KakaoAPIEndPoint.KakaoOAuthUrl, Method.Post);
            req.AddParameter("grant_type", "authorization_code");
            req.AddParameter("client_id", KakaoAPIEndPoint.RestAPIKey);
            req.AddParameter("redirect_uri", KakaoAPIEndPoint.KakaoRedirectUrl);
            req.AddParameter("code", KakaoData.UserToken);


            var restResponse = client.Execute(req);
            var json = JObject.Parse(restResponse.Content);
            KakaoData.accessToken = json["access_token"].ToString();
            //Console.WriteLine($"json: {json.ToString()}");
            return true;
        }

        public int Logout()
        {
            RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoUnlinkUrl, Method.Post);
            req.AddHeader("Authorization", $"Bearer {KakaoData.accessToken}");

            RestClient client = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
            var response = client.Execute(req);
            var json = JObject.Parse(response.Content);
            Console.WriteLine(json.ToString());
            return json["id"].ToObject<Int32>();
        }

        public async void GetUserData()
        {
            RestRequest req = new RestRequest(KakaoAPIEndPoint.KakaoUserDataUrl, Method.Post);
            req.AddHeader("Authorization", $"Bearer {KakaoData.accessToken}");

            RestClient client = new RestClient(KakaoAPIEndPoint.KakaoHostApiUrl);
            var response = client.Execute(req);
            var json = JObject.Parse(response.Content);

            if (json["properties"]["profile_image"] != null)
            {
                string imageUrl = json["properties"]["profile_image"].ToString();
                KakaoData.UserImg = await GetWebImageAsync(imageUrl);
            }
            KakaoData.UserNickName = json["properties"]["nickname"].ToString();
        }

        public async Task<Bitmap> GetWebImageAsync(string url)
        {
            Bitmap bitmap = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(url);

                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        bitmap = new Bitmap(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"이미지 다운로드 중 오류 발생: {ex.Message}");
            }
            return bitmap;
        }

        Bitmap ISNSManager.GetWebImageAsync(string url)
        {
            throw new NotImplementedException();
        }
    }
}
