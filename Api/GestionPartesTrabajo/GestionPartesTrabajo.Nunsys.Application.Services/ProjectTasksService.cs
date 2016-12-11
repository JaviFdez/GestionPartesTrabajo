using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Domain;
using AutoMapper;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public class ProjectTasksService : IProjectTasksService
    {
        private IProjectTasksRepository _projectTasksRepository;

        public ProjectTasksService(IProjectTasksRepository projectTasksRepository)
        {
            this._projectTasksRepository = projectTasksRepository;
        }
        public int countProjectTasks()
        {
            int countTasks = this._projectTasksRepository.countProjectTask();
            return countTasks;
        }

        public ProjectTaskDtoAmp deleterProjectTask(int id)
        {
            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTaskDtoAmp, ProjectTasks>()).CreateMapper();
            ProjectTaskDtoAmp projectTaskDto = null;
            ProjectTasks projectTaskEdm = _projectTasksRepository.GetFirstElementFiltered(item => item.Id == id);
            if (projectTaskEdm != null)
            {
                _projectTasksRepository.Remove(projectTaskEdm);
            }

            projectTaskEdm = configDtoToEdm.Map<ProjectTasks>(projectTaskDto);

            _projectTasksRepository.UnitOfWork.Commit();
            return projectTaskDto;
        }

        public IList<ProjectTaskDtoAmp> getPageProjectsTasks(FiltrosProjectTasksModel filtros, int sizePage, int actualPage)
        {
            IList<ProjectTaskDtoAmp> resultado = this._projectTasksRepository.getPageProjectTasks(filtros, sizePage, actualPage);

            return resultado;
        }

        public ProjectTaskDto getProjectTask(int id)
        {
            ProjectTaskDto projectTask = null;
            ProjectTasks projectTaskEdm = _projectTasksRepository.GetFirstElementFiltered(item => item.Id == id);
            if(projectTaskEdm != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTasks, ProjectTaskDto>()).CreateMapper();
                projectTask = config.Map<ProjectTaskDto>(projectTaskEdm);
            }

            return projectTask;
        }

        public IList<ProjectTaskDtoAmp> getProjectTasks()
        {
            IList<ProjectTaskDtoAmp> resultado = new List<ProjectTaskDtoAmp>();
            IList<ProjectTasks> projectTasks = _projectTasksRepository.GetAll();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTasks, ProjectTaskDtoAmp>()).CreateMapper();

            foreach (ProjectTasks projectTask in projectTasks)
            {


                resultado.Add(config.Map<ProjectTaskDtoAmp>(projectTask));
            }


            resultado = config.Map<IList<ProjectTaskDtoAmp>>(resultado);



            return resultado;
        }

        public IList<ProjectTaskDtoAmp> getProjectTasksByNameProject(string nombre)
        {
            IList<ProjectTaskDtoAmp> resultado = _projectTasksRepository.getProjectTasksByNameProject(nombre);
            return resultado;
        }

        public ProjectTaskDto saveProjectTask(ProjectTaskDto projectTask)
        {
            bool isNew = projectTask.Id == null;
            ProjectTasks projectTasksEdm = null;

            var configDtoToEdm = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTaskDto, ProjectTasks>()).CreateMapper();
            var configEdmToDto = new MapperConfiguration(cfg => cfg.CreateMap<ProjectTasks, ProjectTaskDto>()).CreateMapper();



            if (isNew)
            {

                projectTasksEdm = configDtoToEdm.Map<ProjectTasks>(projectTask);
                this._projectTasksRepository.Add(projectTasksEdm);
            }
            else
            {

                // opcion 1
                projectTasksEdm = _projectTasksRepository.GetFirstElementFiltered(item => item.Id == projectTask.Id);
                projectTasksEdm.TaskCode = projectTask.TaskCode;
                projectTasksEdm.Description = projectTask.Description;
                projectTasksEdm.IdProyect = projectTask.IdProyect;

                /*
                //opcion 3
                 customerEdm = Mapper.Map<Customers>(customer);
                */


            }
            this._projectTasksRepository.UnitOfWork.Commit();
            projectTask = configEdmToDto.Map<ProjectTaskDto>(projectTasksEdm);
            return projectTask;
        }
    }
}
