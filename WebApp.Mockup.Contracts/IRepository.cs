using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApp.Mockup.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(string lazyIncludeString);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

        IQueryable<T> FindBy(Func<T, bool> predicate);
        IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, params  Expression<Func<T, object>>[] lazyIncludes);
        IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Func<T, bool> predicate, string lazyIncludeString);

        IQueryable<T> FindByExp(Expression<Func<T, bool>> predicate, string lazyIncludeString);

    }
}
