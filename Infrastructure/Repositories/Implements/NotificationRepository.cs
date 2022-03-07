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
        public NotificationRepository(FeedDbContext context) : base(context)
        {

        }
    }
}