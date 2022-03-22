using EtnaShop.DataAccess.Data;
using EtnaShop.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EtnaShop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProp = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
                query = query.Where(filter);
            if(includeProp != null)
                query=query.Include(includeProp);
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProp = null)
        {
            IQueryable<T> query = dbSet;
            query=query.Where(filter);
            if (includeProp != null)
                query = query.Include(includeProp);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Removerange(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities);
        }
    }
}
