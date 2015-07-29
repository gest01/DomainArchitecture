using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        public Repository(IDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            Context = context;
        }

		protected IDbContext Context { get; private set; }

        public virtual IQueryable<TEntity> Query(bool tracking = true)
        {
            return Context.Query<TEntity>(tracking);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return Context.Find<TEntity>(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Insert(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            Context.InsertRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Delete(entity);
        }

        public virtual int Truncate()
        {
            return Context.Truncate<TEntity>();
        }

        public virtual  bool HasChanges
        {
            get
            {
                return Context.HasChanges;
            }
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }


                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

     
        #endregion
    }
}
