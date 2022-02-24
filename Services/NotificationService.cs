using System.Reflection.Metadata;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Infrastructure.Notifications.Interfaces;
using feed.Models;
using Microsoft.Extensions.Options;

namespace feed.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationManager _notificationManager;

        public NotificationService(IUnitOfWork uow, INotificationManager notificationManager)
        {
            _uow = uow;
            _notificationManager = notificationManager;
        }

        public async Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize)
        {
            return await _uow.NotificationRepository.GetNotificationsByUserId(userId, pageNumber, pageSize);
        }

        // Not a good design, that it just passes the work to be done to an another method!
        public async Task<bool> MarkNotificationAsSeen(int notificationId)
        {
            return await _notificationManager.MarkNotificationAsSeen(notificationId);
        }
    }
}