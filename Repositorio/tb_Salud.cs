namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Salud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Salud()
        {
            tb_PolizaDetalle = new HashSet<tb_PolizaDetalle>();
        }

        [Key]
        public int IdSalud { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionSalud { get; set; }

        [Required]
        [StringLength(10)]
        public string ResumenSalud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_PolizaDetalle> tb_PolizaDetalle { get; set; }
    }
}
