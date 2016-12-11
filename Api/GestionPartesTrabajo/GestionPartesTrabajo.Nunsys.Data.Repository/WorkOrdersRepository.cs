using GestionPartesTrabajo.Nunsys.Data.Interfaces;
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
    public class WorkOrdersRepository : Repository<WorkOrders>, IWorkOrdersRepository
    {
        public WorkOrdersRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
           
        }

        public int countWorkOrders()
        {
            IDbSet<WorkOrders> worksOrders = GetSet();

            var query = from workOder in worksOrders
                        orderby workOder.OTCode ascending
                        select new WorkOrderDto
                        {
                        };
            int workOrdersCount = query.ToList().Count();

            return workOrdersCount;
        }

        public IList<WorkOrderDtoAmp> getPageWorkOrders(FiltrosWorkOrdersModel filtros, int sizePage, int actualPage)
        {
            IDbSet<WorkOrders> workOrders = GetSet();
            IDbSet<Users> users = GetSet<Users>();
            IDbSet<ProjectTasks> projectTasks = GetSet<ProjectTasks>();
            IDbSet<Projects> projects = GetSet<Projects>();
            var query = from workOrder in workOrders
                        join user in users on workOrder.IdUser equals user.Id
                        join projectTask in projectTasks on workOrder.IdProjectTask equals projectTask.Id
                        join project in projects on projectTask.IdProyect equals project.Id
                        orderby workOrder.OTCode ascending
                        select new WorkOrderDtoAmp
                        {
                            Id = workOrder.Id,
                            OTCode = workOrder.OTCode,
                            Description = workOrder.Description,
                            IdProjectTask = projectTask.Id,
                            projectName = project.Description,
                            IdUser = user.Id,
                            Username = user.Name,
                            PlannedDate = workOrder.PlannedDate,
                            EstimatedDuration = workOrder.EstimatedDuration,
                            RemainingDuration = workOrder.RemainingDuration,
                            WorkOrderStatus = workOrder.WorkOrderStatus
                        };

            if (filtros.OTCode != null)
            {
                query = query.Where(item => item.OTCode.Equals(filtros.OTCode));
            }

            if (filtros.Description != null)
            {
                query = query.Where(item => item.Description.Equals(filtros.Description));
            }

            if (filtros.projectName != null)
            {
                query = query.Where(item => item.projectName.Equals(filtros.projectName));
            }

            if (filtros.Username != null)
            {
                query = query.Where(item => item.Username.Equals(filtros.Username));
            }

            if (filtros.WorkOrderStatus != null)
            {
                query = query.Where(item => item.WorkOrderStatus.Equals(filtros.WorkOrderStatus));
            }

            if (filtros.PlannedDate1 != null)
            {
                query = query.Where(item => item.PlannedDate.Value >= filtros.PlannedDate1.Value);
            }

            if(filtros.PlannedDate2 !=null)
            {
                query = query.Where(item => item.PlannedDate.Value <= filtros.PlannedDate2.Value);
            }

            IList<WorkOrderDtoAmp> workOrdersList = query.Skip(sizePage * (actualPage))
                                              .Take(sizePage)
                                              .ToList();
            return workOrdersList;
        }

        public WorkOrderDtoAmp getWorkOrder(int id)
        {
            IDbSet<WorkOrders> workOrders = GetSet();
            IDbSet<Users> users = GetSet<Users>();
            IDbSet<ProjectTasks> projectTasks = GetSet<ProjectTasks>();
            IDbSet<Projects> projects = GetSet<Projects>();
            var query = from workOrder in workOrders
                        where workOrder.Id == id
                        join user in users on workOrder.IdUser equals user.Id
                        join projectTask in projectTasks on workOrder.IdProjectTask equals projectTask.Id
                        join project in projects on projectTask.IdProyect equals project.Id
                        orderby workOrder.OTCode ascending
                        select new WorkOrderDtoAmp
                        {
                            Id = workOrder.Id,
                            OTCode = workOrder.OTCode,
                            Description = workOrder.Description,
                            IdProjectTask = projectTask.Id,
                            projectName = project.Description,
                            IdUser = user.Id,
                            Username = user.Name,
                            PlannedDate = workOrder.PlannedDate,
                            EstimatedDuration = workOrder.EstimatedDuration,
                            RemainingDuration = workOrder.RemainingDuration,
                            WorkOrderStatus = workOrder.WorkOrderStatus
                        };

            WorkOrderDtoAmp resultado = query.First<WorkOrderDtoAmp>();

            return resultado;
        }
    }
}
