using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
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
using feed.Infrastructure.Repositories;

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

        public async Task<PageResult<Notification>> GetAllNotificationsByPage(PageParameters pageParameters)
        {
            return await _uow.NotificationRepository.GetAllByPageAsync(pageParameters);
        }
        
        public async Task<PageResult<Notification>> GetNotificationsByReceiverIdByPage(int receiverId, PageParameters pageParameters)
        {
            return await _uow.NotificationRepository.FindByPageAsync(pageParameters, x => x.ReceiverId == receiverId);
        }

        // Not a good design, that it just passes the work to be done to an another method!
        public async Task<bool> MarkNotificationAsSeen(int notificationId)
        {
            return await _notificationManager.MarkNotificationAsSeen(notificationId);
        }
    }
}