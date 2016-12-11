using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Model
{
    public class FiltrosWorkOrdersModel
    {
        public string OTCode { get; set; }

        public string Description { get; set; }

        public string projectName { get; set; }

        public string Username { get; set; }

        public int? WorkOrderStatus { get; set; }

        public DateTime? PlannedDate1 { get; set; }

        public DateTime? PlannedDate2 { get; set; }
    }
}
