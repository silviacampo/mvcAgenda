using System.Web;
using System.Web.Mvc;
using MvcAgenda.Infrastructure.Filters;

namespace MvcAgenda
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
        }
    }
}