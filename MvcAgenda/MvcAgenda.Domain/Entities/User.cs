using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MvcAgenda.Resources;

namespace MvcAgenda.Domain.Entities
{
    [MetadataType(typeof(userMetaData))]
    public partial class user
    {
        public global::System.Int32 id { get; set; }

        public global::System.String username { get; set; }

        public global::System.String password { get; set; }

        public global::System.String email { get; set; }

        public List<friend> friends { get; set; }
        public List<aevent> aevents { get; set; }
        public List<location> locations { get; set; }
        public List<comment> comments { get; set; }
        public List<friend> friends1 { get; set; }

        public Role Role { get; set; }

        public bool isAdmin { get; set; }

        public void CopyFrom(user user)
        {
            username = user.username;
            password = user.password;
            email = user.email;
        }
    }
    [Bind(Exclude="isAdmin")]
    public class userMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public global::System.Int32 id { get; set; }

        [Display(Name = "userName", ResourceType = typeof(Users))]
        [Required(ErrorMessageResourceName = "userNameRequiredMsg", ErrorMessageResourceType = typeof(Users))]
        [StringLength(20, ErrorMessageResourceName = "userNameMaxLengthMsg", ErrorMessageResourceType = typeof(Users))]
        [Remote("IsUsernameAvailable", "Users", AdditionalFields="id")]
        public global::System.String username { get; set; }

        [Display(Name = "userPassword", ResourceType = typeof(Users))]
        [Required(ErrorMessageResourceName = "userPasswordRequiredMsg", ErrorMessageResourceType = typeof(Users))]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessageResourceName = "userPasswordMaxLengthMsg", ErrorMessageResourceType = typeof(Users), MinimumLength = 6)]
        public global::System.String password { get; set; }

        [Display(Name = "userEmail", ResourceType = typeof(Users))]
        [Required(ErrorMessageResourceName = "userEmailRequiredMsg", ErrorMessageResourceType = typeof(Users))]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceName = "userEmailRegExMsg", ErrorMessageResourceType = typeof(Users))]
        [StringLength(100, ErrorMessageResourceName = "userEmailMaxLengthMsg", ErrorMessageResourceType = typeof(Users))]
        [Remote("IsEmailAvailable", "Users", AdditionalFields = "id")]
        public global::System.String email { get; set; }


        [Display(Name = "userFriends", ResourceType = typeof(Users))]
        public List<friend> friends { get; set; }
        
        [DisplayName("Is admin?")]
        public bool isAdmin { get; set; }

        //[UIHint("Enum")]
        //viewData.modelmetadata.additionalvalues.containskey("renderlist")
        [AdditionalMetadata("RenderList", "true")]
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }
}
