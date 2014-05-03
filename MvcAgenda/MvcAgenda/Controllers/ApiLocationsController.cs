using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcAgenda.Domain.Abstract;

namespace MvcAgenda.Controllers
{
    public class ApiLocationsController : ApiController
    {
        private ILocationRepository repository;
        public ApiLocationsController(ILocationRepository repository)
        {
            this.repository = repository;       
        }
        // GET api/apilocations
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/apilocations/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/apilocations
        public void Post([FromBody]string value)
        {
        }

        // PUT api/apilocations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/apilocations/5
        public void Delete(int id)
        {
        }
    }
}
