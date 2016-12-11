using NunsysCore.Datos;
using GestionPartesTrabajo.Nunsys.Domain;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class Imputations2Repository : Repository<Imputations>, IImputations2Repository
    {
        public Imputations2Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
