using CommunityToolkit.Mvvm.Messaging.Messages;

namespace FirebaseDemo
{
    public class PushNotificationRequest
    {
        public List<string> registration_ids { get; set; } = new List<string>();
        public NotificationMessageBody notification { get; set; }
        public object data { get; set; }
    }
    public class NotificationMessageBody
    {
        public string title { get; set; }
        public string body { get; set; }
    }

    public class PushNotificationReceived : ValueChangedMessage<string>
    {
        public PushNotificationReceived(string message) : base(message) { }
    }
}
