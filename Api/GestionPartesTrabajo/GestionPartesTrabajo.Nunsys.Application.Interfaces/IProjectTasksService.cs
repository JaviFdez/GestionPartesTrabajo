using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IProjectTasksService
    {
        /// <summary>
        /// Devuelve una tarea
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ProjectTaskDto getProjectTask(int id);

        IList<ProjectTaskDtoAmp> getProjectTasks();

        IList<ProjectTaskDtoAmp> getProjectTasksByNameProject(string nombre);

        IList<ProjectTaskDtoAmp> getPageProjectsTasks(FiltrosProjectTasksModel filtros, int sizePage, int actualPage);

        int countProjectTasks();

        /// <summary>
        /// Creo o modifica una tarea
        /// </summaryproyecto
        /// <param name="tareas">objeto con la tarea a crear/modificar</param>
        /// <returns>Objeto con el proyecto creado/modificado</returns>
        /// <exception cref="KeyNotFoundException">LA tarea a modificar no existe</exception>
        /// <remarks>Si PrjectTasksrDto.Id == null la tarea sera creada</remarks>
        ProjectTaskDto saveProjectTask(ProjectTaskDto projectTasks);

        /// <summary>
        /// Borra una tarea
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ProjectTaskDtoAmp deleterProjectTask(int id);
    }
}
