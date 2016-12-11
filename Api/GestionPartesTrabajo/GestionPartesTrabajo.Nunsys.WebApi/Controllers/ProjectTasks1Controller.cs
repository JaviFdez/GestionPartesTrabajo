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
    [RoutePrefix("api/ProjectTasks1")]
    public class ProjectTasks1Controller : ApiController
    {

        private IProjectTasksService _projectTaskService;

        public ProjectTasks1Controller(IProjectTasksService projectTaskService)
        {
            this._projectTaskService = projectTaskService;
        }

        [Route("ProjectTasksByName")]
        [HttpGet]
        public IHttpActionResult getProjectTasksByNameProject(string name)
        {
            try
            {
                return Ok(_projectTaskService.getProjectTasksByNameProject(name));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [Route("ProjectPage")]
        [HttpPost]
        public IHttpActionResult PageProject(FiltrosProjectTasksModel filtros, int sizePage, int actualPage)
        {
            try
            {
                return Ok(_projectTaskService.getPageProjectsTasks(filtros, sizePage, actualPage));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // GET: api/ProjectTasks

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_projectTaskService.getProjectTasks());
                //return Ok(_repo.getAllCustomers());
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
                return Ok(_projectTaskService.getProjectTask(id));
                //return Ok(_repo.getAllCustomers());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpPost]
        [Route("saveProjectTask")]
        public IHttpActionResult Post(ProjectTaskDto projectTask)
        {
            try
            {
                ProjectTaskDto result = _projectTaskService.saveProjectTask(projectTask);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpGet]
        [Route("countProjectTasks")]
        public IHttpActionResult countProjects()
        {
            try
            {
                //return Ok("value");
                return Ok(_projectTaskService.countProjectTasks());
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        // PUT: api/ProjectTasks/5
        public IHttpActionResult Put(ProjectTaskDto projectTask)
        {
            try
            {
                ProjectTaskDto result = _projectTaskService.saveProjectTask(projectTask);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }

        [HttpDelete]
        [Route("removeProjectTask")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //return Ok();
                return Ok(_projectTaskService.deleterProjectTask(id));
            }
            catch (Exception ex)
            {
                return this.ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));

            }
        }
    }
}
