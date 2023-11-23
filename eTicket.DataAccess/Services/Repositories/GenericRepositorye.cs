using eTicket.DataAccess.Services.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class GenericRepositorye<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;
        internal DbSet<T> DbSet;
        public GenericRepositorye(ApplicationDbContext context)
        {
            this.context = context;
            DbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null,
                                string IncludeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if(filter is not null)
                query = query.Where(filter);
            if(! String.IsNullOrEmpty(IncludeProperties))
                foreach (var includeProp in IncludeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);
            return query.FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
                                                string IncludeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter is not null)
                query = query.Where(filter);
            if (!String.IsNullOrEmpty(IncludeProperties))
                foreach (var includeProp in IncludeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);
            return await query.FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
                    string IncludeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter is not null)
                query = query.Where(filter);
            if (!String.IsNullOrEmpty(IncludeProperties))
                foreach (var includeProp in IncludeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);
            if(OrderBy is not null)
                return OrderBy(query).ToList();
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                        Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
                        string IncludeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter is not null)
                query = query.Where(filter);
            if (!String.IsNullOrEmpty(IncludeProperties))
                foreach (var includeProp in IncludeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);
            if (OrderBy is not null)
                return await OrderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void RemoveById(int id)
        {
            var Obj = GetById(id);
            DbSet.Remove(Obj);
        }

        public void RemoveEntity(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
