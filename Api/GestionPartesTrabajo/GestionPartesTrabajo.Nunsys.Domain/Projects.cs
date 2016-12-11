namespace GestionPartesTrabajo.Nunsys.Domain
{
    using NunsysCore.Dominio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Projects : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projects()
        {
            ProjectTasks = new HashSet<ProjectTasks>();
        }

        [Required]
        [StringLength(50)]
        public string ProjectCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int IdCustomer { get; set; }

        public virtual Customers Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
    }
}
