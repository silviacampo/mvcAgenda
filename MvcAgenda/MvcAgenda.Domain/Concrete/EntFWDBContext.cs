using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using MvcAgenda.Domain.Entities;
using System.Data.Entity.Validation;


namespace MvcAgenda.Domain.Concrete
{
    public class EntFWDBContext: DbContext
    {
        //DbSet<class> table
        public DbSet<MvcAgenda.Domain.Entities.aevent> aevent { get; set; }
        public DbSet<MvcAgenda.Domain.Entities.user> user { get; set; }
        public DbSet<MvcAgenda.Domain.Entities.location> location { get; set; }
        public DbSet<MvcAgenda.Domain.Entities.comment> comment { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //if (DEBUG) {
                    var newException = new FormattedDbEntityValidationException(e);
                    throw newException;
                //}

            }
        }
    }
}
