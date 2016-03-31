using System.Web.Mvc;
using Example.Application;
using Example.Web.Models;

namespace Example.Web.Controllers
{
    public class DataItemController : MvcBaseController
    {
        private readonly IMyAppService _appservice;

        public DataItemController(IMyAppService appservice)
        {
            _appservice = appservice;
        }

        [HttpGet]
        public ActionResult Index()
        {
            DataItemViewModel model = new DataItemViewModel();
            model.Data = _appservice.GetDataItems();
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

        [HttpGet]
        public ActionResult Delete(int id)
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
        public ActionResult Delete(FormCollection form, int id)
        {
            var item = _appservice.GetItem(id);
            if (item == null)
            {
                return ItemNotFound("DataItem with id {0} does not exists!", id);
            }

            _appservice.DeleteItem(item);

            return RedirectToAction("Index");
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