namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.VENTADETALLE")]
    public partial class VENTADETALLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTADETALLE()
        {
            COMPROBANTE = new HashSet<COMPROBANTE>();
        }

        public decimal VENTADETALLEID { get; set; }

        public decimal PRODUCTOID { get; set; }

        public decimal CLIENTEID { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPROBANTE> COMPROBANTE { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
