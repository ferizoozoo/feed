using System.Net.Mail;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using feed.Models;
using System.Threading.Tasks;
using System;
using feed.Infrastructure.Notifications.Interfaces;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Enums;

namespace feed.Infrastructure.Notifications.Implements
{
    public class NotificationManager : INotificationManager
    {
        private readonly IUnitOfWork _uow;

        public NotificationManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        private async Task<int> SaveNotification(string content, int receiverId)
        {
            var notification = new Notification
            {
                ReceiverId = receiverId,
                Seen = false,
                Content = content,
                CreatedAt = DateTime.Now
            };

            await _uow.NotificationRepository.AddAsync(notification);
            await _uow.CommitAsync();

            return notification.Id;
        }

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

        public async Task<bool> MarkNotificationAsSeen(int notificationId)
        {
            var notification = await _uow.NotificationRepository.GetByIdAsync(notificationId);
            if (notification == null)
                return false;
            notification.Seen = true;
            _uow.NotificationRepository.Update(notification);
            await _uow.CommitAsync();
            return true;
        }
    }
}