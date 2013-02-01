using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Mockup.Contracts;
using WebApp.Mockup.Model;

namespace WebApp.Mockup.DataAccess
{
    /// <summary>
    /// "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Parent"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext).
    /// </remarks>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private WebAppDBContext _DbContext { get; set; }

        public UnitOfWork(WebAppDBContext dbContext)
        {
            this._DbContext = dbContext;
        }
        
        public void Commit()
        {
            _DbContext.SaveChanges();
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return _DbContext.Set<T>();
        }

        public bool Remove<T>(T item) where T : class
        {
            try
            {
                _DbContext.Set<T>().Remove(item);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void Attach<T>(T obj) where T : class
        {
            _DbContext.Set<T>().Attach(obj);
        }

        public void Add<T>(T obj) where T : class
        {
            _DbContext.Set<T>().Add(obj);
        }

        public IRepository<Parent> Parents
        {
            get { return new Repository<Parent>(_DbContext); }
        }

        public IRepository<Child> Children
        {
            get { return new Repository<Child>(_DbContext);  }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_DbContext != null)
                {
                    _DbContext.Dispose();
                }
            }
        }
    }
}
