namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Sexo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Sexo()
        {
            tb_Persona = new HashSet<tb_Persona>();
        }

        [Key]
        public int IdSexo { get; set; }

        [Required]
        [StringLength(10)]
        public string DescripcionSexo { get; set; }

        [Required]
        [StringLength(10)]
        public string ResumenSexo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Persona> tb_Persona { get; set; }
    }
}
