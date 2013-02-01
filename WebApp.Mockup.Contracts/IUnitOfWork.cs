using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Model;

namespace WebApp.Mockup.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Attach<T>(T obj) where T : class;
        void Add<T>(T obj) where T : class;
        IQueryable<T> Get<T>() where T : class;
        bool Remove<T>(T item) where T : class;

        IRepository<Parent>Parents { get; }
        IRepository<Child> Children { get; }
    }
}
