namespace GestionPartesTrabajo.Nunsys.Domain
{
    using NunsysCore.Dominio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProjectTasks : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectTasks()
        {
            Imputations = new HashSet<Imputations>();
            WorkOrders = new HashSet<WorkOrders>();
        }


        public int IdProyect { get; set; }

        [StringLength(50)]
        public string TaskCode { get; set; }

        [StringLength(100)]
        public string Description { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imputations> Imputations { get; set; }

        public virtual Projects Projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
