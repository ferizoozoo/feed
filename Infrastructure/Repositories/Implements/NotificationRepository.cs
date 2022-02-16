using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.Repositories.Implements
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(FeedDbContext context) : base(context)
        {

        }
    }
}