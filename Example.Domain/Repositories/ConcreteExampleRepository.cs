using Example.CrossCutting.DataAccess;

namespace Example.Domain.Repositories
{
    public class ConcreteExampleRepository<TEntity> : Repository<TEntity>  where TEntity : class
    {
        public ConcreteExampleRepository(IDbContext context)
            :base(context)  { }
    }
}
