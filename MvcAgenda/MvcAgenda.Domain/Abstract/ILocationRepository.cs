using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Entities;
using System.Data.Objects;

namespace MvcAgenda.Domain.Abstract
{
    public interface ILocationRepository
    {
        IQueryable<MvcAgenda.Domain.Entities.location> locations { get; }

        //void Dispose();

        //void SaveChanges();

        //void DeleteObject(object location);

        //void AddObject(object location);

        //void Attach(object location);

        //ObjectStateManager ObjectStateManager();
    }
}