using GestionPartesTrabajo.Nunsys.Domain;
using NunsysCore.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;

namespace GestionPartesTrabajo.Nunsys.Data.Interfaces
{
    public interface  IProjectTasksRepository : IRepository<ProjectTasks>
    {
        IList<ProjectTaskDtoAmp> getProjectTasksByNameProject(string nombre);
        IList<ProjectTaskDtoAmp> getPageProjectTasks(FiltrosProjectTasksModel filtros, int sizePage, int actualPage);
        int countProjectTask();
    }
}
