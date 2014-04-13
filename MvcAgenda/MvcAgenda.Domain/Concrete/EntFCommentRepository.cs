using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Domain.Concrete
{
    public class EntFCommentRepository : ICommentRepository
    {
        private EntFWDBContext context = new EntFWDBContext();

        public IQueryable<MvcAgenda.Domain.Entities.comment> Comments
        {
            get
            {
                return context.comment;
            }
        }
    }
}