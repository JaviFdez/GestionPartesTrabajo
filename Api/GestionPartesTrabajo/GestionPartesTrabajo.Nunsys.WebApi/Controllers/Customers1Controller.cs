using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Application.Services;
using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.IT.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionPartesTrabajo.Nunsys.WebApi.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [RoutePrefix("api/Customers1")]
    public class Customers1Controller : ApiController
    {
        private ICustomers1Service _customerService;

        public Customers1Controller(ICustomers1Service customerService)
        {
            this._customerService = customerService;
        }
        // GET: api/Customers
       
        [Route("getCustomerPage")]
        [HttpGet]
        public IHttpActionResult GetCustomerPage(int sizePage, int actualPage)
        {
            try
            {
                return Ok(_customerService.getCustomers(sizePage, actualPage));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_customerService.getCustomers());
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // GET: api/Customers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                //return Ok("value");
                return Ok(_customerService.getCustomer(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
        [HttpGet]
        [Route("countCustomers")]
        public IHttpActionResult countCustomers()
        {
            try
            {
                //return Ok("value");
                return Ok(_customerService.countCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // POST: api/Customers
        public IHttpActionResult Post(CustomerDto customer)
        {
            try
            {
                customer.Id = null;
                CustomerDto result = _customerService.saveCustomer(customer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/Customers
        public IHttpActionResult Put(CustomerDto customer)
        {
            try
            {
                CustomerDto result = _customerService.saveCustomer(customer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }


        // DELETE: api/Customers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //return Ok();
                return Ok(_customerService.deleterCustomer(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
