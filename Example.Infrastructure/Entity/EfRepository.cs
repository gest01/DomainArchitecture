using Example.CrossCutting.DataAccess;

namespace Example.Infrastructure.Entity
{
    internal class EfRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public EfRepository(IDbContext context)
            : base(context)
        {
        }
    }
}
