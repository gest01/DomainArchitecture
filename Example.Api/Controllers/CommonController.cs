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
        [Route("api/user/context")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
