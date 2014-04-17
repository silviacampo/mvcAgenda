using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        public List<comment> comments { get; set; }
        public List<friend> friends1 { get; set; }
        //[UIHint("Enum")]
        [AdditionalMetadata("RemderList", "true")] //viewData.modelmetadata.additionalvalues.containskey("renderlist")
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

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name can't be empty")]
        //[Remote("IsUsernameAvailable", "Users")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String password { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "E-mail can't be empty")]
        // [Remote("IsEmailAvailable", "Users")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(100, ErrorMessage = "Max 100 char")]
        public global::System.String email { get; set; }


        [DisplayName("Friends")]
        public List<friend> friends { get; set; }

        public bool isAdmin { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Guest
    }
}
