using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MvcAgenda.Domain.Abstract;

namespace MvcAgenda.Infrastructure.Concrete
{
    public class CustomMembershipProvider//: MembershipProvider
    {
        //private IUserRepository repository;
        //public CustomMembershipProvider(IUserRepository repository)
        //{
        //     this.repository = repository;

        //}
        //public override bool ValidateUser(string username, string password)
        //{
        //    return this.repository.Users.ToList().Exists(m=>m.username == username && m.password == password);
        //}
    }
}