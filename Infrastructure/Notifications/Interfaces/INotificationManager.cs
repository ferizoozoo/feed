using System.Threading.Tasks;
using System;
using feed.Enums;

namespace feed.Infrastructure.Notifications.Interfaces
{
    public interface INotificationManager
    {
        Task<bool> SendNotification(string content, int receiverId, int senderId, NotificationType notifType);
        Task<bool> MarkNotificationAsSeen(int notificationId);
    }
}