﻿using System;
using System.Globalization;
using System.Web.Mvc;
using Example.Web.Common;
using Example.Web.Models;

namespace Example.Web.Controllers
{
    public class ErrorController : MvcBaseController
    {
        [HttpGet]
        public ActionResult UnhandledError()
        {
            Exception error = TempData[ErrorViewBuilder.TempData_Key_Exception] as Exception;
            ErrorViewModel viewmodel = ErrorViewModel.CreateFromError(error, "TODO Unhandled Error Occured");
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult PageNotFound(String aspxerrorpath)
        {
            ErrorViewModel viewmodel = new ErrorViewModel();
            viewmodel.ErrorText = String.Format(CultureInfo.CurrentCulture, "TODO Page {0} not found", aspxerrorpath);
            return View(viewmodel);
        }
    }
}