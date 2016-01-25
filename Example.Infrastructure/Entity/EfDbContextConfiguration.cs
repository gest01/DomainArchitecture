using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Example.Infrastructure.Entity
{
    public class EfDbContextConfiguration : DbConfiguration
    {
        public EfDbContextConfiguration()
        {
            this.SetDatabaseInitializer<EfDbContext>(null);

            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
