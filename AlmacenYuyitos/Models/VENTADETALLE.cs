namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.VENTADETALLE")]
    public partial class VENTADETALLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTADETALLE()
        {
            COMPROBANTE = new HashSet<COMPROBANTE>();
        }

        public int VENTADETALLEID { get; set; }

        //public Int64 PRODUCTOID { get; set; }

        public int CLIENTEID { get; set; }

        public Int64 PRODUCTO_PRODUCTOID { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPROBANTE> COMPROBANTE { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
