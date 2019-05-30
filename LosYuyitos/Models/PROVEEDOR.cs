namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.PROVEEDOR")]
    public partial class PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDOR()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        public int PROVEEDORID { get; set; }

        [Required]
        [StringLength(10)]
        public string RUT { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "RAZON SOCIAL")]
        public string RAZONSOCIAL { get; set; }

        public int? TELEFONO { get; set; }

        [StringLength(100)]
        public string MAIL { get; set; }

        [StringLength(50)]
        public string CONTACTO { get; set; }

        public int RUBROID { get; set; }

        [StringLength(100)]
        [Display(Name = "DIRECCION")]
        public string CALLE { get; set; }

        [StringLength(20)]
        public string NUMERO { get; set; }

        public int COMUNAID { get; set; }

        public virtual COMUNA COMUNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        public virtual RUBRO RUBRO { get; set; }

        //[StringLength(50)]
        //[Display(Name = "WEB")]

        //public string SITIOWEB { get; set; }
    }
}
