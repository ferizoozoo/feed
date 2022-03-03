using System.Reflection.Metadata;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using feed.Infrastructure.Repositories;

namespace feed.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> GetAll(Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        PageResult<T> GetAllByPage(PageParameters pageParameters, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        Task<PageResult<T>> GetAllByPageAsync(PageParameters pageParameters, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        T FirstOrDefault(Expression<Func<T, bool>> query, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> query, params Expression<Func<T, object>>[] includes);
        List<T> Find(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        PageResult<T> FindByPage(PageParameters pageParameters, Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        Task<PageResult<T>> FindByPageAsync(PageParameters pageParameters, Expression<Func<T, bool>> query, Expression<Func<T, object>> orderBy = null, bool isDescending = false, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}