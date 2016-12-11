using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using System.Collections.Generic;

namespace GestionPartesTrabajo.Nunsys.Application.Services
{
    public interface ICustomers1Service
    {
        /// <summary>
        /// Devuelve un consumer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        CustomerDto getCustomer(int id);

        IList<CustomerDto> getCustomers();

        IList<CustomerDto> getCustomers(int sizePage, int actualPage);

        int countCustomers();

        /// <summary>
        /// Creo o modifica un cliente
        /// </summary>
        /// <param name="customer">objeto con el cliente a crear/modificar</param>
        /// <returns>Objeto con el cliente creado/modificado</returns>
        /// <exception cref="KeyNotFoundException">El cliente a modificar no existe</exception>
        /// <remarks>Si CustomerDto.Id == null el cliente sera creado</remarks>
        CustomerDto saveCustomer(CustomerDto customer);

        /// <summary>
        /// Borra un customer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        CustomerDto deleterCustomer(int id);

    }
}