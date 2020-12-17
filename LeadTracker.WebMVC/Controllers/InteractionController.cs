using LeadTracker.Models;
using LeadTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeadTracker.WebMVC.Controllers
{
    public class InteractionController : Controller
    {
        public ActionResult Index()
        {

            var service = new InteractionService();
            var model = service.GetInteractions();

            return View(model);
        }
        public ActionResult Create(InteractionCreate model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var service = new InteractionService();
            service.CreateInteraction(model);

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)

        {

            var service = new InteractionService();
            var detail = service.GetInteractionById(id);
            var model =
                new InteractionEdit
                {
                    InteractionID = detail.InteractionID,
                    TypeOfContact = detail.TypeOfContact,
                    Description = detail.Description,
                    ModifiedUtc = DateTimeOffset.Now
                };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InteractionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InteractionID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new InteractionService();

            if (service.UpdateInteraction(model))
            {
                TempData["SaveResult"] = "Interaction Details Successfully Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to Update Interaction");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = new InteractionService();
            var model = service.GetInteractionById(id);
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new InteractionService();
            var model = service.GetInteractionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new InteractionService();

            service.DeleteInteraction(id);

            TempData["SaveResult"] = "Your interaction was deleted";

            return RedirectToAction("Index");
        }
    }
}