using System.Security.AccessControl;
using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                            .Skip(((int)pageNumber - 1) * (int)pageSize)
                            .Take((int)pageSize).ToListAsync();
        }
    }
}