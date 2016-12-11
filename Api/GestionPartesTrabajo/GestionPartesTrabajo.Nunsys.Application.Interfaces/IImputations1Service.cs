using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IImputations1Service
    {
        /// <summary>
        /// Guarda usuarios
        /// </summary>
        /// <returns></returns>
        /// <exception cref=""></exception>
        ImputationDto saveImputation(ImputationDto imputation);

        /// <summary>
        /// Busca Usuarios
        /// </summary>
        /// <returns></returns>
        /// <exception cref=""></exception>
        ImputationDto search(ImputationDto imputation);

    }
}
