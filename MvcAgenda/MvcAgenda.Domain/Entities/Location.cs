using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using MvcAgenda.Resources;

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
                return (String.IsNullOrEmpty(description) ? String.Empty : (description + " - ")) + fullAddress;
            }
        }

        public string shortLabel
        {
            get
            {
                return String.IsNullOrEmpty(description) ? city : description;
            }
        }

        public string fullAddress
        {
            get
            {
                 return (String.IsNullOrEmpty(address) ? String.Empty : (address + ", ")) + (String.IsNullOrEmpty(postalcode) ? String.Empty : (postalcode + " - ")) + city + " (" + country + ")";
            }
        }
    
    }

   public class locationMetaData
   {
       public global::System.Int32 id { get; set; }

       [Display(Name = "locationDescription", ResourceType = typeof(Locations))]
       [Required(ErrorMessageResourceName = "locationDescriptionRequiredMsg", ErrorMessageResourceType = typeof(Locations))]
       public global::System.String description { get; set; }

       [Display(Name = "locationAddress", ResourceType = typeof(Locations))]
       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields = "city, country, user_id, id")]
       public global::System.String address { get; set; }

       [Display(Name = "locationPostalcode", ResourceType = typeof(Locations))]
       public global::System.String postalcode { get; set; }

       [Display(Name = "locationCity", ResourceType = typeof(Locations))]
       [Required(ErrorMessageResourceName = "locationCityRequiredMsg", ErrorMessageResourceType = typeof(Locations))]
       [StringLength(20, ErrorMessageResourceName = "locationCityMaxLengthMsg", ErrorMessageResourceType = typeof(Locations))]
       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields="address, country, user_id, id")]
       public global::System.String city { get; set; }

       [Display(Name = "locationCountry", ResourceType = typeof(Locations))]
       [Required(ErrorMessageResourceName = "locationCountryRequiredMsg", ErrorMessageResourceType = typeof(Locations))]
       [StringLength(20, ErrorMessageResourceName = "locationCountryMaxLengthMsg", ErrorMessageResourceType = typeof(Locations))]
       [Remote("IsCityCountryAvailable", "Locations", AdditionalFields="address, city, user_id, id")]
       public global::System.String country { get; set; }

       [Display(Name = "locationTimezone", ResourceType = typeof(Locations))]
       [UIHint("Timezone")]
       [Required(ErrorMessageResourceName = "locationTimezoneRequiredMsg", ErrorMessageResourceType = typeof(Locations))]
       [Range(-12, 12, ErrorMessageResourceName = "locationTimezoneRangeMsg", ErrorMessageResourceType = typeof(Locations))]
       public global::System.Int32 timezone { get; set; }
   }

}
