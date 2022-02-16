using System.Threading.Tasks;
using System;
using feed.Infrastructure.Notifications.Interfaces;

namespace feed.Infrastructure.Notifications.Implements
{
    public class SignalRNotificationStrategy
    {
        public async Task<bool> SendNotification(string content, int receiverId, int senderId)
        {
            return await Task.Run(() => true);
        }
    }
}