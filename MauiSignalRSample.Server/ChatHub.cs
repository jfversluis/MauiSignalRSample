using Microsoft.AspNetCore.SignalR;

namespace MauiSignalRSample.Server
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);
            await Clients.All.SendAsync("MessageReceived", message);
        }
    }
}
