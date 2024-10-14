using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IMF.DAL.Repository.IRepository;
using IMF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace IMF.DAL.Repository
{

    namespace IMF.DAL.Repository
    {
        public class Repository<T> : IRepository<T> where T : class
        {

            private readonly ApplicationDbContext _db;
            internal DbSet<T> dbSet;
            public Repository(ApplicationDbContext db)
            {
                _db = db;
                this.dbSet = _db.Set<T>();
            }

            public void Add(T entity)
            {
                dbSet.Add(entity);
            }


            //IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
            public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string includeProperties)
            {
                IQueryable<T> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.ToList();
            }

            public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null)
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.ToListAsync();
            }

            public T Get(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false)
            {
                IQueryable<T> query;
                if (tracked)
                {
                    query = dbSet;

                }
                else
                {
                    query = dbSet.AsNoTracking();
                }

                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();

            }
            public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false)
            {
                IQueryable<T> query;
                if (tracked)
                {
                    query = dbSet;

                }
                else
                {
                    query = dbSet.AsNoTracking();
                }

                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return await query.FirstOrDefaultAsync();
            }

            public void Remove(T entity)
            {
                dbSet.Remove(entity);
            }

            public void RemoveRange(IEnumerable<T> entity)
            {
                dbSet.RemoveRange(entity);
            }
        }
    }
}
