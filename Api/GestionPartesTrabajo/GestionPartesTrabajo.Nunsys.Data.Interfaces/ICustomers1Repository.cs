
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Domain;
using NunsysCore.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Data.Interfaces
{
    public interface ICustomers1Repository : IRepository<Customers>
    {

        IList<CustomerDto> getPageCustomers(int sizePage, int actualPage);
        int countCustomers();
    }

}
