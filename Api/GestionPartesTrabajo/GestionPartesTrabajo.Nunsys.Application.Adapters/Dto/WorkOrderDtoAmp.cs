using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    public partial class WorkOrderDtoAmp
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(50)]
        public string OTCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int IdProjectTask { get; set; }

        public string projectName { get; set; }

        public int IdUser { get; set; }

        public string Username { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PlannedDate { get; set; }

        public int EstimatedDuration { get; set; }

        public int RemainingDuration { get; set; }

        public int WorkOrderStatus { get; set; }
        public byte[] SysVersion { get; set; }
    }
}
