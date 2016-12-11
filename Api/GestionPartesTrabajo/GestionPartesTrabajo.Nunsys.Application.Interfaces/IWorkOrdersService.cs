using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
   public interface IWorkOrdersService
    {
        WorkOrderDtoAmp getWorkOrder(int id);

        IList<WorkOrderDtoAmp> getWorkOrders();

        IList<WorkOrderDtoAmp> getPageWorkOrders(FiltrosWorkOrdersModel filtros, int sizePage, int actualPage);

        int countWorkOrders();

        WorkOrderDtoAmp saveWorkOrder(WorkOrderDtoAmp workOrder);

        WorkOrderDtoAmp deleterWorkOrder(int id);

    }
}
