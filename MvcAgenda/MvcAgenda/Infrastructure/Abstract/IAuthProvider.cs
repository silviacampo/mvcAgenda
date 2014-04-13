using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcAgenda.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, bool rememberme);

        void Logout();

        void CreateUserAndAccount(Domain.Entities.user user);
    }
}
