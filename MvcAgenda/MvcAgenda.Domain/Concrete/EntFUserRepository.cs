using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using System.Data;

namespace MvcAgenda.Domain.Concrete
{
    public class EntFUserRepository : IUserRepository
    {
        private EntFWDBContext context = new EntFWDBContext();

        public IQueryable<user> Users
        {
            get
            {
                return context.user;
            }
        }

        public void SaveUser(user user) {
            if (user.id == 0)
            {
                context.user.Add(user);
            }
            else
            {
                context.user.Find(user.id).CopyFrom(user);
            }
            context.SaveChanges();
        }

        public void DeleteUser(user user) {
            context.user.Remove(user);
            context.SaveChanges();
        }

        public void AddUser(user user)
        {
            context.user.Add(user);
        }

        public user FindUser(int user_id)
        {
            return context.user.Single(u => u.id == user_id);
        }

        public IEnumerable<user> ListUsers(int pageSize, int pageIndex)
        {
            return context.user.OrderBy(u => u.username).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public void SubmitChanges()
        {
            context.SaveChanges();
        }
    }
}