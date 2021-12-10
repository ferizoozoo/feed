using System.Threading.Tasks;
using System;
using feed.Enums;

namespace feed.Infrastructure.Notification.Interfaces
{
    public interface INotificationManager
    {
        Task<bool> SendNotification(string content, int receiverId, int senderId, NotificationType notifType);
    }
}