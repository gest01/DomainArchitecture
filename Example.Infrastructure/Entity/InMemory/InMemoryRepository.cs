using Example.CrossCutting.DataAccess;

namespace Example.Infrastructure.Entity.InMemory
{
    internal class InMemoryRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public InMemoryRepository(IDbContext context)  : base(context)  {  }
    }
}
