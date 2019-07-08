namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.ORDENPEDIDO")]
    public partial class ORDENPEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDENPEDIDO()
        {
            DETALLEPEDIDO = new HashSet<DETALLEPEDIDO>();
            HISTORIALORDEN = new HashSet<HISTORIALORDEN>();
        }

        public int ORDENPEDIDOID { get; set; }

        public DateTime FECHACREACION { get; set; }

        
        [StringLength(10)]
        public string ORDENESTADO_ESTADO { get; set; }

        public int PROVEEDOR_PROVEEDORID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLEPEDIDO> DETALLEPEDIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIALORDEN> HISTORIALORDEN { get; set; }

        public virtual ORDENESTADO ORDENESTADO { get; set; }

        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
