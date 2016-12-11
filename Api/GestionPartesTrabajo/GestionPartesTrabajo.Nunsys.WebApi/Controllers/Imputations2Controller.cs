using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [RoutePrefix("api/Imputations2")]
    public class Imputations2Controller : ApiController
    {
        private IImputations2Service _imputationsService;

        public Imputations2Controller(IImputations2Service imputationsService)
        {
            this._imputationsService = imputationsService;
        }

        // GET: api/Imputations2
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_imputationsService.getImputations());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // GET: api/Imputations2/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_imputationsService.getImputation(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // POST: api/Imputations2
        public IHttpActionResult Post([FromBody]ImputationDto imputation)
        {
            try
            {
                return Ok(_imputationsService.saveImputation(imputation));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/Imputations2/5
        /*public IHttpActionResult Put(int id, [FromBody]ImputationDto imputation)
        {
            try
            {
                return Ok(_imputationsService.saveImputation(imputation));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }*/

        // DELETE: api/Imputations2/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_imputationsService.deleteImputation(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
