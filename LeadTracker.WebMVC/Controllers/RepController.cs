using LeadTracker.Models;
using LeadTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LeadTracker.WebMVC.Controllers
{
    public class RepController : Controller
    {

        public ActionResult Index()
        {

            var service = new RepService();
            var model = service.GetReps();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new RepService();
            var model = service.GetRepByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)

        {

            var service = new RepService();
            var detail = service.GetRepByID(id);
            var model =
                new RepDetail
                {
                    ID = detail.ID,
                    Name = detail.Name,
                    Email = detail.Email,
                };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RepDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new RepService();

            if (service.UpdateRep(model))
            {
                TempData["SaveResult"] = "Rep Details Successfully Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to Update Rep");
            return View(model);
        }

        public ActionResult Create(RepCreate model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var service = new RepService();
            service.CreateRep(model);

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new RepService();
            var model = service.GetRepByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new RepService();

            service.DeleteRep(id);

            TempData["SaveResult"] = "Your rep was deleted";

            return RedirectToAction("Index");
        }
    }
}