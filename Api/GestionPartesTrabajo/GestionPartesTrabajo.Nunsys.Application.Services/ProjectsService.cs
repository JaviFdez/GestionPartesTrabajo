using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using AutoMapper;
using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private IProyectsRepository _projectsRepository;

        public ProjectsService(IProyectsRepository projectRepository)
        {
            this._projectsRepository = projectRepository;
        }

        public int countProjects()
        {
            int countProjects = _projectsRepository.countProjects();
            return countProjects;
        }

       /* public ICollection<ProjectTasks> getProjectTask(int id)
        {
            ICollection<ProjectTasks> result = new List<ProjectTasks>();

            Projects project = _projectsRepository.GetFirstElementFiltered(item => item.Id == id);
            
            return result = project.ProjectTasks;
        }*/

        public ProjectDtoAmp deleterProject(int id)
        {
            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDtoAmp, Projects>()).CreateMapper();
            ProjectDtoAmp projectDto = null;
            Projects projectEdm = _projectsRepository.GetFirstElementFiltered(item => item.Id == id);
            if (projectEdm != null && projectEdm.ProjectTasks.Count == 0)
            { 
                _projectsRepository.Remove(projectEdm);
            }

            projectEdm = configDtoToEdm.Map<Projects>(projectDto);

            _projectsRepository.UnitOfWork.Commit();
            return projectDto;
        }

        public IList<ProjectDtoAmp> getProjects()
        {
            IList<ProjectDtoAmp> resultado = new List<ProjectDtoAmp>();
            IList<Projects> projects = _projectsRepository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Projects, ProjectDtoAmp>()).CreateMapper();

            foreach (Projects project in projects)
            {


                resultado.Add(config.Map<ProjectDtoAmp>(project));
            }


            resultado = config.Map<IList<ProjectDtoAmp>>(resultado);



            return resultado;
        }

        public ProjectDto getProject(int id)
        {
            ProjectDto project = null;
            Projects projectEdm = _projectsRepository.GetFirstElementFiltered(item => item.Id == id);
            if (projectEdm != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Projects, ProjectDto>()).CreateMapper();
                project = config.Map<ProjectDto>(projectEdm); //mapear un objeto en otro
            }


            return project;
        }

        public IList<ProjectDtoAmp> getPageProjects(FiltrosProjectsModel filtros, int sizePage, int actualPage)
        {
            IList<ProjectDtoAmp> resultado = _projectsRepository.getPageProjects(filtros, sizePage, actualPage);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Projects, ProjectDtoAmp>()).CreateMapper();

            return resultado;
        }


        public ProjectDto saveProject(ProjectDto project)
        {
            bool isNew = project.Id == null;
            Projects projectEdm = null;

            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDto, Projects>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<Projects, ProjectDto>()).CreateMapper();



            if (isNew)
            {

                projectEdm = configDtoToEdm.Map<Projects>(project);
                this._projectsRepository.Add(projectEdm);
            }
            else
            {

                // opcion 1
                projectEdm = _projectsRepository.GetFirstElementFiltered(item => item.Id == project.Id);
                projectEdm.ProjectCode = project.ProjectCode;
                projectEdm.Description = project.Description;
                projectEdm.IdCustomer = project.IdCustomer;

                /*
                //opcion 3
                 customerEdm = Mapper.Map<Customers>(customer);
                */


            }
            this._projectsRepository.UnitOfWork.Commit();
            project = configEdmToDto.Map<ProjectDto>(projectEdm);
            return project;

        }

    }
}
