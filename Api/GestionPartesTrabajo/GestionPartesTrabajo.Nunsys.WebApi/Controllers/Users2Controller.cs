using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [RoutePrefix("api/Users2")]

    public class Users2Controller : ApiController
    {
       
        // GET: api/Users
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new string[] { "value1", "value2" });
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
                
            }
            
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok("pepe");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok("POST OK");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok("PUT OK");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok("DELETE OK");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
