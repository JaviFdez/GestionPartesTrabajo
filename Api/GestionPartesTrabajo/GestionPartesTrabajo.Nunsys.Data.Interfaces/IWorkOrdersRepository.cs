using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Model;
using GestionPartesTrabajo.Nunsys.Domain;
using NunsysCore.Datos;
using NunsysCore.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Data.Interfaces
{
    public interface IWorkOrdersRepository: IRepository<WorkOrders>
    {
        WorkOrderDtoAmp getWorkOrder(int id);
        IList<WorkOrderDtoAmp> getPageWorkOrders(FiltrosWorkOrdersModel filtros, int sizePage, int actualPage);
        int countWorkOrders();
    }
}
