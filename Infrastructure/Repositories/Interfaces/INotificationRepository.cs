using feed.Models;

namespace feed.Infrastructure.Repositories.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize);
    }
}