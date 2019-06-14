namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            COMPROBANTE = new HashSet<COMPROBANTE>();
        }

        public int USUARIOID { get; set; }

        public int PERSONAID { get; set; }

        public int PERFILID { get; set; }

        [Required]
        [StringLength(10)]
        public string PERSONA_RUT { get; set; }

        [Required]
        [StringLength(25)]
        public string PASSWORD { get; set; }

        [StringLength(25)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPROBANTE> COMPROBANTE { get; set; }

        public virtual PERFIL PERFIL { get; set; }

        public virtual PERSONA PERSONA { get; set; }
    }
}
