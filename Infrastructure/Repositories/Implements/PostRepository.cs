using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.Repositories.Implements
{
    public class PostRepository : Repository<Post> , IPostRepository
    {
        public PostRepository(FeedDbContext context) : base(context)
        {

        }
    }
}