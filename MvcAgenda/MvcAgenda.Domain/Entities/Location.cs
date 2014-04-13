using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAgenda.Domain.Entities
{
   public partial class location
    {
        public global::System.Int32 id { get; set; }

        public global::System.String city { get; set; }

        public global::System.String country { get; set; }

        public global::System.Int32 timezone { get; set; }

        public List<aevent> aevents { get; set; }

    }

}
