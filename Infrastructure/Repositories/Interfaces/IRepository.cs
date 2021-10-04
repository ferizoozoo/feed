using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace feed.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        List<T> Find(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}