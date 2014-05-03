using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Controllers
{
    public class LocationsController : Controller
    {
        private ILocationRepository repository;

        public LocationsController(ILocationRepository repository)
        {
            this.repository = repository;       
        }

        //
        // GET: /Locations/

        public ActionResult Index()
        {
            return View(repository.Locations);
        }

        //
        // GET: /Locations/Details/5

        public ActionResult Details(int id = 0)
        {
            location location = repository.Locations.Single(l => l.id == id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        //
        // GET: /Locations/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Locations/Create

        [HttpPost]
        public ActionResult Create(location location)
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

        public ActionResult Edit(int id = 0)
        {
            location location = repository.Locations.Single(l => l.id == id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        //
        // POST: /Locations/Edit/5

        [HttpPost]
        public ActionResult Edit(Domain.Entities.location location)
        {
            if (ModelState.IsValid)
            {
                this.repository.SaveLocation(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }

        //
        // GET: /Locations/Delete/5

        public ActionResult Delete(int id = 0)
        {
            location location = repository.Locations.Single(l => l.id == id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        //
        // POST: /Locations/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            location location = repository.Locations.Single(l => l.id == id);
            repository.DeleteLocation(location);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           // repository.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult IsCityCountryAvailable(string city, string country, int id=0)
        {
            if (!repository.Locations.Any(l => l.city == city && l.country == country && l.id !=id))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string msg = String.Format("{0} already exists.", city);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get(string term="")
        {
            var selectedLocations = repository.Locations.Where(l => l.city.Contains(term)).Select(l => new { label = l.city, id = l.id}).Take(25).ToList();
            return Json(selectedLocations, JsonRequestBehavior.AllowGet);
        }
    }
}