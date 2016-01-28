using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.CrossCutting.Security;

namespace Example.Application
{
    internal class MyAppService : AppServiceBase
    {
        public void MethodNeedsAdminPermissions()
        {
            if (!User.IsAdmin())
                throw new Exception("User is not authorized!");


        }
    }
}
