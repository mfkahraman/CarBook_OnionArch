using Microsoft.AspNetCore.SignalR;

namespace CarBook_OnionArch.WebAPI.Hubs
{
    public class MessageHub(IHttpClientFactory httpClient) : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
