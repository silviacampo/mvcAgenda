using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcAgenda.Domain.Entities
{
    [MetadataType(typeof(locationMetaData))]
   public partial class location
    {
        public global::System.Int32 id { get; set; }

        public global::System.String description { get; set; }

        public global::System.String address { get; set; }

        public global::System.String postalcode { get; set; }

        public global::System.String city { get; set; }

        public global::System.String country { get; set; }

        public global::System.Int32 timezone { get; set; }

        public List<aevent> aevents { get; set; }

        public global::System.Int32 user_id { get; set; }

        public user user { get; set; }

        public void CopyFrom(location location)
        {
            description = location.description;
            address = location.address;
            postalcode = location.postalcode;
            city = location.city;
            country = location.country;
            timezone = location.timezone;
         }

        public string label { 
            get { 
                return ((description=="" || description == null)? "" : (description + " - ")) + ((address=="" || address==null) ? "": (address + ", ")) + city; } }
    
    
    }

   public class locationMetaData
   {
       public global::System.Int32 id { get; set; }

       [DisplayName("Description")]
       [Required(ErrorMessage = "Description can't be empty")]
       public global::System.String description { get; set; }

       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields = "city, country, user_id, id")]
       [DisplayName("Address")]
       public global::System.String address { get; set; }

       [DisplayName("Postal Code")]
       public global::System.String postalcode { get; set; }

       [DisplayName("City")]
       [Required(ErrorMessage = "City can't be empty")]
       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields="address, country, user_id, id")]
       [StringLength(20, ErrorMessage = "Max 20 char")]
       public global::System.String city { get; set; }

       [DisplayName("Country")]
       [Required(ErrorMessage = "Country can't be empty")]
       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields="address, city, user_id, id")]
       [StringLength(20, ErrorMessage = "Max 20 char")]
       public global::System.String country { get; set; }

       [DisplayName("Timezone")]
       [UIHint("Timezone")]
       [Required(ErrorMessage = "TimeZone can't be empty")]
       [Range(-12, 12, ErrorMessage = "TimeZone can't be more than 12 or less than -12")]
       public global::System.Int32 timezone { get; set; }
   }

}
