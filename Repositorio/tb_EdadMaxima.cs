namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_EdadMaxima
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_EdadMaxima()
        {
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int idEdadMaxima { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEdadMaxima { get; set; }

        public int EdadMaximaAsegurado { get; set; }

        public int EdadMaximaBeneficiario { get; set; }

        public int EdadMaximaBeneficiario2 { get; set; }

        public int IdPeriodo { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
