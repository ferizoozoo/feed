using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace feed.Infrastructure.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendToAll(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", user, message);
        }
    }
}