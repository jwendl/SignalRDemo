using Microsoft.AspNet.SignalR;

namespace HubService
{
    public class TextHub
        : Hub
    {
        public void SendText(string text)
        {
            Clients.All.sendText(text);
        }
    }
}
