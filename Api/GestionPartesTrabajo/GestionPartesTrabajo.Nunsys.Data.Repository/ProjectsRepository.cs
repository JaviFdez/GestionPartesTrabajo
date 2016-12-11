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
using System.Data.Entity;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class ProjectsRepository : Repository<Projects>, IProyectsRepository
    {
        public ProjectsRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public int countProjects()
        {
            IDbSet<Projects> projects = GetSet();

            var query = from project in projects
                        orderby project.ProjectCode ascending
                        select new ProjectDtoAmp
                        {
                            Id = project.Id,                            
                            ProjectCode = project.ProjectCode,
                            Description = project.Description,
                            IdCustomer = project.IdCustomer
                        };
            int projectsCount = query.ToList().Count();

            return projectsCount;
        }

        public IList<ProjectDtoAmp> getPageProjects(FiltrosProjectsModel filtros, int sizePage, int actualPage)
        {
            IDbSet<Projects> projects = GetSet();
            IDbSet<Customers> customers = GetSet<Customers>();
            var query = from project in projects
                        join customer in customers on project.IdCustomer equals customer.Id
                        orderby project.ProjectCode ascending
                        select new ProjectDtoAmp
                        {
                            Id = project.Id,
                            ProjectCode = project.ProjectCode,
                            Description = project.Description,
                            NameCustomer = customer.Name
                        };
            

            if (filtros.NameCustomer != null)
            {
                query = query.Where(project => project.NameCustomer.Equals(filtros.NameCustomer));
            }

            if (filtros.Descripcion != null)
            {
                query = query.Where(project => project.Description.Equals(filtros.Descripcion));
            }

            if (filtros.CodeProject != null)
            {
                query = query.Where(project => project.ProjectCode.Equals(filtros.CodeProject));
            }

            IList<ProjectDtoAmp> projectsList = query.Skip(sizePage * (actualPage))
                                              .Take(sizePage)
                                              .ToList();
            return projectsList;
        }
    }
}
