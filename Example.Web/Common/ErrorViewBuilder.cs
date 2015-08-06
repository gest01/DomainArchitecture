using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Example.CrossCutting;
using Example.Web.Models;

namespace Example.Web.Common
{
    internal static class ErrorViewBuilder
    {
        public const String TempData_Key_Exception = "TempData_Key_Exception";

        public static ViewResultBase ItemNotFound(Controller trigger, String message)
        {
            ObjectServices.Logger.CreateLogger(trigger.GetType()).Warn("Item Not Found! Message = {0}", message);

            ErrorViewModel viewmodel = new ErrorViewModel();
            viewmodel.ErrorText = message;
            viewmodel.ErrorRequestPath = trigger.HttpContext.Request.Url.AbsoluteUri;

            if (trigger.Request.UrlReferrer != null)
            {
                viewmodel.ReturnUrl = trigger.Request.UrlReferrer.AbsoluteUri;
            }

            ViewDataDictionary viewData = new ViewDataDictionary
            {
                Model = viewmodel
            };

            ViewResultBase viewresult = trigger.Request.IsAjaxRequest() ? (ViewResultBase)new PartialViewResult() : (ViewResultBase)new ViewResult();
            viewresult.ViewName = "ItemNotFound";
            viewresult.ViewData = viewData;

            return viewresult;
        }


        public static void NotAuthorized(AuthenticationChallengeContext filterContext)
        {
            filterContext.Result = NotAuthorizedViewResult(filterContext);
        }

        public static void NotAuthorized(AuthorizationContext filterContext)
        {
            filterContext.Result = NotAuthorizedViewResult(filterContext);
        }

        private static ViewResult NotAuthorizedViewResult(ControllerContext filterContext)
        {
            ObjectServices.Logger.CreateLogger(filterContext.Controller.GetType()).Warn("'{0}' is not authorized!", filterContext.HttpContext.User.Identity.Name);

            Exception error = filterContext.Controller.TempData[ErrorViewBuilder.TempData_Key_Exception] as Exception;
            String defaultTitle = String.Format("{0} is not authorized for {1}", filterContext.HttpContext.User.Identity.Name, filterContext.HttpContext.Request.Url);
            ErrorViewModel viewmodel = ErrorViewModel.CreateFromError(error, defaultTitle);

            ViewDataDictionary viewData = new ViewDataDictionary
            {
                Model = viewmodel
            };

            ViewResult viewresult = new ViewResult();
            viewresult.ViewName = "NotAuthorized";
            viewresult.ViewData = viewData;
            return viewresult;
        }

        public static void UnhandledError(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var errorObject = new
                {
                    ErrorMessage = exception.Message,
                    Stacktrace = exception.ToString()
                };


                filterContext.HttpContext.Response.StatusCode = 500;
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    ContentType = "application/json",
                    Data = errorObject
                };

                return;
            }

            ErrorViewModel viewmodel = ErrorViewModel.CreateFromError(exception, "Unhandled Error Occured");
            ViewDataDictionary viewData = new ViewDataDictionary
            {
                Model = viewmodel
            };

            ViewResult viewresult = new ViewResult();
            viewresult.ViewName = "UnhandledError";
            viewresult.ViewData = viewData;

            filterContext.Result = viewresult;
        }
    }
}