using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace PushNotifications;

public class FirebaseService
{
    private readonly FirebaseApp app;

    public FirebaseService()
    {
        app = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.GetApplicationDefault(),
            ProjectId = "react-vite-pwa-5882e",
        });
    }

    public async Task SendNotificationAsync(string fcmToken,
        string? title, string? body)
    {
        if (string.IsNullOrWhiteSpace(title))   title = "Default Title";
        if (string.IsNullOrWhiteSpace(body))   body = "Default Body";

        Message message = new()
        {
            Token = fcmToken,
            Webpush = new()
            {
                Notification = new()
                {
                    Title = title,
                    Body = body,
                    Actions = [
                        new() { ActionName = "foo", Title = "Open new dashboard"},
                        new() { ActionName = "bar", Title = "Focus last view devices"}
                    ],
                    Data = new Dictionary<string, object>()
                    {
                        { "onActionClick", new Dictionary<string, object>()
                            {
                                {"default", new {operation= "focusLastFocusedOrOpen", url= "#/dashboard"} },
                                {"foo", new {operation= "openWindow", url= "#/dashboard"} },
                                {"bar", new {operation= "focusLastFocusedOrOpen", url= "#/deviceManagement/viewDevice"} }
                            }
                        }
                    }
                }
            }
        };

        var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        Console.WriteLine("Successfully sent message: " + response);
    }

}
