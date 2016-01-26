using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using Example.Api.Common;

namespace Example.Api.Controllers
{
    public class MyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }

    public class DemoController : ApiBaseController
    {
        [HttpPost]
        [Route("api/demo/myitem/")]
        public IHttpActionResult UpdateItem(MyItem item)
        {
            if (ModelState.IsValid)
            {
                return Ok(item);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/demo/")]
        public IHttpActionResult GetData()
        {
            return Ok(new {
             Data = new {
                 Name = "Test",
                 Id = DateTime.Now.Ticks,
                 CoolValue = 2332
             }
            });
        }

        [HttpGet]
        [Route("api/demo/exception")]
        public IHttpActionResult ThrowException()
        {
            throw new System.Exception("Demo exception");
        }

        [HttpGet]
        [ApiAdminAuthorize]
        [Route("api/demo/notauthorized")]
        public IHttpActionResult NotAuthorized()
        {
            return Ok();
        }
    }
}
