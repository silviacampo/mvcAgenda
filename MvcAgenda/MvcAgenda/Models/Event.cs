using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Data.Objects.DataClasses;
using System.Web.Mvc;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda
{
    //[MetadataType(typeof(eventMetaData))]
    //public partial class aevent
    //{
    //}
    public class eventMetaData
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title can't be empty")]
        [StringLength(50, ErrorMessage = "Max 50 char")]
        public global::System.String title { get; set; }

        [DisplayName("Description")]
        [StringLength(200, ErrorMessage = "Max 200 char")]
        public global::System.String description { get; set; }

        [Range(1,int.MaxValue,ErrorMessage="You must choose a user")]
        public global::System.Int32 user_id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
        public global::System.Int32 location_id { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Start Time can't be empty")]
        [FutureDate(ErrorMessage="Start Time must be a date in the future")]
        public global::System.DateTime startTime { get; set; }

        [DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "End Time must be a date in the future")]
        public Nullable<global::System.DateTime> endTime { get; set; }

        [Required(AllowEmptyStrings=true, ErrorMessage = "URL can't be empty")]
        [StringLength(200, ErrorMessage = "Max 200 char")]
        [RegularExpression(@"(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?", ErrorMessage = "URL is not valid")]
        public global::System.String url { get; set; }

        [DisplayName("Comments")]
        public List<comment> comments { get; set; }
    }
}