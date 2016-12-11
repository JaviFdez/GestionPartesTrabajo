namespace GestionPartesTrabajo.Nunsys.Domain
{
    using NunsysCore.Dominio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Imputations : BaseEntity
    {
        public int IdUser { get; set; }

        public int? IdWorkOrder { get; set; }

        public int IdProjectTask { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public double? Hours { get; set; }

        public virtual ProjectTasks ProjectTasks { get; set; }

        public virtual Users Users { get; set; }

        public virtual WorkOrders WorkOrders { get; set; }
    }
}
