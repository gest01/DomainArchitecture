using System.Web.Http;
using Example.Application;

namespace Example.Api.Controllers
{
    public class MyDataController : ApiBaseController
    {
        private readonly MyAppService _appservice;

        public MyDataController()
        {
            _appservice = new MyAppService();
        }

        [HttpGet]
        [Route("api/mydata/{id}")]
        public IHttpActionResult GetItem(int id)
        {
            var dataitem = _appservice.GetItem(id);
            if (dataitem != null)
            {
                return Ok(dataitem);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/mydata/items")]
        public IHttpActionResult GetItems()
        {
            return Ok(_appservice.GetDataItems());
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
