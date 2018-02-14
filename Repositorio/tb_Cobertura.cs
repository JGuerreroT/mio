namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Cobertura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Cobertura()
        {
            tb_Poliza = new HashSet<tb_Poliza>();
        }

        [Key]
        public int IdCobertura { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionCobertura { get; set; }

        [Required]
        [StringLength(10)]
        public string ResumenCobertura { get; set; }

        public decimal PorcentajeCobertura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Poliza> tb_Poliza { get; set; }
    }
}
