using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.CrossCutting;
using Example.CrossCutting.Logging;

namespace Example.Web.Controllers
{
    public class MvcBaseController : Controller
    {
        public MvcBaseController()
        {
            Logger = ObjectServices.Logger.CreateLogger(GetType());
        }

        protected ILogger Logger { get; private set; }
    }
}