﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Models;
using MvcAgenda;

namespace MvcAgenda.Controllers
{
    public class EventsController : Controller
    {
        private IEmailSender emailsender;
        private IEventRepository repository;

        public EventsController(IEmailSender emailsender, IEventRepository repository)
        {
            this.emailsender = emailsender;
            this.repository = repository;

        }

        public EventsController(IEventRepository repository)
        {
            this.repository = repository;

        }

        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase file)
        //{ 
        ////save the file to disk on the server
        //    string filename = "myfilename";
        //    file.SaveAs(filename);

        //    //or work with the data directly
        //    byte[] uploadedBytes = new byte[file.ContentLength];
        //    file.InputStream.Read(uploadedBytes, 0, file.ContentLength);
        //    //now do something with uploaded bytes

        //    //enctype="multipart/form-data"
        //}

        private List<SelectListItem> getUsers()
        {
            if (TempData["users"] == null)
            {
                //List<SelectListItem> users = (from u in db.users.AsEnumerable()
                //                               select new SelectListItem() { Text = u.username, Value = u.id.ToString() }).ToList();
                // users.Add(new SelectListItem() { Text = "Choose", Value = "0" });
                // TempData["users"] = users;
            }
            return (List<SelectListItem>)TempData["users"];
        }



        //
        // GET: /Events/
        public int pageSize = 5;
        public ViewResult Index(int page = 1)
        {
            ListViewModel<aevent> viewModel = new ListViewModel<aevent>
            {
                Items = repository.Events.Where(e => User.Identity.Name == "" || e.user.username == User.Identity.Name).OrderByDescending(e => e.startTime).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = User.Identity.Name == "" ? repository.Events.Count() : repository.Events.Where(e => e.user.username == User.Identity.Name).Count()
                },
                Current = User.Identity.Name
            };
            return View(viewModel);
        }

        public ViewResult Calendar(string id = "")
        {
            List<aevent> events = repository.Events.Where(e => id == "" || e.user.username == id).OrderBy(e => e.startTime).ToList();
            return View(events);
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            aevent aevent = this.repository.Events.SingleOrDefault(a => a.id == id);
            if (aevent == null)
            {
                return HttpNotFound();
            }
            return View(aevent);
        }

        //
        // GET: /Events/Create

        public ActionResult Create(string strStartTime)
        {
            //List<SelectListItem> users = getUsers();
            //ViewBag.users = users;
            DateTime startTimeObj = DateTime.Now;
            if (strStartTime != null && strStartTime.Length > 0)
            {
                strStartTime = strStartTime.Replace('!', ':');
                startTimeObj = DateTime.Parse(strStartTime);
            }
            return View(new aevent { startTime = startTimeObj, user_id = 0 });
        }

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(aevent aevent)
        {
            if (ModelState.IsValid)
            {
                if (this.repository.SaveEvent(aevent))
                {

                    SendEventByEmail(emailsender, aevent);
                    return RedirectToAction("Index");
                }

            }
            List<SelectListItem> users = getUsers();
            ViewBag.users = users;
            return View(aevent);
        }



        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            aevent aevent = this.repository.Events.SingleOrDefault(a => a.id == id);
            List<SelectListItem> users = getUsers();
            ViewBag.users = users;
            if (aevent == null)
            {
                return HttpNotFound();
            }
            return View(aevent);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult Edit(aevent aevent)
        {
            if (ModelState.IsValid)
            {
                if (this.repository.SaveEvent(aevent))
                {
                    //SendEventByEmail(emailsender, aevent);

                    return RedirectToAction("Index");
                }
            }
            //List<SelectListItem> users = getUsers();
            //ViewBag.users = users;
            return View(aevent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditDate(int id, string strStartTime, string strEndTime)
        {
            aevent aevent = this.repository.Events.SingleOrDefault(a => a.id == id);
            if (aevent == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (strStartTime != null && strStartTime.Length > 0)
                {
                    aevent.startTime = DateTime.Parse(strStartTime);
                }
                if (strEndTime != null && strEndTime.Length > 0)
                {
                    aevent.endTime = DateTime.Parse(strEndTime);
                }

                if (this.repository.SaveEvent(aevent))
                {

                    //SendEventByEmail(emailsender, aevent);

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            aevent aevent = this.repository.Events.SingleOrDefault(a => a.id == id);
            if (aevent == null)
            {
                return HttpNotFound();
            }
            return View(aevent);
        }

        //
        // POST: /Events/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    aevent aevent = this.repository.Events.SingleOrDefault(a => a.id == id);
        //    this.repository.DeleteEvent(aevent);

        //    if (User.Identity.Name == "admin")
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", new { controller = "Home" });
        //    }
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            aevent aevent = repository.Events.SingleOrDefault(l => l.id == id);
            if (repository.DeleteEvent(aevent))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            base.Dispose(disposing);
        }


        private void SendEventByEmail(IEmailSender emailsender, aevent aevent)
        {
            emailsender.SendMail(aevent);
        }

        public JsonResult IsStartingDateAvailable(int userid, string startingDate)
        {
            DateTime parsedDate;
            if (!DateTime.TryParse(startingDate, out parsedDate))
            {
                return Json("Please enter a valid date", JsonRequestBehavior.AllowGet);
            }
            else if (!repository.Events.Any(u => u.user_id == userid && u.startTime == parsedDate))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string msg = String.Format("{0} is not available.", startingDate.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsStartDateValid(DateTime startTime, DateTime? endTime, int id = 0)
        {
                if (id == 0)
                {
                    if (startTime < DateTime.Now)
                    {
                        return Json(Resources.Events.eventStartTimeFutureDateMsg, JsonRequestBehavior.AllowGet);
                    }
                }

                if (endTime != null)
                {
                    if (startTime.CompareTo(endTime) >= 0)
                    {
                        return Json(Resources.Events.eventEndTimeGreaterStartTime, JsonRequestBehavior.AllowGet);
                    }
                }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEndDateValid(DateTime startTime, DateTime? endTime, int id = 0)
        {
            if (endTime != null)
            {
                if (id == 0)
                {
                    if (endTime < DateTime.Now)
                    {
                        return Json(Resources.Events.eventEndTimeFutureDateMsg, JsonRequestBehavior.AllowGet);
                    }
                }
                if (startTime.CompareTo(endTime) >= 0)
                {
                    return Json(Resources.Events.eventEndTimeGreaterStartTime, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}