using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Domain.Abstract
{
    public interface IEventRepository
    {
        IQueryable<aevent> Events { get; }
    }
}
