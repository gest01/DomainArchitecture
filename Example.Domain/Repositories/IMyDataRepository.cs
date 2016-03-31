using System;
using System.Collections.Generic;
using Example.Domain.Entities;

namespace Example.Domain.Repositories
{
    public interface IMyDataRepository
    {
        IEnumerable<MyEntity> GetMyData();

        MyEntity Find(int id);

        void UpdateEntity(MyEntity entity);
        void DeleteEntity(MyEntity entity);
    }
}
