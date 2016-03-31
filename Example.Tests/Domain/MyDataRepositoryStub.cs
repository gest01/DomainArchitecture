using System;
using System.Collections.Generic;
using System.Linq;
using Example.Domain.Entities;
using Example.Domain.Repositories;

namespace Example.Tests.Domain
{
    internal class MyDataRepositoryStub : IMyDataRepository
    {
        private List<MyEntity> _entities;

        public MyDataRepositoryStub()
        {
            _entities = new List<MyEntity>();
        }

        public void DeleteEntity(MyEntity entity)
        {
            throw new NotImplementedException();
        }

        public MyEntity Find(int id)
        {
            return _entities.SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<MyEntity> GetMyData()
        {
            return _entities;
        }

        public void UpdateEntity(MyEntity entity)
        {

        }
    }
}
