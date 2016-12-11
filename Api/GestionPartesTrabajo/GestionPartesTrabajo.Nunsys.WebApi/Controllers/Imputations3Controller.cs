using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [RoutePrefix("api/Imputations3")]
    public class Imputations3Controller : ApiController
    {
        // GET: api/Imputations
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new String[] { "value1", "value2" });
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // GET: api/Imputations/5
        public IHttpActionResult Get(int id)
        {
            //return "value";
            try
            {
                return Ok(new String[] { "value1", "value2" });
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // POST: api/Imputations
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // PUT: api/Imputations/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // DELETE: api/Imputations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }
    }
}
