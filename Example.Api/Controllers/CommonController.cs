using System;
using System.Web.Http;
using Example.Domain.Security;

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
                    DisplayName = User.GetDisplayName(),
                    Id = DateTime.Now.Ticks
                }
            });
        }
    }
}
