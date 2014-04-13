using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<user> Users { get; }
        void SaveUser(user user);
        void DeleteUser(user user);

        void AddUser(MvcAgenda.Domain.Entities.user user);
        MvcAgenda.Domain.Entities.user FindUser(int user_id);
        IEnumerable<MvcAgenda.Domain.Entities.user> ListUsers(int pageSize, int pageIndex);
        void SubmitChanges();
    }
}