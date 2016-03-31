using Example.CrossCutting.DataAccess;

namespace Example.Infrastructure.Entity.InMemory
{
    internal class InMemoryUnitOfWork : UnitOfWork
    {
        public InMemoryUnitOfWork()
            : base(new InMemoryDbContext())  { }

        protected override IRepository<TEntity> CreateRepository<TEntity>(IDbContext context)
        {
            return new InMemoryRepository<TEntity>(context);
        }
    }
}
