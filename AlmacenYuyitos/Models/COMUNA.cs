namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.COMUNA")]
    public partial class Comuna
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comuna()
        {
            PERSONA = new HashSet<Persona>();
            PROVEEDOR = new HashSet<Proveedor>();
        }

        public int COMUNAID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Display(Name = "COMUNA")]
        public int REGIONID { get; set; }

        public virtual Region REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> PROVEEDOR { get; set; }
    }
}
