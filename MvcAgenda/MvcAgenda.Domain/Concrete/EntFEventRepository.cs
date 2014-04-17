using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Domain.Concrete
{
    public class EntFEventRepository: IEventRepository
    {
        private EntFWDBContext context = new EntFWDBContext();

        public IQueryable<MvcAgenda.Domain.Entities.aevent> Events
        {
            get {
                return context.aevent;
            }
        }
        public void SaveEvent(aevent aevent)
        {
            if (aevent.id == 0)
            {
                context.aevent.Add(aevent);
            }
            else
            {
                context.aevent.Find(aevent.id).CopyFrom(aevent);
            }
            context.SaveChanges();
        }

        public void DeleteEvent(aevent aevent)
        {
            context.aevent.Remove(aevent);
            context.SaveChanges();
        }
    }
}
