using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.CrossCutting;
using Example.CrossCutting.Logging;
using Example.Web.Common;

namespace Example.Web.Controllers
{
    public class MvcBaseController : Controller
    {
        public MvcBaseController()
        {
            Logger = ObjectServices.Logger.CreateLogger(GetType());
        }

        protected ILogger Logger { get; private set; }

        /// <summary>
        /// Liefert die ItemNotFound View mit einem spezifischen Fehlertext
        /// </summary>
        /// <param name="format">Fehlertext</param>
        /// <param name="args">Formatparameter</param>
        /// <returns>ViewResult</returns>
        [NonAction]
        protected virtual ViewResultBase ItemNotFound(String format, params Object[] args)
        {
            return ErrorViewBuilder.ItemNotFound(this, String.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Liefert die ItemNotFound View mit einem allgemeinen Fehlertext
        /// </summary>
        /// <returns>ViewResult</returns>
        [NonAction]
        protected virtual ViewResultBase ItemNotFound()
        {
            return ItemNotFound("Object not found!");
        }
    }
}