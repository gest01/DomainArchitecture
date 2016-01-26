using System;
using System.Web.Http;

namespace Example.Api.Controllers
{
    public class CommonController : ApiBaseController
    {
        [HttpGet]
        [Route("api/user/context")]
        public IHttpActionResult Get()
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
