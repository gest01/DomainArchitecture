using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Example.CrossCutting.DataAccess;

namespace Example.DataAccess
{
    internal class ExampleDbContext : DbContext, IDbContext
    {

        public ExampleDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)  {  }

        static ExampleDbContext()
        {
            Database.SetInitializer<ExampleDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public bool HasChanges
        {
            get
            {
                return this.ChangeTracker.Entries().Any(f => f.State == EntityState.Added)
                    || this.ChangeTracker.Entries().Any(f => f.State == EntityState.Deleted)
                    || this.ChangeTracker.Entries().Any(f => f.State == EntityState.Modified);
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this.Delete<TEntity>(entity);
        }

        public TEntity Find<TEntity>(params object[] keyValues) where TEntity : class
        {
            return this.Find<TEntity>(keyValues);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            this.Insert<TEntity>(entity);
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            this.InsertRange<TEntity>(entities);
        }

        public IQueryable<TEntity> Query<TEntity>(bool tracking = true) where TEntity : class
        {
            if (tracking)
            {
                return this.Set<TEntity>();
            }
            return this.Set<TEntity>().AsNoTracking();
        }

        public int Truncate<TEntity>() where TEntity : class
        {
           return  this.Database.ExecuteSqlCommand("TRUNCATE TABLE " + typeof(TEntity).Name);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            this.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
