namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_TasaAnclaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_TasaAnclaje()
        {
            tb_Reserva = new HashSet<tb_Reserva>();
        }

        [Key]
        public int IdTasaAnclaje { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaTasaAnclaje { get; set; }

        public decimal TASoles { get; set; }

        public decimal TADolares { get; set; }

        public decimal TASolesA { get; set; }

        public decimal TADolaresA { get; set; }

        public int IdPeriodo { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
