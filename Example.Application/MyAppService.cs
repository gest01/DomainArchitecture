using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Application.DTO;
using Example.CrossCutting.Security;
using Example.Domain.Repositories;

namespace Example.Application
{
    public interface IMyAppService
    {
        IEnumerable<MyDemoDTO> GetData();
    }

    internal class MyAppService : AppServiceBase, IMyAppService
    {
        public MyAppService()
            : this(ServiceRegistry.Container.MyDataRepository)
        {

        }

        public MyAppService(IMyDataRepository repository)
        {

        }

        public void MethodNeedsAdminPermissions()
        {
            if (!User.IsAdmin())
                throw new Exception("User is not authorized!");
        }

        public IEnumerable<MyDemoDTO> GetData()
        {
            return null;
        }
    }
}
