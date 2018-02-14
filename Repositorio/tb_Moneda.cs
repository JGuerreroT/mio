namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Moneda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Moneda()
        {
            tb_Cotizacion = new HashSet<tb_Cotizacion>();
            tb_Poliza = new HashSet<tb_Poliza>();
        }

        [Key]
        public int idMoneda { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionMoneda { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoMoneda { get; set; }

        [Required]
        [StringLength(10)]
        public string Codigo2Moneda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Cotizacion> tb_Cotizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Poliza> tb_Poliza { get; set; }
    }
}
