using Microsoft.AspNet.SignalR.Client;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupHubSubscriber();
            Console.ReadKey();
        }

        private static void SetupHubSubscriber()
        {
            var hubLocation = "http://localhost:8080/";
            var hubConnection = new HubConnection(hubLocation);
            var hubProxy = hubConnection.CreateHubProxy("TextHub");

            hubConnection.Start().Wait();
            hubProxy.On("sendText", (text) =>
            {
                Console.WriteLine("Recieved {0}: ", text);
            });
        }
    }
}
