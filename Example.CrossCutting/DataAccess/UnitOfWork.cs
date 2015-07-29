using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.CrossCutting.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDictionary<Type, Object> _repositories = new Dictionary<Type, Object>();

        private readonly IDbContext _ctx;

        public UnitOfWork(IDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _ctx = context;
        }

        public virtual IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                IRepository<TEntity> instance = TryCreateConcreteGenericRepositoryInstance<TEntity>(_ctx) ?? CreateRepository<TEntity>(_ctx);
                _repositories.Add(typeof(TEntity), instance);
            }

            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        protected virtual IRepository<TEntity> CreateRepository<TEntity>(IDbContext context) where TEntity : class
        {
            return new Repository<TEntity>(context);
        }

        internal IDbContext Context { get { return _ctx; } }

        private static IRepository<TEntity> TryCreateConcreteGenericRepositoryInstance<TEntity>(IDbContext context) where TEntity : class
        {
            IEnumerable<Type> implementations = FindConcreteGenericRepositoryImplementation(typeof(TEntity));
            if (implementations.Count() == 1)
            {
                return (IRepository<TEntity>)Activator.CreateInstance(implementations.First(), context);
            }

            return null;
        }

        private static IEnumerable<Type> FindConcreteGenericRepositoryImplementation(Type entityType)
        {
            Type[] types = entityType.Assembly.GetTypes();
            return
                from type in types
                let baseType = type.BaseType
                where !type.IsAbstract 
                      && !type.IsInterface
                      && baseType != null 
                      && baseType.IsGenericType 
                      && baseType.GetGenericTypeDefinition() == typeof(Repository<>)
                      && baseType.GetGenericArguments().Contains(entityType)

                select type;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repositories.Clear();
                    _ctx.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
