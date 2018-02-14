namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Reserva()
        {
            tb_ReservaDetalle = new HashSet<tb_ReservaDetalle>();
        }

        [Key]
        public int IdReserva { get; set; }

        public int IdPeriodo { get; set; }

        public int IdFoto { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaReserva { get; set; }

        public decimal ReservaSepelio { get; set; }

        public decimal ReservaGarantizado { get; set; }

        public decimal ReservaMatematica { get; set; }

        public decimal ReservaTotal { get; set; }

        public int IdSepelio { get; set; }

        public int IdTipoCambio { get; set; }

        public int IdTasaMercado { get; set; }

        public int IdTasaAnclaje { get; set; }

        public int IdFactorSeguridad { get; set; }

        public decimal FactorIPC { get; set; }

        public int IdEdadMaxima { get; set; }

        public int IdEstado { get; set; }

        public decimal PensionReserva { get; set; }

        public int IdIPC { get; set; }

        public decimal IPCInicial { get; set; }

        public decimal IPCFinal { get; set; }

        public virtual tb_EdadMaxima tb_EdadMaxima { get; set; }

        public virtual tb_Estado tb_Estado { get; set; }

        public virtual tb_FactorSeguridad tb_FactorSeguridad { get; set; }

        public virtual tb_Foto tb_Foto { get; set; }

        public virtual tb_IPC tb_IPC { get; set; }

        public virtual tb_Sepelio tb_Sepelio { get; set; }

        public virtual tb_TasaAnclaje tb_TasaAnclaje { get; set; }

        public virtual tb_TasaMercado tb_TasaMercado { get; set; }

        public virtual tb_TipoCambio tb_TipoCambio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ReservaDetalle> tb_ReservaDetalle { get; set; }
    }
}
