using NunsysCore.Datos;
using GestionPartesTrabajo.Nunsys.Data.Interfaces;
using GestionPartesTrabajo.Nunsys.Domain;

namespace GestionPartesTrabajo.Nunsys.Data.Repository
{
    public class SampleRepository : Repository<Sample>, ISampleRepository
    {
        public SampleRepository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
