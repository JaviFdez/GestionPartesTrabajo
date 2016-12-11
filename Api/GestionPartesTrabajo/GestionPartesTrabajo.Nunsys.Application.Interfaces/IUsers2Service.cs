using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IUsers2Service
    {
        /// <summary>
        /// Crear un usuario
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>

        int createUser(int param1);

        /// <summary>
        /// Guardar un usuario 
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>

        int saveUser(int param1);

        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>

        int updateUser(int param1);

        /// <summary>
        /// Borrar un usuario
        /// </summary>
        /// <param name="param1">...</param>
        /// <returns>...</returns>
        /// <exception cref="KeyNotFoundException">...</exception>

        int deleteUser(int param1);

    }
}
