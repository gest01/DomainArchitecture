using System.Web.Http;

namespace Example.Api.Controllers
{
    public class MyController : ApiBaseController
    {
        public IHttpActionResult Get()
        {
            return Ok("Hello, World!");
        }

        [HttpGet]
        [Route("api/demo/exception")]
        public IHttpActionResult ThrowException()
        {
            throw new System.Exception("Demo exception");
        }
    }
}
