using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Example.CrossCutting.DataAccess.InMemory
{
    /// <summary>
    /// In Memory Db context for testing
    /// </summary>
    public class InMemoryDbContext : IDbContext
    {
        protected static readonly MemoryStore InternalStore = new MemoryStore();

        public bool HasChanges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            InternalStore.Remove<TEntity>(entity);
        }

        public void Dispose()
        {

        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            if (keyValues == null || keyValues.Length == 0)
                throw new ArgumentNullException("keyValues");
            
            // Get primary key properties through KeyAttribute
            Type entityType = typeof(TEntity);
            var primaryKeyProperties = entityType.GetProperties().Where(f => KeyAttribute.IsDefined(f, typeof(KeyAttribute))).ToArray();
            if (!primaryKeyProperties.Any())
            {
                throw new ArgumentException(String.Format("No primary keys were found on type {0}! Mark primary key property with KeyAttribute", entityType.GetType()));
            }

            var entities = InternalStore.GetItems<TEntity>();
            foreach (TEntity entity in entities)
            {
                // Get primary key values of the entity
                var values = from pk2 in primaryKeyProperties select pk2.GetValue(entity);

                // compare values
                IEnumerable<object> difference = values.Except(keyValues);
                if (!difference.Any())
                    return entity; 
            }

            return null;
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            InternalStore.Insert<TEntity>(entity);
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            InternalStore.Insert<TEntity>(entities.ToArray());
        }

        public IQueryable<TEntity> Query<TEntity>(bool tracking = true) where TEntity : class
        {
            return InternalStore.GetItems<TEntity>();
        }

        public int SaveChanges()
        {
            return -1;
        }

        public int Truncate<TEntity>() where TEntity : class
        {
            return InternalStore.Clear<TEntity>();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
        }
    }
}
