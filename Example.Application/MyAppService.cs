using System;
using System.Linq;
using System.Collections.Generic;
using Example.Application.DTO;
using Example.CrossCutting.Security;
using Example.Domain.Repositories;

namespace Example.Application
{
    public interface IMyAppService : IDisposable
    {
        IEnumerable<MyDemoDTO> GetData();

        MyDemoDTO GetItem(int id);
        void UpdateItem(MyDemoDTO item);
    }

    public class MyAppService : AppServiceBase, IMyAppService
    {
        private readonly IMyDataRepository _repository;

        public MyAppService()
            : this(ServiceRegistry.Container.MyDataRepository)
        {

        }

        public MyAppService(IMyDataRepository repository)
        {
            _repository = repository;
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

            var entity = _repository.Find(dto.Id);
            if (entity == null)
            {
                throw new ArgumentException("Entity with Id " + dto.Id + " not found!");
            }

            Mapper.MapToEntity(entity, dto);

            _repository.UpdateEntity(entity);
        }

        public IEnumerable<MyDemoDTO> GetData()
        {
            return _repository.GetMyData().Select(f => Mapper.MapToDto(f));
        }

        public MyDemoDTO GetItem(int id)
        {
            var item = _repository.Find(id);
            if (item != null)
            {
                return Mapper.MapToDto(item);
            }

            return null;
        }
    }
}
