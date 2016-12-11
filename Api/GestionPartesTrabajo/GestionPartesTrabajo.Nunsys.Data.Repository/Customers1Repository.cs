using NunsysCore.Datos;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionPartesTrabajo.Nunsys.Data.Repository;
using GestionPartesTrabajo.Nunsys.Domain;
using System.Data.Entity;
using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class Customers1Repository : Repository<Customers>, ICustomers1Repository
    {
        public Customers1Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<CustomerDto> getPageCustomers(int sizePage, int actualPage)
        {
            IDbSet<Customers> customers = GetSet();

            var query = from customer in customers
                        orderby customer.Number ascending
                        select new CustomerDto
                        {
                            Number = customer.Number,
                            Name = customer.Name,
                        };

            IList<CustomerDto> customersList = query.Skip(sizePage * (actualPage))
                                              .Take(sizePage)
                                              .ToList();
            return customersList;

        }

        public int countCustomers()
        {
            IDbSet<Customers> customers = GetSet();

            var query = from customer in customers
                        orderby customer.Number ascending
                        select new CustomerDto
                        {
                            Number = customer.Number,
                            Name = customer.Name,
                        };
            int customersCount = query.ToList().Count();

            return customersCount;
        }
    }
}
