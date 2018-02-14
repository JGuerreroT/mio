namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_PolizaDetalle
    {
        [Key]
        public int IdDetallePoliza { get; set; }

        public int IdPoliza { get; set; }

        public int IdPersona { get; set; }

        public int IdRelacionFamiliar { get; set; }

        public int IdSalud { get; set; }

        public decimal PorcentajeBeneficio { get; set; }

        public int IdTipoPensionista { get; set; }

        public int IdTipoPersona { get; set; }

        public virtual tb_Persona tb_Persona { get; set; }

        public virtual tb_Poliza tb_Poliza { get; set; }

        public virtual tb_RelacionFamiliar tb_RelacionFamiliar { get; set; }

        public virtual tb_Salud tb_Salud { get; set; }

        public virtual tb_TipoPensionista tb_TipoPensionista { get; set; }

        public virtual tb_TipoPersona tb_TipoPersona { get; set; }
    }
}
