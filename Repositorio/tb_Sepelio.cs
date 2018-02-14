namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Sepelio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Sepelio()
        {
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int IdSepelio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaSepelio { get; set; }

        public decimal MontoGS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
