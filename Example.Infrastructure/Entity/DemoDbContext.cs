using System.Collections.Generic;
using System.Linq;
using Example.CrossCutting.DataAccess.InMemory;
using Example.Domain.Entities;

namespace Example.Infrastructure.Entity
{
    internal class DemoDbContext : InMemoryDbContext
    {
        static DemoDbContext()
        {
            InternalStore.Insert<MyEntity>(CreateDummyData().ToArray());
        }

        private static IEnumerable<MyEntity> CreateDummyData()
        {
            List<MyEntity> entities = new List<MyEntity>();

            for (int i = 0; i < 10; i++)
            {
                entities.Add(new MyEntity() { Id = i, LastName = "Lastname " + i, Name = "Name " + i });
            }

            return entities;
        }
    }
}
