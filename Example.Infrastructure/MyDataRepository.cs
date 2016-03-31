using System;
using System.Collections.Generic;
using System.Linq;
using Example.CrossCutting.DataAccess;
using Example.Domain.Entities;
using Example.Domain.Repositories;

namespace Example.Infrastructure
{
    internal class MyDataRepository : IMyDataRepository
    {
        private readonly IUnitOfWork _context;

        public MyDataRepository(IUnitOfWork context)
        {
            _context = context;
        }

        public IEnumerable<MyEntity> GetMyData()
        {
            return _context.RepositoryFor<MyEntity>().Query();
        }

        public MyEntity Find(int id)
        {
            return _context.RepositoryFor<MyEntity>().Find(id);
        }


        public void DeleteEntity(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.RepositoryFor<MyEntity>().Delete(entity);
            _context.Commit();
        }

        public void UpdateEntity(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.RepositoryFor<MyEntity>().Update(entity);
            _context.Commit();
        }
    }
}
