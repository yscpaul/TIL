﻿using CommunityToolkit.Mvvm.Messaging;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Diagnostics;

namespace FirebaseDemo
{
    public partial class MainPage : ContentPage
    {
        int count = 0; private string _deviceToken;

        public MainPage()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<PushNotificationReceived>(this, (r, m) =>
            {
                string msg = m.Value;
                NavigateToPage();
            });

            if (Preferences.ContainsKey("DeviceToken"))
            {
                _deviceToken = Preferences.Get("DeviceToken", "");
            }

            ReadFireBaseAdminSdk();
             



            NavigateToPage();
        }
        private async void ReadFireBaseAdminSdk()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("fcm.json");
            var reader = new StreamReader(stream);

            var jsonContent = reader.ReadToEnd();
            

            if (FirebaseMessaging.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(jsonContent)
                });
            }

            
        }
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var androidNotificationObject = new Dictionary<string, string>();
            androidNotificationObject.Add("NavigationID", "2");

            var iosNotificationObject = new Dictionary<string, object>();
            iosNotificationObject.Add("NavigationID", "2");

            var pushNotificationRequest = new PushNotificationRequest
            {
                notification = new NotificationMessageBody
                {
                    title = "Notification Title",
                    body = "Notification body"
                },
                data = androidNotificationObject,
                registration_ids = new List<string> { _deviceToken }
            };

            var messageList = new List<Message>();

            var obj = new Message
            {
                //Token = _deviceToken,
                Topic="all",
                Notification = new Notification
                {
                    Title = "Tilte",
                    Body = "message body"
                },
                Data = androidNotificationObject,
                Apns = new ApnsConfig()
                {
                    Aps = new Aps
                    {
                        Badge = 15,
                        CustomData = iosNotificationObject,
                    }
                }
            };

            messageList.Add(obj);

            var response = await FirebaseMessaging.DefaultInstance.SendAllAsync(messageList);

            //string url = "https://fcm.googleapis.com/fcm/send";

            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("key", "=" + "");

            //    string serializeRequest = JsonConvert.SerializeObject(pushNotificationRequest);
            //    var response = await client.PostAsync(url, new StringContent(serializeRequest, Encoding.UTF8, "application/json"));
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        await App.Current.MainPage.DisplayAlert("Notification sent", "notification sent", "OK");
            //    }
            //}
        }


        private void NavigateToPage()
        {

            if (Preferences.ContainsKey("NavigationID"))
            {
                string id = Preferences.Get("NavigationID", "");
                if (id == "1")
                {
                    //AppShell.Current.GoToAsync(nameof(NewPage1));
                }
                if (id == "2")
                {
                    //AppShell.Current.GoToAsync(nameof(NewPage2));
                }
                Preferences.Remove("NavigationID");
            }
        }

        private void MessageBtn_Clicked(object sender, EventArgs e)
        {
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    { "mmData","12232" },
                },
                //Token = registrationToken,
                Topic = "all",
                Notification = new Notification()
                {
                    Title = "Test from code",
                    Body = "Here is your test!"
                }
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string.
            Debug.WriteLine("Successfully sent message: " + response);

        }
    }


}
