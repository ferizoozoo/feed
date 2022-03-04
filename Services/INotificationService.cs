using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Models;
using feed.Infrastructure.Repositories;

namespace feed.Services
{
    public interface INotificationService
    {
        Task<PageResult<Notification>> GetNotificationsByUserIdByPage(int userId, PageParameters pageParameters);
        Task<PageResult<Notification>> GetAllNotificationsByPage(PageParameters pageParameters);
        Task<bool> MarkNotificationAsSeen(int notificationId);
    }
}