using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunsysCore.Datos;
using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;



namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class Users1Repository : Repository<Users>, IUsers1Repository
    {
        public Users1Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
