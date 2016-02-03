using System;
using System.Collections.Generic;
using System.Linq;
using Example.Domain.Entities;
using Example.Domain.Repositories;

namespace Example.Infrastructure
{
    public class MyDataRepository : IMyDataRepository
    {
        private readonly static IEnumerable<MyEntity> _data = CreateDummyData();

        public IEnumerable<MyEntity> GetMyData()
        {
            return _data;
        }

        public MyEntity Find(int id)
        {
            return _data.SingleOrDefault(f => f.Id == id);
        }

        public void UpdateEntity(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Nothing todo in demo app :-)
        }

        private static IEnumerable<MyEntity> CreateDummyData()
        {
            List<MyEntity> entities = new List<MyEntity>();

            for (int i = 0; i < 10; i++)
            {
                entities.Add(new MyEntity() { Id = i, LastName = "Lastname " + i, Name = "Name " + i  });
            }

            return entities;
        }
    }
}
