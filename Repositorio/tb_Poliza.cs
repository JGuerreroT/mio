namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Poliza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Poliza()
        {
            tb_FotoDetalle = new HashSet<tb_FotoDetalle>();
            tb_PolizaDetalle = new HashSet<tb_PolizaDetalle>();
        }

        [Key]
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

        public int IdPeriodo { get; set; }

        public bool Estudiante { get; set; }

        public decimal PorcentajeGarantizado { get; set; }

        public decimal PensionIncial { get; set; }

        public decimal PensionDevengue { get; set; }

        public decimal PensionReserva { get; set; }

        public virtual tb_Cobertura tb_Cobertura { get; set; }

        public virtual tb_Cotizacion tb_Cotizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_FotoDetalle> tb_FotoDetalle { get; set; }

        public virtual tb_Modalidad tb_Modalidad { get; set; }

        public virtual tb_Moneda tb_Moneda { get; set; }

        public virtual tb_Periodo tb_Periodo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_PolizaDetalle> tb_PolizaDetalle { get; set; }
    }
}
