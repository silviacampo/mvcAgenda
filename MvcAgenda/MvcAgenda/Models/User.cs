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

/// <summary>
/// Summary description for UserCustom
/// </summary>
/// 
namespace MvcAgenda
{
    [MetadataType(typeof(userMetaData))]
    //public partial class user
   // {
   //     private agendaEntities db = new agendaEntities();

  // }
    public class userMetaData
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name can't be empty")]
        [Remote("IsUsernameAvailable", "Users")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String username { get; set; }
        
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password can't be empty")]
        [StringLength(20, ErrorMessage = "Max 20 char")]
        public global::System.String password { get; set; }
        
        [DisplayName("Email")]
        [Required(ErrorMessage = "E-mail can't be empty")]
        [Remote("IsEmailAvailable", "Users")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(100, ErrorMessage = "Max 100 char")]
        public global::System.String email { get; set; }

        
        [DisplayName("Friends")]
        public EntityCollection<friend> friends { get; set; }
    }
}