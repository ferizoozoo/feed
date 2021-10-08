using System.Threading.Tasks;
using System;
using feed.Infrastructure.Repositories.Interfaces;

namespace feed.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IPostLikeRepository PostLikeRepository { get; }
        
        int Commit();
        Task<int> CommitAsync();
    }
}