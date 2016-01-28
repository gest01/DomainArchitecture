using System;
using System.Web.Http;
using Example.Application;

namespace Example.Api.Controllers
{
    public class CommonController : ApiBaseController
    {
        [HttpGet]
        [Route("api/user/context")]
        public IHttpActionResult Get( )
        {
            return Ok(new
            {
                User = new
                {
                    DisplayName = User.Identity.Name,
                    Id = DateTime.Now.Ticks
                }
            });
        }
    }
}
