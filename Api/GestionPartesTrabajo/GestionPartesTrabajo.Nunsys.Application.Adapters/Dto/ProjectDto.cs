namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProjectDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int IdCustomer { get; set; }

        public byte[] SysVersion { get; set; }

        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
    }
}
