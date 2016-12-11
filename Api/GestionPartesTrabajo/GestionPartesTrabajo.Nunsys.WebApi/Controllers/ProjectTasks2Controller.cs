using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/ProjectTasks2")]
    public class ProjectTasks2Controller : ApiController
    {
        // GET: api/ProjectTasks
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

        // GET: api/ProjectTasks/5
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

        // POST: api/ProjectTasks
        public IHttpActionResult Post([FromBody]string value)
        {
            try
            {
                return Ok("Post!");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // PUT: api/ProjectTasks/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok("Put!");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // DELETE: api/ProjectTasks/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok("Delete!");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }
    }
}
