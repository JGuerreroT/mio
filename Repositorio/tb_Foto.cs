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

        public int IdPoliza { get; set; }

        public int NumeroPoliza { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaDevengue { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaVigencia { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaEnvio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNotificacion { get; set; }

        public int IdMoneda { get; set; }

        public int IdCobertura { get; set; }

        public int IdModalidad { get; set; }

        public int PeriodoDiferido { get; set; }

        public int PeriodoGarantizado { get; set; }

        public bool Gratificacion { get; set; }

        public bool DerechoACrecer { get; set; }

        public bool Calce { get; set; }

        public bool Repacto { get; set; }

        public decimal Prima { get; set; }

        public decimal CICInical { get; set; }

        public decimal CICFInal { get; set; }

        public decimal TasaVenta { get; set; }

        public decimal TasaReserva { get; set; }

        public bool RentaTemporal { get; set; }

        public decimal PorcentajeRentaTemporal { get; set; }

        public int PeriodoInicialRentaTemporal { get; set; }

        public int IdCotizacion { get; set; }

        public int IdPeriodoPoliza { get; set; }

        public bool Estudiante { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_FotoDetalle> tb_FotoDetalle { get; set; }

        public virtual tb_Poliza tb_Poliza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Reserva> tb_Reserva { get; set; }
    }
}
