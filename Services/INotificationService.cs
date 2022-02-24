using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Models;

namespace feed.Services
{
    public interface INotificationService
    {
        Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize);
        Task<bool> MarkNotificationAsSeen(int notificationId);
    }
}