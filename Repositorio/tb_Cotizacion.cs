namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Cotizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Cotizacion()
        {
            tb_Poliza = new HashSet<tb_Poliza>();
        }

        [Key]
        public int IdCotizacion { get; set; }

        public int NumeroOperacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaResultado { get; set; }

        public int IdMoneda { get; set; }

        public int IdCiaSeguro { get; set; }

        public int IdEstado { get; set; }

        public decimal PensionCotizacion { get; set; }

        public decimal CICCotizacion { get; set; }

        public decimal SumaAsegurada { get; set; }

        [Required]
        [StringLength(20)]
        public string CUSPP { get; set; }

        public virtual tb_CiaSeguro tb_CiaSeguro { get; set; }

        public virtual tb_Estado tb_Estado { get; set; }

        public virtual tb_Moneda tb_Moneda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Poliza> tb_Poliza { get; set; }
    }
}
