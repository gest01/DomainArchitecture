using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        public Repository()
        {

        }

        /// <summary>Liefert den Db Context</summary>
		protected IDbContext Context { get; private set; }

        public IQueryable<TEntity> Query(bool tracking = true)
        {
            return Context.Query<TEntity>(tracking);
        }

        public TEntity Find(params object[] keyValues)
        {
            return Context.Find<TEntity>(keyValues);
        }

        public void Insert(TEntity entity)
        {
            Context.Insert(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            Context.InsertRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Delete(entity);
        }

        public int Truncate()
        {
            return Context.Truncate<TEntity>();
        }

        public bool HasChanges
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

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

     
        #endregion
    }
}
