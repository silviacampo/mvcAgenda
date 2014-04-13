using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAgenda.Views.Models
{
   public interface IFormatEventStatus
    {
       string Format(int status_id);
    }
}
