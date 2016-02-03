using System;
using System.Web.Mvc;

namespace Example.Web.Controllers
{
    public class HomeController : MvcBaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UnhandledException()
        {
            throw new Exception("Test Exception"); 
        }

        [HttpGet]
        public ActionResult AngularApp()
        {
            return View();
        }
    }
}