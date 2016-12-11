using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Domain;
using NunsysCore.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Data.Interfaces
{
    public interface IProyectsRepository: IRepository<Projects>
    {
        IList<ProjectDtoAmp> getPageProjects(FiltrosProjectsModel filtros, int sizePage, int actualPage);
        int countProjects();
    }
}
