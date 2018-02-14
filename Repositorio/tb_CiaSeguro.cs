namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CiaSeguro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_CiaSeguro()
        {
            tb_Cotizacion = new HashSet<tb_Cotizacion>();
        }

        [Key]
        public int IdCiaSeguro { get; set; }

        [Required]
        [StringLength(50)]
        public string DescripcionCiaSeguro { get; set; }

        [Required]
        [StringLength(20)]
        public string ResumenCiaSeguro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Cotizacion> tb_Cotizacion { get; set; }
    }
}
