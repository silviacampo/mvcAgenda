using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAgenda
{
    public interface IEmailSender
    {
      void SendMail(object obj);
    }
}
