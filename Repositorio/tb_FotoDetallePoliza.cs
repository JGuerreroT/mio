namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_FotoDetallePoliza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_FotoDetallePoliza()
        {
            tb_ReservaDetalle = new HashSet<tb_ReservaDetalle>();
        }

        [Key]
        public int IdFotoDetallePoliza { get; set; }

        public int IdFoto { get; set; }

        public int IdFotoDetalle { get; set; }

        public int IdPoliza { get; set; }

        public int IdDetallePoliza { get; set; }

        public int IdPersona { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(20)]
        public string CUSSPP { get; set; }

        [Required]
        [StringLength(20)]
        public string DNI { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFallecimiento { get; set; }

        public int IdEstado { get; set; }

        public int IdSexo { get; set; }

        public int IdRelacionFamiliar { get; set; }

        public int IdSalud { get; set; }

        public decimal PorcentajeBeneficio { get; set; }

        public int IdTipoPensionista { get; set; }

        public int IdTipoPersona { get; set; }

        public virtual tb_FotoDetalle tb_FotoDetalle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ReservaDetalle> tb_ReservaDetalle { get; set; }
    }
}
