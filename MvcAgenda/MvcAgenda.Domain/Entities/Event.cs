using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.Web.Mvc;
using MvcAgenda.Resources;

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
        [Display(Name = "eventTitle" , ResourceType = typeof(Events))]
        [Required(ErrorMessageResourceName = "eventTitleRequiredMsg", ErrorMessageResourceType = typeof(Events))]
        [StringLength(50, ErrorMessageResourceName = "eventTitleMaxLengthMsg", ErrorMessageResourceType = typeof(Events))]
        public global::System.String title { get; set; }

        [Display(Name = "eventDescription", ResourceType = typeof(Events))]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessageResourceName = "eventDescriptionMaxLengthMsg", ErrorMessageResourceType = typeof(Events))]
        public global::System.String description { get; set; }

         [Display(Name = "eventUser", ResourceType = typeof(Events))]
         [Range(1, int.MaxValue, ErrorMessageResourceName = "eventUserRange", ErrorMessageResourceType = typeof(Events))]
        public global::System.Int32 user_id { get; set; }

         [Display(Name = "eventLocation", ResourceType = typeof(Events))]
         [UIHint("LocationAutocomplete")]
         [Range(1, int.MaxValue, ErrorMessageResourceName = "eventLocationRange", ErrorMessageResourceType = typeof(Events))]
        public global::System.Int32 location_id { get; set; }

        [Display(Name = "eventStartTime", ResourceType = typeof(Events))]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceName = "eventStartTimeRequiredMsg", ErrorMessageResourceType = typeof(Events))]
        [Remote("IsStartDateValid", "Events", AdditionalFields = "endTime, id")]
        //[FutureDate(ErrorMessage = Events.eventStartTimeFutureDateMsg)]
        public global::System.DateTime startTime { get; set; }

        [Display(Name = "eventEndTime", ResourceType = typeof(Events))]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Remote("IsEndDateValid", "Events", AdditionalFields = "startTime, id")]
        //[FutureDate(ErrorMessage = Events.eventEndTimeFutureDateMsg)]
        public Nullable<global::System.DateTime> endTime { get; set; }

        [Display(Name = "eventUrl", ResourceType = typeof(Events))]
        [UIHint("Url")]
        //[Required(AllowEmptyStrings = true, ErrorMessageResourceName = "eventUrlRequiredMsg", ErrorMessageResourceType = typeof(Events))]
        [StringLength(200, ErrorMessageResourceName = "eventUrlMaxLengthMsg", ErrorMessageResourceType = typeof(Events))]
        [RegularExpression(@"(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?", ErrorMessageResourceName = "eventUrlInvalidMsg", ErrorMessageResourceType = typeof(Events))]
        public global::System.String url { get; set; }

        [Display(Name = "eventComments", ResourceType = typeof(Events))]
        public EntityCollection<comment> comments { get; set; }
    }
}
