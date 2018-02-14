namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_IPC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_IPC()
        {
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int idIPC { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaIPC { get; set; }

        public decimal IndiceMensual { get; set; }

        public decimal IndiceTrimestral { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
