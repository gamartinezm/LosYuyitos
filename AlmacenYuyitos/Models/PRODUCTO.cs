namespace AlmacenYuyitos.Models
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
            VENTADETALLE = new HashSet<VENTADETALLE>();
        }

        public int PRODUCTOID { get; set; }

        public int PRECIOVENTA { get; set; }

        public int PRECIOCOMPRA { get; set; }

        public int STOCK { get; set; }

        public int? STOCKCRITICO { get; set; }

        public int TIPOPRODUCTO_TIPOPRODUCTOID { get; set; }

        public DateTime FECHAVENCIMIENTO { get; set; }

        public int PROVEEDOR_PROVEEDORID { get; set; }

        public int FAMILIAPRODUCTOID { get; set; }

        public virtual FAMILIAPRODUCTO FAMILIAPRODUCTO { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }

        public virtual TIPOPRODUCTO TIPOPRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }
    }
}
