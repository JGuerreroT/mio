namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_RelacionFamiliar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_RelacionFamiliar()
        {
            tb_PolizaDetalle = new HashSet<tb_PolizaDetalle>();
        }

        [Key]
        public int IdRelacionFamiliar { get; set; }

        [Required]
        [StringLength(10)]
        public string DescripcionRelacionFamiliar { get; set; }

        [Required]
        [StringLength(10)]
        public string ResumenRelacionFamiliar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_PolizaDetalle> tb_PolizaDetalle { get; set; }
    }
}
