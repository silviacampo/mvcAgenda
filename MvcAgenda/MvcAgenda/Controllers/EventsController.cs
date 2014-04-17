using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Models;

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
        public ViewResult Index(int? user_id, int page = 1)
        {
            EventsListViewModel viewModel = new EventsListViewModel
            {
                Events = repository.Events.Where(e => user_id == null || e.user_id == user_id ).OrderBy(e => e.title).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = user_id == null ? repository.Events.Count() : repository.Events.Where(e=> e.user_id == user_id).Count()
                },
                CurrentUser_id = user_id
            };
            return View(viewModel);
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            aevent aevent = this.repository.Events.Single(a => a.id == id);
            if (aevent == null)
            {
                return HttpNotFound();
            }
            return View(aevent);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            //List<SelectListItem> users = getUsers();
            //ViewBag.users = users;
            return View(new aevent { startTime = DateTime.Now, user_id=0 });
        }

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(aevent aevent)
        {
            //if (ModelState.IsValidField("startTime") && ModelState.IsValidField("endTime") && aevent.startTime.CompareTo(aevent.endTime) >=0)
           // {
           // ModelState.AddModelError("","Event cannot finish before staring");
           // }
            if (ModelState.IsValid)
            {
                this.repository.SaveEvent(aevent);

                SendEventByEmail(emailsender, aevent);

                if (User.Identity.Name == "silvia")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", new { controller = "Events", user_id = aevent.user_id, page = 1 });
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
            aevent aevent = this.repository.Events.Single(a => a.id == id);
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
                this.repository.SaveEvent(aevent);

                SendEventByEmail(emailsender, aevent);

                if (User.Identity.Name == "silvia")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", new { controller = "Events", user_id = aevent.user_id, page = 1 });
                }
            }
            //List<SelectListItem> users = getUsers();
            //ViewBag.users = users;
            return View(aevent);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            aevent aevent = this.repository.Events.Single(a => a.id == id);
            if (aevent == null)
            {
                return HttpNotFound();
            }
            return View(aevent);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            aevent aevent = this.repository.Events.Single(a => a.id == id);
            this.repository.DeleteEvent(aevent);

            if (User.Identity.Name == "silvia")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { controller = "Events", user_id = aevent.user_id, page = 1 });
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
    }
}