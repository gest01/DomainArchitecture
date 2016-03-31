using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Example.CrossCutting;
using Example.CrossCutting.DataAccess;
using Example.Domain.Entities;

namespace Example.Infrastructure.Entity.InMemory
{
    internal class InMemoryDbContext : IDbContext
    {
        private static readonly MemoryStore _store = new MemoryStore();

        static InMemoryDbContext()
        {
            _store.Insert<MyEntity>(CreateDummyData().ToArray());
        }

        public bool HasChanges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _store.Remove<TEntity>(entity);
        }

        public void Dispose()
        {

        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            if (keyValues == null || keyValues.Length == 0)
                throw new ArgumentNullException("keyValues");

            // Determine Primary Key Attribute
            String primaryKeyPropertyName = "Id"; // Default PK Field
            var primaryKeyProperty = ReflectionUtil.FindCustomProperty<TEntity>(typeof(KeyAttribute));
            if (primaryKeyProperty != null)
            {
                primaryKeyPropertyName = primaryKeyProperty.Name;
            }

            var entities = _store.GetItems<TEntity>();
            foreach (TEntity entity in entities)
            {
                var instanceProperty = entity.GetType().GetProperty(primaryKeyPropertyName);
                if (instanceProperty == null)
                    throw new ArgumentException(String.Format("Unknown property '{0}' for type '{1}'!", primaryKeyPropertyName, typeof(TEntity)));

                Object value = instanceProperty.GetValue(entity);
                if (value != null)
                {
                    if (keyValues[0].Equals(value))
                        return entity;
                }
            }

            return null;

        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _store.Insert<TEntity>(entity);
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _store.Insert<TEntity>(entities.ToArray());
        }

        public IQueryable<TEntity> Query<TEntity>(bool tracking = true) where TEntity : class
        {
            return _store.GetItems<TEntity>();
        }

        public int SaveChanges()
        {
            return -1;
        }

        public int Truncate<TEntity>() where TEntity : class
        {
            return _store.Clear<TEntity>();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
        }

        private static IEnumerable<MyEntity> CreateDummyData()
        {
            List<MyEntity> entities = new List<MyEntity>();

            for (int i = 0; i < 10; i++)
            {
                entities.Add(new MyEntity() { Id = i, LastName = "Lastname " + i, Name = "Name " + i });
            }

            return entities;
        }
    }
}
