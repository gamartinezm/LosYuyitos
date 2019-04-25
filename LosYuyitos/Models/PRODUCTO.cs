namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            STOCK = new HashSet<STOCK>();
            VENTADETALLE = new HashSet<VENTADETALLE>();
            ORDENPEDIDO = new HashSet<ORDENPEDIDO>();
        }

        public int PRODUCTOID { get; set; }

        public int TIPOPRODUCTOID { get; set; }

        public int PROVEEDORID { get; set; }

        public int MEDIDAID { get; set; }

        [Required]
        [StringLength(100)]
        public string DESCRIPCION { get; set; }

        public int? PRECIOVENTA { get; set; }

        public int PRECIOCOMPRA { get; set; }

        public DateTime? FECHAVENCIMIENTO { get; set; }

        public virtual FAMILIAPRODUCTO FAMILIAPRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK> STOCK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }

        public virtual TIPOPRODUCTO TIPOPRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDENPEDIDO> ORDENPEDIDO { get; set; }
    }
}
