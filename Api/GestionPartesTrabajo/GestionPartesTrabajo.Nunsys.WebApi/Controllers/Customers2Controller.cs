using GestionPartesTrabajo.Nunsys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [RoutePrefix("api/Customers2")]
    public class Customers2Controller : ApiController
    {
        // GET: api/Customers2
        public IHttpActionResult Get()
        {
            try
            {
                
                return Ok();
            }
            catch(Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // GET: api/Customers2/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok("pepo");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // POST: api/Customers2
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // PUT: api/Customers2/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // DELETE: api/Customers2/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }
    }
}
