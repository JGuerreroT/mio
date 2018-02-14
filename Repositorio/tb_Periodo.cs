namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Periodo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Periodo()
        {
            tb_EdadMaxima = new HashSet<tb_EdadMaxima>();
            tb_FactorSeguridad = new HashSet<tb_FactorSeguridad>();
            tb_Foto = new HashSet<tb_Foto>();
            tb_Poliza = new HashSet<tb_Poliza>();
            tb_TasaAnclaje = new HashSet<tb_TasaAnclaje>();
            tb_TasaMercado = new HashSet<tb_TasaMercado>();
            tb_TipoCambio = new HashSet<tb_TipoCambio>();
        }

        [Key]
        public int IdPeriodo { get; set; }

        [Required]
        [StringLength(2)]
        public string Mes { get; set; }

        [Required]
        [StringLength(4)]
        public string Anio { get; set; }

        public int IdEstado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_EdadMaxima> tb_EdadMaxima { get; set; }

        public virtual tb_Estado tb_Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_FactorSeguridad> tb_FactorSeguridad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Foto> tb_Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Poliza> tb_Poliza { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TasaAnclaje> tb_TasaAnclaje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TasaMercado> tb_TasaMercado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TipoCambio> tb_TipoCambio { get; set; }
    }
}
