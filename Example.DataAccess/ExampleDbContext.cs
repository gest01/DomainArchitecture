using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CrossCutting.DataAccess;

namespace Example.DataAccess
{
    internal class ExampleDbContext : IDbContext
    {
        public bool HasChanges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Query<TEntity>(bool tracking = true) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public int Truncate<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
