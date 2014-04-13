using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAgenda.Infrastructure.Abstract;
using System.Web.Security;
using MvcAgenda.Domain.Abstract;

namespace MvcAgenda.Infrastructure.Concrete
{
    public class FormsAuthProvider: IAuthProvider
    {
        private IUserRepository repository;
        public FormsAuthProvider(IUserRepository repository)
        {
             this.repository = repository;

        }

        public bool Authenticate(string username, string password, bool rememberme)
        {
            bool result = ValidateUser(username, password); //FormsAuthentication.Authenticate(username, password); //Membership.ValidateUser(username, password);
            if (result) {
                FormsAuthentication.SetAuthCookie(username, rememberme);
            }
            return result;
        }

        private bool ValidateUser(string username, string password)
        {
            return this.repository.Users.ToList().Exists(m => m.username == username && m.password == password);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public void CreateUserAndAccount(Domain.Entities.user user)
        {
            this.repository.SaveUser(user);
        }
    }
}