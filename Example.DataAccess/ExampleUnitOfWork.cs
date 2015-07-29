using Example.CrossCutting.DataAccess;

namespace Example.DataAccess
{
    internal class ExampleUnitOfWork : UnitOfWork
    {
        public ExampleUnitOfWork(IDbContext context)
            :base(context)  { }

        protected override IRepository<TEntity> CreateRepository<TEntity>(IDbContext context)
        {
            return new ExampleRepository<TEntity>(context);
        }
    }
}
