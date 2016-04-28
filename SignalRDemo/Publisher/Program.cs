using Microsoft.AspNet.SignalR.Client;
using System;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupHubPublisher();
        }

        private static void SetupHubPublisher()
        {
            var hubLocation = "http://localhost:8080/";
            var hubConnection = new HubConnection(hubLocation);
            var hubProxy = hubConnection.CreateHubProxy("TextHub");

            hubProxy.On<string>("sendText", text => Console.WriteLine("{0}", text));
            hubConnection.Start().Wait();

            var itemNumber = 0;
            while (true)
            {
                var message = String.Format("Sending Item #{0:00000000}", itemNumber++);
                hubProxy.Invoke<string>("SendText", message);
            }
        }
    }
}
