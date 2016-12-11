namespace GestionPartesTrabajo.Nunsys.Domain
{
    using NunsysCore.Dominio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class WorkOrders : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkOrders()
        {
            Imputations = new HashSet<Imputations>();
        }

        [Required]
        [StringLength(50)]
        public string OTCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int IdProjectTask { get; set; }

        public int IdUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PlannedDate { get; set; }

        public int EstimatedDuration { get; set; }

        public int RemainingDuration { get; set; }

        public int WorkOrderStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imputations> Imputations { get; set; }

        public virtual ProjectTasks ProjectTasks { get; set; }

        public virtual Users Users { get; set; }
    }
}
