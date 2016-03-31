using System;
using System.Collections.Generic;
using System.Linq;
using Example.Application.DTO;
using Example.Domain;
using Example.Domain.Entities;
using Example.Domain.Security;

namespace Example.Application
{
    public interface IMyAppService : IDisposable
    {
        IEnumerable<MyDemoDTO> GetDataItems();

        MyDemoDTO GetItem(int id);
        void UpdateItem(MyDemoDTO item);
    }

    internal class MyAppService : AppServiceBase, IMyAppService
    {
        private readonly IDataDomainService _domainservice;

        public MyAppService(IDataDomainService domainservice)
        {
            _domainservice = domainservice;
        }

        public void MethodNeedsAdminPermissions()
        {
            if (!User.IsAdmin())
                throw new Exception("User is not authorized!");
        }

        public void UpdateItem(MyDemoDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            Logger.Info("Updating MyDemoDTO..Id={0}", dto.Id);

            MyEntity entity = _domainservice.FindEntity(dto.Id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with Id " + dto.Id + " not found!");
            }

            Mapper.MapToEntity(entity, dto);

            _domainservice.Update(entity);
        }

        public IEnumerable<MyDemoDTO> GetDataItems()
        {
            return _domainservice.GetEntities().Select(f => Mapper.MapToDto(f));
        }

        public MyDemoDTO GetItem(int id)
        {
            MyEntity item = _domainservice.FindEntity(id);
            if (item != null)
            {
                return Mapper.MapToDto(item);
            }

            return null;
        }
    }
}
