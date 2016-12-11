namespace GestionPartesTrabajo.Nunsys.Domain
{
    using NunsysCore.Dominio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Users : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Imputations = new HashSet<Imputations>();
            WorkOrders = new HashSet<WorkOrders>();
        }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname1 { get; set; }

        [StringLength(50)]
        public string Surname2 { get; set; }

        [Required]
        [StringLength(128)]
        public string IdNetUser { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imputations> Imputations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
