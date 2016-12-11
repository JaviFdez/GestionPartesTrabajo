namespace GestionPartesTrabajo.Nunsys.Application.Adapters.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserDto
    {
        public int? Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname1 { get; set; }

        [StringLength(50)]
        public string Surname2 { get; set; }

        [Required]
        [StringLength(128)]
        public string IdNetUser { get; set; }

        public byte[] SysVersion { get; set; }
    }
}
