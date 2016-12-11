using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IProjectsService
    {
        /// <summary>
        /// Devuelve un project
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ProjectDto getProject(int id);

        IList<ProjectDtoAmp> getProjects();

        IList<ProjectDtoAmp> getPageProjects(FiltrosProjectsModel filtros, int sizePage, int actualPage);

        int countProjects();

        /// <summary>
        /// Creo o modifica un proyecto
        /// </summaryproyecto
        /// <param name="proyecto">objeto con el proyecto a crear/modificar</param>
        /// <returns>Objeto con el proyecto creado/modificado</returns>
        /// <exception cref="KeyNotFoundException">El proyecto a modificar no existe</exception>
        /// <remarks>Si CustomerDto.Id == null el cliente sera creado</remarks>
        ProjectDto saveProject(ProjectDto project);

        /// <summary>
        /// Borra un proyecto
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ProjectDtoAmp deleterProject(int id);
    }
}
