using feed.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace feed.Infrastructure.Repositories.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize);
    }
}