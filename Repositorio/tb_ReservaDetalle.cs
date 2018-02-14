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
        public int IdReservaDetalle { get; set; }

        public int IdReserva { get; set; }

        public int IdFotoDetalle { get; set; }

        public decimal ReservaMatematica { get; set; }

        public decimal ReservaSepelio { get; set; }

        public decimal ReservaGarantizada { get; set; }

        public decimal PensionReserva { get; set; }

        public virtual tb_FotoDetalle tb_FotoDetalle { get; set; }

        public virtual tb_Reserva tb_Reserva { get; set; }
    }
}
