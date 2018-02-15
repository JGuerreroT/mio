namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ReservaDetalle
    {
        [Key]
        [Column(Order = 0)]
        public int IdReservaDetalle { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdReserva { get; set; }

        public int IdFotoDetallePoliza { get; set; }

        public decimal ReservaMatematica { get; set; }

        public decimal ReservaSepelio { get; set; }

        public decimal ReservaGarantizada { get; set; }

        public decimal PensionReserva { get; set; }

        public virtual tb_FotoDetallePoliza tb_FotoDetallePoliza { get; set; }

        public virtual tb_Reserva tb_Reserva { get; set; }
    }
}
