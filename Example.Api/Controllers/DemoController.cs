using System;
using System.Collections.Generic;
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
        [Route("api/demo/myitem")]
        public IHttpActionResult GetData()
        {
            List<MyItem> items = new List<MyItem>();
            for (int i = 0; i < 5; i++)
            {
                items.Add(new MyItem() { Id = i, Name = "Hello " + i, LastName = "World " + i });
            }

            return Ok(new { Items = items });
        }

        [HttpGet]
        [Route("api/demo/exception")]
        public IHttpActionResult ThrowException()
        {
            throw new Exception("Demo exception");
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
