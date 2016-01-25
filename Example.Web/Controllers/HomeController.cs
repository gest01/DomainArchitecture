using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Web.Controllers
{
    public class HomeController : MvcBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

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