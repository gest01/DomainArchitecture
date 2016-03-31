using Example.CrossCutting.DataAccess;

namespace Example.Infrastructure.Entity
{
    internal class EfUnitOfWork : UnitOfWork
    {
        public EfUnitOfWork()
            :this(new EfDbContext()) { }

        public EfUnitOfWork(IDbContext context)
            : base(context)
        { }

        protected override IRepository<TEntity> CreateRepository<TEntity>(IDbContext context)
        {
            return new EfRepository<TEntity>(context);
        }
    }
}
