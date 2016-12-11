using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using GestionPartesTrabajo.Nunsys.Domain;
using System.Collections.Generic;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IImputations2Service
    {
        /// <summary>
        /// Devuelve un consumer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ImputationDto getImputation(int id);

        /// <summary>
        /// Devuelve un consumer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        IList<ImputationDto> getImputations();

        /// <summary>
        /// Creo o modifica un customer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ImputationDto saveImputation(ImputationDto imputation);

        /// <summary>
        /// Borra un customer
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>
        ImputationDto deleteImputation(int id);
    }
}
