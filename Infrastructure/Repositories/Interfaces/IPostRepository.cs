using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Models;

namespace feed.Infrastructure.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<PostDto>> GetPostsWithLikeCountAndLikedByUser(int? userId);
    }
}