using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Example.Api.Controllers
{
    public class CommonController : ApiBaseController
    {
        public CommonController()
        {

        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
