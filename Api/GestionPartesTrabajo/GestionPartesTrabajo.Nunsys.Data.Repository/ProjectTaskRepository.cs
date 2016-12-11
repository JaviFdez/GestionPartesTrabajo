using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Repository;
using GestionPartesTrabajo.Nunsys.Domain;
using NunsysCore.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using System.Data.Entity;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class ProjectTaskRepository : Repository<ProjectTasks>, IProjectTasksRepository
    {
        public ProjectTaskRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int countProjectTask()
        {
            IDbSet<ProjectTasks> projectTasks = GetSet();

            var query = from projectTask in projectTasks
                        orderby projectTask.TaskCode ascending
                        select new ProjectTaskDtoAmp
                        {
                            Id = projectTask.Id,
                            TaskCode = projectTask.TaskCode,
                            Description = projectTask.Description,
                            IdProyect = projectTask.IdProyect
                        };
            int projectTaskCount = query.ToList().Count();

            return projectTaskCount;
        }

        public IList<ProjectTaskDtoAmp> getPageProjectTasks(FiltrosProjectTasksModel filtros, int sizePage, int actualPage)
        {
            IDbSet<ProjectTasks> projectTasks = GetSet();
            IDbSet<Projects> projects = GetSet<Projects>();
            var query = from projectTask in projectTasks
                        join project in projects on projectTask.IdProyect equals project.Id
                        orderby projectTask.TaskCode ascending
                        select new ProjectTaskDtoAmp
                        {
                            Id = projectTask.Id,
                            TaskCode = projectTask.TaskCode,
                            Description = projectTask.Description,
                            NameProject = project.Description
                        };


            if (filtros.NameProject != null)
            {
                query = query.Where(project => project.NameProject.Equals(filtros.NameProject));
            }

            if (filtros.Descripcion != null)
            {
                query = query.Where(project => project.Description.Equals(filtros.Descripcion));
            }

            if (filtros.TaskCode != null)
            {
                query = query.Where(project => project.TaskCode.Equals(filtros.TaskCode));
            }

            IList<ProjectTaskDtoAmp> projectsList = query.Skip(sizePage * (actualPage))
                                              .Take(sizePage)
                                              .ToList();
            return projectsList;
        }

        public IList<ProjectTaskDtoAmp> getProjectTasksByNameProject(string nombre)
        {
            IDbSet<ProjectTasks> projectTasks = GetSet();
            IDbSet<Projects> projects = GetSet<Projects>();
            var query = from projectTask in projectTasks
                        join project in projects on projectTask.IdProyect equals project.Id
                        where project.Description == nombre
                        orderby projectTask.TaskCode ascending
                        select new ProjectTaskDtoAmp
                        {
                            Id = projectTask.Id,
                            TaskCode = projectTask.TaskCode,
                            Description = projectTask.Description,
                            NameProject = project.Description
                        };

            IList<ProjectTaskDtoAmp> projectTaskList = query.ToList();
            return projectTaskList;

        }
    }
}
