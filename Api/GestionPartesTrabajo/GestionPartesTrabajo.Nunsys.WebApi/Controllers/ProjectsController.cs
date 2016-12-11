using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    public class ProjectsController : ApiController
    {
        // GET: api/Projects
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

        // GET: api/Projects/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok("Get!");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // POST: api/Projects
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

        // PUT: api/Projects/5
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

        // DELETE: api/Projects/5
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
