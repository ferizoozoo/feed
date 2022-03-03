using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Models;
using feed.Infrastructure.Repositories;

namespace feed.Services
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize);
        Task<PageResult<Notification>> GetAllNotificationsByPage(PageParameters pageParameters);
        Task<PageResult<Notification>> GetNotificationsByReceiverIdByPage(int receiverId, PageParameters pageParameters);
        Task<bool> MarkNotificationAsSeen(int notificationId);
    }
}