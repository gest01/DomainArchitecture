using Example.CrossCutting.DataAccess;

namespace Example.Infrastructure.Entity
{
    internal class MyUnitOfWork : UnitOfWork
    {
        public MyUnitOfWork()
            :this(new EfDbContext()) { }

        public MyUnitOfWork(IDbContext context)
            : base(context)
        { }

        protected override IRepository<TEntity> CreateRepository<TEntity>(IDbContext context)
        {
            return new EfRepository<TEntity>(context);
        }
    }
}
