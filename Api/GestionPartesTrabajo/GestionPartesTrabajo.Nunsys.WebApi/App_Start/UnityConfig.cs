using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using GestionPartesTrabajo.Nunsys.Application.Interfaces;
using GestionPartesTrabajo.Nunsys.Application.Services;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Data.Repository;
using NunsysCore.Datos;

namespace GestionPartesTrabajo.Nunsys.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration configuration)
        {
            var container = new UnityContainer();

            container.RegisterType<IQueryableUnitOfWork, UnitOfWorkPrincipal>();
            container.RegisterType<IUnitOfWorkPrincipal, UnitOfWorkPrincipal>(new PerResolveLifetimeManager());

            container.RegisterType<ISampleService, SampleService>();
            // ...


            container.RegisterType<IImputations1Service , Imputations1Service>();
            container.RegisterType<IImputations1Repository, IImputations1Repository>();

            container.RegisterType<ICustomers1Service, Customers1Service>();
            container.RegisterType<ICustomers1Repository, Customers1Repository>();

            container.RegisterType<IProjectsService, ProjectsService>();
            container.RegisterType<IProyectsRepository, ProjectsRepository>();

            container.RegisterType<IProjectTasksService, ProjectTasksService>();
            container.RegisterType<IProjectTasksRepository, ProjectTaskRepository>();

            container.RegisterType<IWorkOrdersService, WorkOrdersService>();
            container.RegisterType<IWorkOrdersRepository, WorkOrdersRepository>();

            container.RegisterType<IUsers1Service, Users1Service>();
            container.RegisterType<IUsers1Repository, Users1Repository>();

            configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}