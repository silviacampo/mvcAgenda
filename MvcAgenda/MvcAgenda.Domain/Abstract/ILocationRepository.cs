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
        IQueryable<location> Locations { get; }

        void SaveLocation(location location);
        void DeleteLocation(location location);
    }
}