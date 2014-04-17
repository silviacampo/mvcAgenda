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

        public IQueryable<MvcAgenda.Domain.Entities.location> Locations
        {
            get
            {
                return context.location;
            }
        }

        public void SaveLocation(location location)
        {
            if (location.id == 0)
            {
                context.location.Add(location);
            }
            else
            {
                context.location.Find(location.id).CopyFrom(location);
            }
            context.SaveChanges();
        }

        public void DeleteLocation(location location)
        {
            context.location.Remove(location);
            context.SaveChanges();
        }
    }
}

