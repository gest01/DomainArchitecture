using System;
using System.Collections.Generic;
using Example.Domain.Entities;
using Example.Domain.Repositories;

namespace Example.Domain
{
    public interface IDataDomainService
    {
        MyEntity FindEntity(int id);

        void Update(MyEntity entity);
        void Delete(MyEntity entity);

        IEnumerable<MyEntity> GetEntities();
    }

    internal class DataDomainService : IDataDomainService
    {
        private readonly IMyDataRepository _repository;

        public DataDomainService(IMyDataRepository repository)
        {
            _repository = repository;
        }

        public MyEntity FindEntity(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<MyEntity> GetEntities()
        {
            return _repository.GetMyData();
        }

        public void Update(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.UpdateEntity(entity);
        }

        public void Delete(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.DeleteEntity(entity);
        }

    }
}
