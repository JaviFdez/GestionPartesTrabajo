using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{

   
    [RoutePrefix("/api/Users1")]
    public class Users1Controller : ApiController
    {

        private IUsers1Service _usersService;

        public Users1Controller(IUsers1Service usersService)
        {
            this._usersService = usersService;
        }

        /// <summary>
        /// GET: api/Users
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(this._usersService.getUsers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
                
            }
            
        }

        // GET: api/User/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok("Get");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // POST: api/User
        public IHttpActionResult Post(UserDto user)
        {
            try
            {
                return Ok(this._usersService.saveUser(user));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok("put");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok("deleted");
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
