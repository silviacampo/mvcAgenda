using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcAgenda.Domain
{
    [MetadataType(typeof(locationMetaData))]
    public partial class Location
    {
        public global::System.Int32 id { get; set; }

        public global::System.String city { get; set; }

        public global::System.String country { get; set; }

        public global::System.Int32 timezone { get; set; }
    }

    public class locationMetaData
    {
        public global::System.Int32 id { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "City can't be empty")]
        [Remote("IsCityCountryAvailable", "Locations")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String city { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "Country can't be empty")]
        [Remote("IsCityCountryAvailable", "Locations")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String country { get; set; }

        [DisplayName("Timezone")]
        [Required(ErrorMessage = "TimeZone can't be empty")]
        [Range(-12,12,ErrorMessage = "Invalide Timezone")]
        public global::System.Int32 timezone { get; set; }
    }

}