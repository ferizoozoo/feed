using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.Repositories.Implements
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly FeedDbContext _context;
        public NotificationRepository(FeedDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize)
        {
            return await _context.Set<Notification>().Where(x => x.ReceiverId == userId)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize);
        }
    }
}