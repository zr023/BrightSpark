using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrightSpark.Models;

namespace BrightSpark.Controllers
{
    public class WordsController : ApiController
    {
        // GET: api/Words
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Words/id/true
        public IEnumerable<string> GetWords(string sort, bool unique)
        {
            Words w = new Words();
            var result = w.GetWords(sort, unique);
            return result.Values;
        }


        // GET: api/Words/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Words
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Words/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Words/5
        public void Delete(int id)
        {
        }
    }
}
