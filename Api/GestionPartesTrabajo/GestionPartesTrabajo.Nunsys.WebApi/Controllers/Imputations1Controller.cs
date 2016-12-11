using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Data.Repository;
using GestionPartesTrabajo.Nunsys.Application.Services;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;

using GestionPartesTrabajo.Nunsys.Data.Interfaces;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [RoutePrefix("api/Imputations1")]
    public class Imputations1Controller : ApiController
    {

        IImputations1Service imputationsService;

        public Imputations1Controller(IImputations1Service imputationsService)
        {
            this.imputationsService = imputationsService;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/Imputations1
        public IHttpActionResult Get()
        {
            try
            {
                return Ok("Get con todo");

            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }


        }

        // GET: api/Imputations1/5
        //public IHttpActionResult Get(ImputationDto imputation)
        //{
        //    try
        //    {

        //        return Ok(HttpStatusCode.Created);

        //    }
        //    catch (Exception ex)
        //    {
        //        return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
        //    }
        //}

        // POST: api/Imputations1
        public IHttpActionResult Post(ImputationDto imputation)
        {
            try
            {
        //      imputationsService.saveImputation(imputation);
                return Ok(HttpStatusCode.Created);

            }

            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }

        }

        // PUT: api/Imputations1/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            try
            {
                return Ok("Modificado con Id:" + id + " y valor:" + value);

            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        // DELETE: api/Imputations1/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok("Borrado con id:" + id);

            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }
    }
}
