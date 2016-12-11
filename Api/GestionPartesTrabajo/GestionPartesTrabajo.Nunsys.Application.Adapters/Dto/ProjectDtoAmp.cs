using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    public partial class ProjectDtoAmp
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int IdCustomer { get; set; }

        public string NameCustomer { get; set; }

        public byte[] SysVersion { get; set; }
    }
}
