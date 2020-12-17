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
    }
}