using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAgenda.Domain.Entities;

namespace MvcAgenda.Models
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string Current { get; set; }
    }
}