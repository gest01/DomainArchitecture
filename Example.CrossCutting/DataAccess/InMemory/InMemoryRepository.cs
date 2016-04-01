namespace Example.CrossCutting.DataAccess.InMemory
{
    internal class InMemoryRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public InMemoryRepository(IDbContext context)  : base(context)  {  }
    }
}
