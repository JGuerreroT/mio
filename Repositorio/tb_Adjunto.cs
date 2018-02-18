namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Adjunto
    {
        [Key]
        public int IdArchivo { get; set; }

        [Required]
        [StringLength(200)]
        public string Ruta { get; set; }
    }
}
