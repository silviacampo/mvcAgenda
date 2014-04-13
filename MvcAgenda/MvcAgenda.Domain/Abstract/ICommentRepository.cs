using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Domain.Abstract
{
    //not needed, treat in the event aggregate
    public interface ICommentRepository
    {
        IQueryable<MvcAgenda.Domain.Entities.comment> Comments { get; }

    }
}
