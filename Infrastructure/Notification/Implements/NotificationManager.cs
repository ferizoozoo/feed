using System.Threading.Tasks;
using System;
using feed.Infrastructure.Notification.Interfaces;
using feed.Enums;

namespace feed.Infrastructure.Notification.Implements
{
    public class NotificationManager : INotificationManager
    {
        public async Task<bool> SendNotification(string content, int receiverId, int senderId, NotificationType notifType)
        {
            // Another way to use these different strategies, is to define an IStrategy and let them implement
            // this interface and register them to the DI container, after that use the GetServices method
            // to get these strategies without explicitly creating objects of these strategies
            switch(notifType)
            {
                case NotificationType.Email:
                    return await (new EmailNotificationStrategy()).SendNotification(content, receiverId, senderId);
                case NotificationType.Sms:
                    return await (new SmsNotificationStrategy()).SendNotification(content, receiverId, senderId);
                case NotificationType.RealTime:
                    return await (new SignalRNotificationStrategy()).SendNotification(content,receiverId, senderId);
                default: 
                    return await Task.Run(() => false);            
            }
        }
    }
}