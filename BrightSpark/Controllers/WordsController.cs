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

        // GET: v1/words/id/true
        public Dictionary<int, string> GetWords(string sort, bool unique)
        {
            Dictionary<int, string> result = new Dictionary<int, string>(); ;
            try
            {
                Words w = new Words();
                result = w.GetWords(sort, unique);
            }
            catch (Exception)
            {
                HttpResponseMessage response =
                    this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unspecified error.");
                throw new HttpResponseException(response);
            }

            return result;
        }


        // GET: api/Words/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Words
        public Dictionary<int, string> Post([FromBody]string[] value)
        {
            if (value == null)
            {
                HttpResponseMessage response =
                                  this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unspecified error.");
                throw new HttpResponseException(response);
            }


            Words w = new Words();
            return w.AddWords(value); 

        }

        // PUT: api/Words/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Words/5
        public HttpResponseMessage Delete()
        {
            Words w = new Words();
            HttpResponseMessage response;
            if (w.DeleteAllWords() == "ok")
            {
                response =
                    this.Request.CreateResponse(HttpStatusCode.OK, "All words are succesfuly deleted.");
            }
            else
            {
                response =
                    this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unexpected error."); //It is not really a bad request but the swagger suggest code 400 
            }


            return response;


        }
    }
}
