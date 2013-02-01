using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Contracts;

namespace WebApp.Mockup.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext dbContext)
        {
            if (dbContext == null) 
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<T> GetAll(string lazyIncludeString)
        {
            return DbSet.Include(lazyIncludeString);
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }  
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        public IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate)
        {
            DbSet<T> set = (DbSet<T>)DbContext.Set<T>();

            return set.Where(predicate).AsQueryable<T>();
        }

        public IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, string lazyIncludeString)
        {
            DbSet<T> set = (DbSet<T>)DbContext.Set<T>();

            return set.Include(lazyIncludeString).Where(predicate).AsQueryable<T>();
        }

        public IQueryable<T> FindBy(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] lazyIncludes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Func<T, bool> predicate, string lazyIncludeString)
        {
            throw new NotImplementedException();
        }
    }
}
