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
            ViewBag.Message = Resources.Home.homeIndexMsg;

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            //this.ControllerContext.

            return View();
        }
    }
}
