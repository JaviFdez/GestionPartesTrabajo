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
    class Imputations1Repository : Repository<Imputations>, IImputations1Repository
    {
    
        public Imputations1Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

       
    }
}
