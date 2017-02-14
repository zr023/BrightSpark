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
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        // GET: api/Fibonacci
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/Fibonacci/5
        [Route("v1/Fibonacci/{n}")]
        public FibonacciStruct GetFibonacci(uint n)
        {
            log.Debug("GetFibonacci - Requested value is: "+ n.ToString());

            Fibonacci f = new Fibonacci();
            FibonacciStruct fbResult = new FibonacciStruct();
            try
            {
                fbResult = f.GetNthFibonacciNumberIterative(n);
            }
            catch (Exception)
            {

                HttpResponseMessage response =
                    this.Request.CreateResponse(HttpStatusCode.InternalServerError, "Unspecified error.");
                log.Fatal(response.ToString());
                throw new HttpResponseException(response);

            }

            log.Debug("GetFibonacci - Response is the value requested: " + fbResult.numberRequested.ToString());
            log.Debug("GetFibonacci - Response is nth value in sequence: " + fbResult.nthNumberOfFibonacciSequence.ToString());

            return fbResult;  
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
