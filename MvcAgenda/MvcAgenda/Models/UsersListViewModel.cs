using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<user> Users {get; set;}
        public PagingInfo PagingInfo {get; set;}
    }
}