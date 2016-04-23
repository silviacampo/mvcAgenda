using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using System.Data.Entity;

namespace MvcAgenda.Domain.Concrete
{
    public class EntFEventRepository: IEventRepository
    {
        private EntFWDBContext context = new EntFWDBContext();

        public IQueryable<MvcAgenda.Domain.Entities.aevent> Events
        {
            get {
                return context.aevent.Include(b => b.location).Include(b => b.user);
            }
        }
        public bool SaveEvent(aevent aevent)
        {
            if (aevent.id == 0)
            {
                context.aevent.Add(aevent);
            }
            else
            {
                context.aevent.Find(aevent.id).CopyFrom(aevent);
            }
            try{
            context.SaveChanges();
            return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteEvent(aevent aevent)
        {
            try
            {
                context.aevent.Remove(aevent);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
