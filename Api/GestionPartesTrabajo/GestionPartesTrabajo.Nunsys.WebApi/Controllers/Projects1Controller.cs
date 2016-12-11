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
    [RoutePrefix("api/Projects1")]
    public class Projects1Controller : ApiController
    {
        private IProjectsService _projectsService;

        public Projects1Controller(IProjectsService projectsService)
        {
            this._projectsService = projectsService;
        }

        [Route("ProjectPage")]
        [HttpPost]
        public IHttpActionResult PageProject(FiltrosProjectsModel filtros, int sizePage, int actualPage)
        {
            try
            {
                return Ok(_projectsService.getPageProjects(filtros, sizePage, actualPage));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // GET: api/Projects1/5
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_projectsService.getProjects());
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_projectsService.getProject(id));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpGet]
        [Route("countProjects")]
        public IHttpActionResult countProjects()
        {
            try
            {
                //return Ok("value");
                return Ok(_projectsService.countProjects());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpPost]
        [Route("saveProject")]
        public IHttpActionResult Post(ProjectDto project)
        {
            try
            {
                ProjectDto result = _projectsService.saveProject(project);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/Projects1/5
        public IHttpActionResult Put(ProjectDto project)
        {
            try
            {
                ProjectDto result = _projectsService.saveProject(project);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
        
        [HttpDelete]
        [Route("removeProject")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //return Ok();
                return Ok(_projectsService.deleterProject(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
