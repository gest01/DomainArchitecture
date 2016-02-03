using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Application;
using Example.Web.Models;

namespace Example.Web.Controllers
{
    public class DataItemController : MvcBaseController
    {
        private readonly IMyAppService _appservice;

        public DataItemController()
        {
            _appservice = new MyAppService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            DataItemViewModel model = new DataItemViewModel();
            model.Data = _appservice.GetData();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _appservice.GetItem(id);
            if (item == null)
            {
                return ItemNotFound("DataItem with id {0} does not exists!", id);
            }

            DataItemViewModel model = new DataItemViewModel();
            model.Item = item;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, DataItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _appservice.GetItem(id);
                if (item == null)
                {
                    return ItemNotFound("DataItem with id {0} does not exists!", id);
                }

                _appservice.UpdateItem(model.Item);


                return RedirectToAction("Index");
            }

            return View(model);
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