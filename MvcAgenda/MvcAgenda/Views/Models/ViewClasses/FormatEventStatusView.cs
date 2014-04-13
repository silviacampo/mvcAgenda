using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace MvcAgenda.Views.Models.ViewClasses
{
    public class FormatEventStatusView: WebViewPage
    {
        //anotate the property to inject by property
        [Inject]
        public IFormatEventStatus Formattter { get; set; }

        public override void Execute()
        {

        }
    }
}