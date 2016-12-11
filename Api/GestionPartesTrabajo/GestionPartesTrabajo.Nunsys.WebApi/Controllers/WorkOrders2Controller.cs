using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    //[Authorize]
    [RoutePrefix("api/WorkOrders2")]
    public class WorkOrders2Controller : ApiController
    {

        // GET: api/WorkOrders
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

        // GET: api/WorkOrders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok("value");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // POST: api/WorkOrders
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

        // PUT: api/WorkOrders/5
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

        // DELETE: api/WorkOrders/5
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
