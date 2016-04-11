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
using MvcAgenda.Models;

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
        public int pageSize = 5;
        public ActionResult Index(int page = 1)
        {
            ListViewModel<location> viewModel = new ListViewModel<location>
            {
                Items = repository.Locations.Where(l => User.Identity.Name == "" || l.user.username == User.Identity.Name).OrderBy(l => l.description).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = User.Identity.Name == "" ? repository.Locations.Count() : repository.Locations.Where(e => e.user.username == User.Identity.Name).Count()
                },
                Current = User.Identity.Name
            };
            return View(viewModel);
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

        public PartialViewResult Delete(int id = 0)
        {
            location location = repository.Locations.Single(l => l.id == id);
            if (location == null)
            {
                //return HttpNotFound();
            }
            return PartialView(location);
        }

        //
        // POST: /Locations/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    location location = repository.Locations.SingleOrDefault(l => l.id == id);
        //    repository.DeleteLocation(location);
        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            location location = repository.Locations.SingleOrDefault(l => l.id == id);
            if (repository.DeleteLocation(location)) {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        protected override void Dispose(bool disposing)
        {
           // repository.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult IsCityCountryAvailable(string address, string city, string country, int user_id, int id=0)
        {
            if (!repository.Locations.Any(l=>l.address == address && l.city == city && l.country == country && l.user_id == user_id && l.id !=id))
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
            var selectedLocations = repository.Locations.Where(l => l.description.Contains(term) || l.city.Contains(term) || l.address.Contains(term)).ToList();
            var selectedValues = selectedLocations.Select(l => new { label = l.label, id = l.id });
            return Json(selectedValues, JsonRequestBehavior.AllowGet);
        }
    }
}