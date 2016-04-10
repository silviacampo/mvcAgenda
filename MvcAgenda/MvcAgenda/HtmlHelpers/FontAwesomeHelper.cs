using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace MvcAgenda.HtmlHelpers
{
    public static class LinkExtensions
    {

        private static readonly String SPAN_FORMAT = "<i class=\"{0}\" alt=\"{1}\"></i>";
        private static readonly String A_END = "</a>";

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, String iconName, object htmlAttributes = null)
        {
            var linkMarkup = htmlHelper.ActionLink(" ", actionName, routeValues, htmlAttributes).ToHtmlString();
            if (!linkMarkup.EndsWith(A_END))
                throw new ArgumentException();

            var iconMarkup = String.Format(SPAN_FORMAT, iconName, linkText);
            return new MvcHtmlString(linkMarkup.Insert(linkMarkup.Length - A_END.Length, iconMarkup));
        }

    }
}