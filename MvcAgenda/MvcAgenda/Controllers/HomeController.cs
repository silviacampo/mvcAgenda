using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAgenda.Infrastructure.Filters;
using System.Web.UI;

namespace MvcAgenda.Controllers
{
    [OutputCache(Duration = 1000, Location = OutputCacheLocation.Client, VaryByParam = "*")]
    public class HomeController : Controller
    {
    //[ActionName("Home")] view should be home
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            //this.ControllerContext.

            return View();
        }
    }
}
