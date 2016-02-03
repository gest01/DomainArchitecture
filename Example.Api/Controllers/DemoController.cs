using System;
using System.Web.Http;
using Example.Api.Common;
using Example.Application;
using Example.Application.DTO;

namespace Example.Api.Controllers
{
    public class DemoController : ApiBaseController
    {
        private readonly IMyAppService _appservice;

        public DemoController()
        {
            _appservice = new MyAppService();
        }

        [HttpPost]
        [Route("api/demo/myitem/")]
        public IHttpActionResult UpdateItem(MyDemoDTO item)
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
            return Ok(new { Items =  _appservice.GetDataItems() });
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appservice.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
