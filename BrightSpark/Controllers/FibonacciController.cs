using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrightSpark.Models;

namespace BrightSpark.Controllers
{
    public class FibonacciController : ApiController
    {
        // GET: api/Fibonacci
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Fibonacci/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fibonacci
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Fibonacci/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fibonacci/5
        public void Delete(int id)
        {
        }
    }
}
