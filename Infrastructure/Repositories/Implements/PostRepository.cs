using feed.Models;
using feed.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace feed.Infrastructure.Repositories.Implements
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly FeedDbContext _context;
        public PostRepository(FeedDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> GetPostsWithLikeCountAndLikedByUser(int? userId)
        {
            return await _context.Set<PostDto>().FromSqlRaw(
                "exec [dbo].[GetPostsWithLikeCountAndLikedByUser] @UserId",
                new SqlParameter("UserId", userId ?? SqlInt32.Null)
            ).ToListAsync();
        }
    }
}