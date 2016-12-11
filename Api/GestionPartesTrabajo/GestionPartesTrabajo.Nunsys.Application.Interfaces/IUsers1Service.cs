using GestionPartesTrabajo.Nunsys.Application.Adapters.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Interfaces
{
    public interface IUsers1Service
    {
        IList<UserDto> getUsers();
        UserDto saveUser(UserDto user);
    }
}
