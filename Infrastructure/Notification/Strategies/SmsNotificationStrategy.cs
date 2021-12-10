using System.Threading.Tasks;
using System;
using feed.Infrastructure.Notification.Interfaces;

namespace feed.Infrastructure.Notification.Implements
{
    public class SmsNotificationStrategy
    {
        public async Task<bool> SendNotification(string content, int receiverId, int senderId)
        {
            return await Task.Run(() => true);
        }
    }
}