namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string Login { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public int IdEstado { get; set; }
    }
}
