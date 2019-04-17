namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.PROVEEDOR")]
    public partial class PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROVEEDOR()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        public decimal PROVEEDORID { get; set; }

        [Required]
        [StringLength(10)]
        public string RUT { get; set; }

        [Required]
        [StringLength(100)]
        public string RAZONSOCIAL { get; set; }

        public decimal? TELEFONO { get; set; }

        [StringLength(100)]
        public string MAIL { get; set; }

        [StringLength(50)]
        public string CONTACTO { get; set; }

        public decimal RUBROID { get; set; }

        [StringLength(100)]
        public string CALLE { get; set; }

        [StringLength(20)]
        public string NUMERO { get; set; }

        public decimal COMUNAID { get; set; }

        public virtual COMUNA COMUNA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }

        public virtual RUBRO RUBRO { get; set; }
    }
}
