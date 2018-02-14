namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_TasaMercado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TasaMercado()
        {
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int idTasaMercado { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaTasaMercado { get; set; }

        public decimal TMSoles { get; set; }

        public decimal TMDolares { get; set; }

        public decimal TMSolesA { get; set; }

        public decimal TMDolaresA { get; set; }

        public int IdPeriodo { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
