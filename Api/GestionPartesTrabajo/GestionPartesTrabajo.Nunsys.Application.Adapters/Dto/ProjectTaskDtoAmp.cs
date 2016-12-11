using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    public class ProjectTaskDtoAmp
    {
        public int Id { get; set; }
        public int IdProyect { get; set; }

        public string NameProject { get; set; }

        [StringLength(50)]
        public string TaskCode { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        public byte[] SysVersion { get; set; }
    }
}
