using Example.CrossCutting.DataAccess.InMemory;

namespace Example.Infrastructure.Entity
{
    internal class DemoUnitOfWork : InMemoryUnitOfWork
    {
        public DemoUnitOfWork()
            :base(new DemoDbContext())
        {

        }
    }
}
