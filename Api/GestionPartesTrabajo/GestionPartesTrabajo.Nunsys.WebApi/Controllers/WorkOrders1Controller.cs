using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/WorkOrders1")]
    public class WorkOrders1Controller : ApiController
    {

        private IWorkOrdersService _workOrderService;

        public WorkOrders1Controller(IWorkOrdersService workOrderService)
        {
            this._workOrderService = workOrderService;
        }

        [Route("WorkOrderPage")]
        [HttpPost]
        public IHttpActionResult WorkOrderPage(FiltrosWorkOrdersModel filtros, int sizePage, int actualPage)
        {
            try
            {
                return Ok(_workOrderService.getPageWorkOrders(filtros, sizePage, actualPage));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // GET: api/WorkOrders
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_workOrderService.getWorkOrders());
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
                return Ok(_workOrderService.getWorkOrder(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpGet]
        [Route("countWorkOrders")]
        public IHttpActionResult countWorkOrders()
        {
            try
            {
                //return Ok("value");
                return Ok(_workOrderService.countWorkOrders());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpPost]
        [Route("saveWorkOrder")]
        // POST: api/WorkOrders
        public IHttpActionResult Post(WorkOrderDtoAmp workOrder)
        {
            try
            {
                return Ok(_workOrderService.saveWorkOrder(workOrder));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/WorkOrders/5
        public IHttpActionResult Put(WorkOrderDtoAmp workOrder)
        {
            try
            {
                return Ok(_workOrderService.saveWorkOrder(workOrder));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpDelete]
        [Route("removeWorkOrder")]
        // DELETE: api/WorkOrders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Ok(_workOrderService.deleterWorkOrder(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
