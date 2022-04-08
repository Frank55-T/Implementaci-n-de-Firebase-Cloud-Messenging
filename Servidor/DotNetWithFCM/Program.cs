// See https://aka.ms/new-console-template for more information
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

Console.WriteLine("Hello, World!");


FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(@"C:\Users\frans\Downloads\prueba-fc26d-firebase-adminsdk-c70oa-75bb20bcb9.json"),
});

// This registration token comes from the client FCM SDKs.
var registrationToken = "dhwv_DWZQvi6L513m-VMts:APA91bGrX8vzPcxN4jxolFN4sBbKM4EyZkYwcuVSLNMsdrSi232sQ-ckoJHzEUq_J2nHPKl7V_Q7HkFLXekz7dK0kV73XB6JjgjtOrDK1Drdy0bExmKG9rdyLEXVp4K4NCTw1jjSdbXo";

// See documentation on defining a message payload.
var message = new Message()
{
    Data = new Dictionary<string, string>()
    {
        { "score", "850" },
        { "time", "2:45" },
    },
    Token = registrationToken,
    Notification = new Notification()
        {
            Title = "karina",
            Body = "chaneque",
        }
};

// Send a message to the device corresponding to the provided
// registration token.
string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
// Response is a message ID string.
Console.WriteLine("Successfully sent message: " + response);