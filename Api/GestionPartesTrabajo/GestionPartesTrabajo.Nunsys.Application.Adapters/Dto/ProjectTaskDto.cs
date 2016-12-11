namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProjectTaskDto
    {
        public int? Id { get; set; }
        public int IdProyect { get; set; }

        [StringLength(50)]
        public string TaskCode { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        public byte[] SysVersion { get; set; }
    }
}
