using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using feed.Models;

namespace feed.Infrastructure
{
    public class FeedDbContext : DbContext
    {
        public FeedDbContext(DbContextOptions<FeedDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}