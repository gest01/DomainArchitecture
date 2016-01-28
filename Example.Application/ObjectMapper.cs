using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Application.DTO;
using Example.Domain.Entities;

namespace Example.Application
{
    internal class ObjectMapper
    {
        public MyDemoDTO MapToDto(MyEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            MyDemoDTO dto = new MyDemoDTO();
            dto.Id = entity.Id;
            dto.LastName = entity.LastName;
            dto.Name = entity.Name;
            return dto;
        }

        public MyEntity MapToEntity(MyDemoDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            MyEntity entity = new MyEntity();
            entity.Id = dto.Id;
            entity.LastName = dto.LastName;
            entity.Name = dto.Name;
            return entity;
        }
    }
}
