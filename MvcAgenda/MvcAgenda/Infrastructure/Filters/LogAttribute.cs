using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace MvcAgenda.Infrastructure.Filters
{
    public class LogAttribute: ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) 
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(string.Format("Action takes {0} secs",timer.Elapsed.TotalSeconds));
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(string.Format("Action result takes {0} secs", timer.Elapsed.TotalSeconds));
        }
    }
}