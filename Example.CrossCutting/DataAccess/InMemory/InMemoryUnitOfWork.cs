namespace Example.CrossCutting.DataAccess.InMemory
{
    /// <summary>
    /// InMemory UnitOfWork
    /// </summary>
    public class InMemoryUnitOfWork : UnitOfWork
    {
        public InMemoryUnitOfWork()
            : this(new InMemoryDbContext())  { }

        public InMemoryUnitOfWork(IDbContext context)
            :base(context)  {   }

        protected override IRepository<TEntity> CreateRepository<TEntity>(IDbContext context)
        {
            return new InMemoryRepository<TEntity>(context);
        }
    }
}
