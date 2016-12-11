namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{ 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ImputationDto
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public int? IdWorkOrder { get; set; }

        public int IdProjectTask { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public double? Hours { get; set; }

        public byte[] SysVersion { get; set; }

    }
}
