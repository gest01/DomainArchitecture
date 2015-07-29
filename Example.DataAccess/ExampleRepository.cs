using Example.CrossCutting.DataAccess;
using Example.Domain.Repositories;

namespace Example.DataAccess
{
    internal class ExampleRepository<TEntity> : ConcreteExampleRepository<TEntity> where TEntity : class
    {
        public ExampleRepository(IDbContext context)
            : base(context)  {  }
    }
}
