using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;

namespace MvcAgenda.Domain.Entities
{
  [MetadataType(typeof(eventMetaData))]
    public partial class aevent
    {
        public global::System.Int32 id { get; set; }
        public global::System.String title { get; set; }

        public global::System.String description { get; set; }

        public global::System.Int32 user_id { get; set; }

        public global::System.Int32 location_id { get; set; }

        public global::System.DateTime startTime { get; set; }

        public Nullable<global::System.DateTime> endTime { get; set; }

        public global::System.String url { get; set; }

        public user user { get; set; }

        public location location { get; set; }

        public List<comment> comments { get; set; }
        public void CopyFrom(aevent aevent)
        {
            title = aevent.title;
            description = aevent.description;
            user_id = aevent.user_id;
            location_id = aevent.location_id;
            startTime = aevent.startTime;
            endTime = aevent.endTime;
            url = aevent.url;
        }
    }
    public class eventMetaData
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title can't be empty")]
        [StringLength(50, ErrorMessage = "Max 50 char")]
        public global::System.String title { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "Max 200 char")]
        public global::System.String description { get; set; }

         [DisplayName("User")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a user")]
        public global::System.Int32 user_id { get; set; }

         [DisplayName("Location")]
         [UIHint("LocationAutocomplete")]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a location")]
        public global::System.Int32 location_id { get; set; }

        [DisplayName("Starting")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Start Time can't be empty")]
        [FutureDate(ErrorMessage = "Start Time must be a date in the future")]
        public global::System.DateTime startTime { get; set; }

        [DisplayName("Ending")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "End Time must be a date in the future")]
        public Nullable<global::System.DateTime> endTime { get; set; }

        [DisplayName("URL")]
        [UIHint("Url")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "URL can't be empty")]
        [StringLength(200, ErrorMessage = "Max 200 char")]
        [RegularExpression(@"(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?", ErrorMessage = "URL is not valid")]
        public global::System.String url { get; set; }

        [DisplayName("Comments")]
        public EntityCollection<comment> comments { get; set; }
    }
}
