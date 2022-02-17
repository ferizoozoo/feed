using System.Reflection.Metadata;
using System.Numerics;
using System.Threading;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Models;
using Microsoft.Extensions.Options;

namespace feed.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;

        public NotificationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize)
        {
            return await _uow.NotificationRepository.GetNotificationsByUserId(userId, pageNumber, pageSize);
        }
    }
}