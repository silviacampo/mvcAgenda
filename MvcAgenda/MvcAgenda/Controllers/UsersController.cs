using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Domain;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Models;
namespace MvcAgenda.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public int pageSize = 3;

        private IEmailSender emailsender;
        private IUserRepository repository;

        public UsersController(IEmailSender emailsender, IUserRepository repository)
        {
            this.emailsender = emailsender;
            this.repository = repository;
        
        }
        public UsersController(IUserRepository repository)
        {
             this.repository = repository;

        }
        public UsersController()
        {
         }

        //
        // GET: /Users/

        public ViewResult Index(int page = 1)
        {
            UsersListViewModel usersList = new UsersListViewModel
            {
                Users = this.repository.Users.OrderBy(u => u.username).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = this.repository.Users.Count()
                }
            };

            return View(usersList);
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            user user = this.repository.FindUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View("Edit", new user());
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                repository.SaveUser(user);
                TempData["message"] = string.Format("{0} has been saved", user.username);

                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit()
        {
            user user = repository.Users.Single(u => u.username == User.Identity.Name);
            //probably never come in
            if (user == null)
            {
                return HttpNotFound();
            } 
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                repository.SaveUser(user);
                //TempData used like viewbag (not usefull, we are redirecting and the data would pass between view and controller only in the current http request) and session(persist too long and should be erased) but deleted at the end of the http request
                TempData["message"] = string.Format("{0} has been saved", user.username);
                if (User.Identity.Name == "admin")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(user);
            }
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user user = this.repository.Users.Single(u => u.id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = repository.Users.FirstOrDefault(u => u.id == id);
            if (user != null)
            {
                repository.DeleteUser(user);
                TempData["message"] = string.Format("{0} was deleted", user.username);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
           // db.Dispose();
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public JsonResult IsUsernameAvailable(string username, int id =0)
        {
            if (!repository.Users.Any(u => u.username == username) || id > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string suggestedUID = String.Format("{0} is not available.", username);
                for (int i = 1; i < 100; i++)
                {
                    string altCandidate = username + i.ToString();
                    if (!repository.Users.Any(u => u.username == altCandidate))
                    {
                        suggestedUID = String.Format("{0} is not available. Try {1}.", username, altCandidate);
                        break;
                    }
                }
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }


        }

        [AllowAnonymous]
        public JsonResult IsEmailAvailable(string email, int id =0)
        {
            if (!repository.Users.Any(u => u.email == email)|| id > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string msg = String.Format("{0} is not available.", email);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult Menu(int? user_id = null) {
            ViewBag.SelectedUser = user_id;
            return PartialView(repository.Users.OrderBy(u=>u.username));
        }

        public PartialViewResult UserMenu(string username)
        {
            user user = repository.Users.Single(u=>u.username == username);
            return PartialView(user);
        }

        public PartialViewResult UserHiddenField(string username)
        {
            user user = repository.Users.Single(u => u.username == username);
            return PartialView(user);
        }

        public RedirectToRouteResult ResetPassword(int id, string returnUrl)
        {
            //todo reset password + send email
            return RedirectToAction("Index", new { returnUrl });
        
        }

    }
}