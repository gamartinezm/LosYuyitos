namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.COMUNA")]
    public partial class COMUNA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMUNA()
        {
            PERSONA = new HashSet<PERSONA>();
            PROVEEDOR = new HashSet<PROVEEDOR>();
        }

        public int COMUNAID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Display(Name = "REGION")]
        public int REGIONID { get; set; }

        public virtual REGION REGION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERSONA> PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROVEEDOR> PROVEEDOR { get; set; }
    }
}