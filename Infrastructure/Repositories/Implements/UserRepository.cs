using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.Repositories.Implements
{
    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(FeedDbContext context) : base(context)
        {

        }
    }
}