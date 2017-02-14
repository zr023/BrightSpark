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
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/Words
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: v1/words/id/true
        public Dictionary<int, string> GetWords(string sort, bool unique)
        {
            // Log request
            log.Debug("GetWords - Requested sort value is: " + sort);
            log.Debug("GetWords - Requested unique value is: " + unique.ToString());

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
                log.Fatal(response.ToString());
                throw new HttpResponseException(response);
            }

            // Log response
            foreach (KeyValuePair<int, string> entry in result)
            {
                log.Debug("Response is the words requested: " + entry.ToString());
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
            // Log request
            foreach (string s in value)
            {
                log.Debug("Post -Requested value is: " + s);
            }

            Words w = new Words();
            Dictionary<int, string> rsp = w.AddWords(value);

            if (value == null || rsp == null)
            {
                HttpResponseMessage response =
                                  this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unspecified error.");
                log.Fatal(response.ToString());
                throw new HttpResponseException(response);
            }

            // Log response
            foreach (KeyValuePair<int, string> entry in rsp)
            {
                log.Debug("Post - Response is the words requested: " + entry.ToString());
            }

            return rsp;

        }

        // PUT: api/Words/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Words/5
        public HttpResponseMessage Delete()
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Words w = new Words();
                if (w.DeleteAllWords() == "ok")
                {
                    response =
                        this.Request.CreateResponse(HttpStatusCode.OK, "All words are succesfuly deleted.");
                }
                else
                {
                    response =
                        this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unexpected error."); //It is not really a bad request but the swagger suggests code 400 
                }
            }
            catch (Exception)
            {
                //response = this.Request.CreateResponse(HttpStatusCode.BadRequest, "Unspecified error.");
                log.Fatal(response.ToString());
                //throw new HttpResponseException(response);
            }

            log.Debug("Delete words: " + response.ToString());
            return response;


        }
    }
}
