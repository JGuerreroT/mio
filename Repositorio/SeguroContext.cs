namespace Repositorio
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SeguroContext : DbContext
    {
        public SeguroContext()
            : base("name=SeguroContext")
        {
        }

        public virtual DbSet<tb_Adjunto> tb_Adjunto { get; set; }
        public virtual DbSet<tb_CiaSeguro> tb_CiaSeguro { get; set; }
        public virtual DbSet<tb_Cobertura> tb_Cobertura { get; set; }
        public virtual DbSet<tb_Cotizacion> tb_Cotizacion { get; set; }
        public virtual DbSet<tb_EdadMaxima> tb_EdadMaxima { get; set; }
        public virtual DbSet<tb_Estado> tb_Estado { get; set; }
        public virtual DbSet<tb_FactorSeguridad> tb_FactorSeguridad { get; set; }
        public virtual DbSet<tb_Foto> tb_Foto { get; set; }
        public virtual DbSet<tb_FotoDetalle> tb_FotoDetalle { get; set; }
        public virtual DbSet<tb_FotoDetallePoliza> tb_FotoDetallePoliza { get; set; }
        public virtual DbSet<tb_IPC> tb_IPC { get; set; }
        public virtual DbSet<tb_Modalidad> tb_Modalidad { get; set; }
        public virtual DbSet<tb_Moneda> tb_Moneda { get; set; }
        public virtual DbSet<tb_Periodo> tb_Periodo { get; set; }
        public virtual DbSet<tb_Persona> tb_Persona { get; set; }
        public virtual DbSet<tb_Poliza> tb_Poliza { get; set; }
        public virtual DbSet<tb_PolizaDetalle> tb_PolizaDetalle { get; set; }
        public virtual DbSet<tb_RelacionFamiliar> tb_RelacionFamiliar { get; set; }
        public virtual DbSet<tb_Reserva> tb_Reserva { get; set; }
        public virtual DbSet<tb_ReservaDetalle> tb_ReservaDetalle { get; set; }
        public virtual DbSet<tb_Rol> tb_Rol { get; set; }
        public virtual DbSet<tb_Salud> tb_Salud { get; set; }
        public virtual DbSet<tb_Sepelio> tb_Sepelio { get; set; }
        public virtual DbSet<tb_Sexo> tb_Sexo { get; set; }
        public virtual DbSet<tb_TasaAnclaje> tb_TasaAnclaje { get; set; }
        public virtual DbSet<tb_TasaMercado> tb_TasaMercado { get; set; }
        public virtual DbSet<tb_TipoCambio> tb_TipoCambio { get; set; }
        public virtual DbSet<tb_TipoPensionista> tb_TipoPensionista { get; set; }
        public virtual DbSet<tb_TipoPersona> tb_TipoPersona { get; set; }
        public virtual DbSet<tb_Usuario> tb_Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Adjunto>()
                .Property(e => e.Ruta)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CiaSeguro>()
                .Property(e => e.DescripcionCiaSeguro)
                .IsUnicode(false);

            modelBuilder.Entity<tb_CiaSeguro>()
                .Property(e => e.ResumenCiaSeguro)
                .IsFixedLength();

            modelBuilder.Entity<tb_CiaSeguro>()
                .HasMany(e => e.tb_Cotizacion)
                .WithRequired(e => e.tb_CiaSeguro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Cobertura>()
                .Property(e => e.DescripcionCobertura)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Cobertura>()
                .Property(e => e.ResumenCobertura)
                .IsFixedLength();

            modelBuilder.Entity<tb_Cobertura>()
                .Property(e => e.PorcentajeCobertura)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Cobertura>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Cobertura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Cotizacion>()
                .Property(e => e.PensionCotizacion)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Cotizacion>()
                .Property(e => e.CICCotizacion)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Cotizacion>()
                .Property(e => e.SumaAsegurada)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Cotizacion>()
                .Property(e => e.CUSPP)
                .IsFixedLength();

            modelBuilder.Entity<tb_Cotizacion>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Cotizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_EdadMaxima>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_EdadMaxima)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .Property(e => e.DescripcionEstado)
                .IsFixedLength();

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Cotizacion)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Foto)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Periodo)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Persona)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_FactorSeguridad>()
                .Property(e => e.PorcentajeFactorSeguridad)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FactorSeguridad>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_FactorSeguridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Foto>()
                .HasMany(e => e.tb_FotoDetalle)
                .WithRequired(e => e.tb_Foto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Foto>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_Foto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.Prima)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.CICInical)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.CICFInal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.TasaVenta)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.TasaReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.PorcentajeRentaTemporal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.PorcentajeGarantizado)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.PensionIncial)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.PensionDevengue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .Property(e => e.PensionReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetalle>()
                .HasMany(e => e.tb_FotoDetallePoliza)
                .WithRequired(e => e.tb_FotoDetalle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_FotoDetalle>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_FotoDetalle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .Property(e => e.CUSSPP)
                .IsFixedLength();

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .Property(e => e.DNI)
                .IsFixedLength();

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .Property(e => e.PorcentajeBeneficio)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_FotoDetallePoliza>()
                .HasMany(e => e.tb_ReservaDetalle)
                .WithRequired(e => e.tb_FotoDetallePoliza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_IPC>()
                .Property(e => e.IndiceMensual)
                .HasPrecision(18, 10);

            modelBuilder.Entity<tb_IPC>()
                .Property(e => e.IndiceTrimestral)
                .HasPrecision(18, 10);

            modelBuilder.Entity<tb_IPC>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_IPC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Modalidad>()
                .Property(e => e.DescripcionModalidad)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Modalidad>()
                .Property(e => e.ResumenModalidad)
                .IsFixedLength();

            modelBuilder.Entity<tb_Modalidad>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Modalidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Moneda>()
                .Property(e => e.DescripcionMoneda)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Moneda>()
                .Property(e => e.CodigoMoneda)
                .IsFixedLength();

            modelBuilder.Entity<tb_Moneda>()
                .Property(e => e.Codigo2Moneda)
                .IsFixedLength();

            modelBuilder.Entity<tb_Moneda>()
                .HasMany(e => e.tb_Cotizacion)
                .WithRequired(e => e.tb_Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Moneda>()
                .HasMany(e => e.tb_Foto)
                .WithRequired(e => e.tb_Moneda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Moneda>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Moneda)
                .HasForeignKey(e => e.IdModalidad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .Property(e => e.Mes)
                .IsFixedLength();

            modelBuilder.Entity<tb_Periodo>()
                .Property(e => e.Anio)
                .IsFixedLength();

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_EdadMaxima)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_FactorSeguridad)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_Foto)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_Poliza)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_TasaAnclaje)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_TasaMercado)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Periodo>()
                .HasMany(e => e.tb_TipoCambio)
                .WithRequired(e => e.tb_Periodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.CUSSPP)
                .IsFixedLength();

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.DNI)
                .IsFixedLength();

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.FechaNac)
                .IsFixedLength();

            modelBuilder.Entity<tb_Persona>()
                .Property(e => e.FechaFall)
                .IsFixedLength();

            modelBuilder.Entity<tb_Persona>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.Prima)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.CICInical)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.CICFInal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.TasaVenta)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.TasaReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.PorcentajeRentaTemporal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.PorcentajeGarantizado)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.PensionIncial)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.PensionDevengue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.PensionReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.FechaDev)
                .IsFixedLength();

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.FechaVig)
                .IsFixedLength();

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.FechaEnv)
                .IsFixedLength();

            modelBuilder.Entity<tb_Poliza>()
                .Property(e => e.FechaNot)
                .IsFixedLength();

            modelBuilder.Entity<tb_Poliza>()
                .HasMany(e => e.tb_FotoDetalle)
                .WithRequired(e => e.tb_Poliza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Poliza>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_Poliza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_PolizaDetalle>()
                .Property(e => e.PorcentajeBeneficio)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_RelacionFamiliar>()
                .Property(e => e.DescripcionRelacionFamiliar)
                .IsFixedLength();

            modelBuilder.Entity<tb_RelacionFamiliar>()
                .Property(e => e.ResumenRelacionFamiliar)
                .IsFixedLength();

            modelBuilder.Entity<tb_RelacionFamiliar>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_RelacionFamiliar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.ReservaSepelio)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.ReservaGarantizado)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.ReservaMatematica)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.ReservaTotal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.FactorIPC)
                .HasPrecision(18, 10);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.PensionReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.IPCInicial)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .Property(e => e.IPCFinal)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Reserva>()
                .HasMany(e => e.tb_ReservaDetalle)
                .WithRequired(e => e.tb_Reserva)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_ReservaDetalle>()
                .Property(e => e.ReservaMatematica)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_ReservaDetalle>()
                .Property(e => e.ReservaSepelio)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_ReservaDetalle>()
                .Property(e => e.ReservaGarantizada)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_ReservaDetalle>()
                .Property(e => e.PensionReserva)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Rol>()
                .Property(e => e.DescripcionRol)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Rol>()
                .HasMany(e => e.tb_Usuario)
                .WithRequired(e => e.tb_Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Salud>()
                .Property(e => e.DescripcionSalud)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Salud>()
                .Property(e => e.ResumenSalud)
                .IsFixedLength();

            modelBuilder.Entity<tb_Salud>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_Salud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Sepelio>()
                .Property(e => e.MontoGS)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_Sepelio>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_Sepelio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Sexo>()
                .Property(e => e.DescripcionSexo)
                .IsFixedLength();

            modelBuilder.Entity<tb_Sexo>()
                .Property(e => e.ResumenSexo)
                .IsFixedLength();

            modelBuilder.Entity<tb_Sexo>()
                .HasMany(e => e.tb_Persona)
                .WithRequired(e => e.tb_Sexo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_TasaAnclaje>()
                .Property(e => e.TASoles)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaAnclaje>()
                .Property(e => e.TADolares)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaAnclaje>()
                .Property(e => e.TASolesA)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaAnclaje>()
                .Property(e => e.TADolaresA)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaAnclaje>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_TasaAnclaje)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_TasaMercado>()
                .Property(e => e.TMSoles)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaMercado>()
                .Property(e => e.TMDolares)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaMercado>()
                .Property(e => e.TMSolesA)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaMercado>()
                .Property(e => e.TMDolaresA)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TasaMercado>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_TasaMercado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_TipoCambio>()
                .Property(e => e.ImporteTC)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tb_TipoCambio>()
                .HasMany(e => e.tb_Reserva)
                .WithRequired(e => e.tb_TipoCambio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_TipoPensionista>()
                .Property(e => e.DescripcionTipoPensionista)
                .IsUnicode(false);

            modelBuilder.Entity<tb_TipoPensionista>()
                .Property(e => e.ResumenTipoPensionista)
                .IsFixedLength();

            modelBuilder.Entity<tb_TipoPensionista>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_TipoPensionista)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_TipoPersona>()
                .Property(e => e.DescripcionTipoPersona)
                .IsUnicode(false);

            modelBuilder.Entity<tb_TipoPersona>()
                .Property(e => e.ResumenPersona)
                .IsFixedLength();

            modelBuilder.Entity<tb_TipoPersona>()
                .HasMany(e => e.tb_PolizaDetalle)
                .WithRequired(e => e.tb_TipoPersona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Usuario>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<tb_Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
