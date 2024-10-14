using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace IMF.DAL.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties = "");
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}

