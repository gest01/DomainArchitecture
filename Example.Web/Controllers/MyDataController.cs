using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Web.Controllers
{
    /// <summary>
    /// MVC Controller for Angular MyDataModule
    /// </summary>
    public class MyDataController : MvcBaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Items()
        {
            return PartialView();
        }


        [HttpGet]
        public ActionResult Detail()
        {
            return PartialView();
        }
    }
}