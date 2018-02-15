namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Foto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Foto()
        {
            tb_FotoDetalle = new HashSet<tb_FotoDetalle>();
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int IdFoto { get; set; }

        public int IdPeriodo { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFoto { get; set; }

        public int IdMoneda { get; set; }

        public int IdEstado { get; set; }

        public virtual tb_Estado tb_Estado { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_FotoDetalle> tb_FotoDetalle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
