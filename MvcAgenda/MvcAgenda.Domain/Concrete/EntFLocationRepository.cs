using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using System.Data.Objects;

namespace MvcAgenda.Domain.Concrete
{
    public class EntFLocationRepository : ILocationRepository
    {
        private EntFWDBContext context = new EntFWDBContext();

        public IQueryable<MvcAgenda.Domain.Entities.location> locations
        {
            get
            {
                return context.location;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        //public void DeleteObject(object location)
        //{
        //    context.locations.DeleteObject((MvcAgenda.Domain.location)location);
        //}

        //public void AddObject(object location)
        //{
        //    context.locations.AddObject((MvcAgenda.Domain.location)location);
        //}

        //public void Attach(object location)
        //{
        //    context.locations.Attach((MvcAgenda.Domain.location)location);
        //}

        //public ObjectStateManager ObjectStateManager()
       // {
       //     return context.ObjectStateManager;
       // }
    }
}

