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
        List<T> GetAll(Expression<Func<T, object>> orderBy = null, bool isDescending = false);
        Task<List<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, bool isDescending = false);
        T FirstOrDefault(Expression<Func<T, bool>> query);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> query);
        List<T> Find(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}