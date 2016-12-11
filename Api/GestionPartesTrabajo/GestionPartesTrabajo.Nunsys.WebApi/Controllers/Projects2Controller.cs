using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    
    [RoutePrefix("api/Projects2")]
    public class Projects2Controller : ApiController
    {
        // GET: api/Projects1
        public IEnumerable<string> Get()
        {
            return new string[] { "value11", "value22" };
        }

        // GET: api/Projects1/5
        public string Get(int id)
        {
             return "value";
        }

        // POST: api/Projects1
        public void Post([FromBody]string value)
        {
            try
            {
                Ok();
            }
            catch (Exception ex)
            {
               this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/Projects1/5
        public void Put(int id, [FromBody]string value)
        {
            try
            {
                Ok();
            }
            catch (Exception ex)
            {
                this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // DELETE: api/Projects1/5
        public void Delete(int id)
        {
            try
            {
                Ok();
            }
            catch (Exception ex)
            {
               this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
