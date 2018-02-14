namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_TipoPensionista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TipoPensionista()
        {
            tb_PolizaDetalle = new HashSet<tb_PolizaDetalle>();
        }

        [Key]
        public int IdTipoPensionista { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionTipoPensionista { get; set; }

        [Required]
        [StringLength(10)]
        public string ResumenTipoPensionista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_PolizaDetalle> tb_PolizaDetalle { get; set; }
    }
}
