using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using feed.Infrastructure.UnitOfWork.Interfaces;
using feed.Infrastructure.Repositories.Interfaces;
using feed.Infrastructure.Repositories.Implements;

namespace feed.Infrastructure.UnitOfWork.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FeedDbContext _context;

        // The DbContext injected here is not a generic one!!
        public UnitOfWork(FeedDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            PostRepository = new PostRepository(_context);
        }

        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}