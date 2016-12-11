namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CustomerDto
    {
        public int? Id { get; set; }

        [StringLength(50)]
        public string Number { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public byte[] SysVersion { get; set; }
    }
}
