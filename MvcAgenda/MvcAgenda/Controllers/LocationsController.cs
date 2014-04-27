using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain;

namespace MvcAgenda.Controllers
{
    public class LocationsController : Controller
    {
       // private agendaEntities db = new agendaEntities();
        private ILocationRepository repository;

        public LocationsController(ILocationRepository repository)
        {
            this.repository = repository;       
        }

        //
        // GET: /Locations/

        public ActionResult Index()
        {
            //return View(db.locations.ToList());
            return View(repository.Locations);
        }

        //
        // GET: /Locations/Details/5

       // public ActionResult Details(int id = 0)
       // {
            //Domain.location location = repository.locations.Single(l => l.id == id);
           // if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //
        // GET: /Locations/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Locations/Create

        [HttpPost]
        public ActionResult Create(Domain.Entities.location location)
        {
            if (ModelState.IsValid)
            {
                this.repository.SaveLocation(location);
                return RedirectToAction("Index");
            }

            return View(location);
        }

        //
        // GET: /Locations/Edit/5

       // public ActionResult Edit(int id = 0)
       // {
           // Domain.location location = repository.locations.Single(l => l.id == id);
          //  if (location == null)
          //  {
         //      return HttpNotFound();
         //   }
         //   return View(location);
       // }

        //
        // POST: /Locations/Edit/5

        [HttpPost]
        public ActionResult Edit(Domain.Entities.location location)
        {
            if (ModelState.IsValid)
            {
                //repository.Attach(location);
                //repository.ObjectStateManager().ChangeObjectState(location, EntityState.Modified);
                //repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        //
        // GET: /Locations/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Domain.location location = repository.locations.Single(l => l.id == id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //
        // POST: /Locations/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Domain.location location = repository.locations.Single(l => l.id == id);
        //    repository.DeleteObject(location);
        //    repository.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
           // repository.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult IsCityCountryAvailable(string city, string country)
        {
            if (!repository.Locations.Any(l => l.city == city && l.country == country))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string msg = String.Format("{0} already exists.", city);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
    }
}