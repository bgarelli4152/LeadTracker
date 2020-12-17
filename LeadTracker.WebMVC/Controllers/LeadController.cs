using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeadTracker.Models;
using LeadTracker.Services;
using LeadTracker.Data;

namespace LeadTracker.WebMVC.Controllers
{
    public class LeadController : Controller
    {
   
        public ActionResult Index()
        {
            
            var service = new LeadService();
            var model = service.GetLeads();

            return View(model);
        }
       
        public ActionResult Details(int id)
        {
            var service = new LeadService();
            var model = service.GetLeadByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)

        {
            
            var service = new LeadService();
            var detail = service.GetLeadByID(id);
            var model =
                new LeadEdit
                {
                    ID = detail.ID,
                    Name = detail.Name,
                    Company = detail.Company,
                    Phone = detail.Phone,
                    Email = detail.Email,
                    Converted = detail.Converted
                };
            return View(model);
          
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LeadEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new LeadService();

            if (service.UpdateLead(model))
            {
                TempData["SaveResult"] = "Lead Details Successfully Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to Update Lead");
            return View(model);
        }

        public ActionResult Create(LeadCreate model)
        {

            if(!ModelState.IsValid)
             {
                return View(model);
            }


            var service = new LeadService();
            service.CreateLead(model);

            return RedirectToAction("Index");
        }
        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new LeadService();
            var model = service.GetLeadByID(id);

            return View(model);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new LeadService();

            service.DeleteLead(id);

            TempData["SaveResult"] = "Your lead was deleted";

            return RedirectToAction("Index");
        }
    }
}