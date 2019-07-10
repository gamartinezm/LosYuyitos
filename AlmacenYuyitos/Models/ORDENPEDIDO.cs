namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.ORDENPEDIDO")]
    public partial class OrdenPedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdenPedido()
        {
            DETALLEPEDIDO = new HashSet<DetallePedido>();
            HISTORIALORDEN = new HashSet<HistorialOrden>();
        }

        public int ORDENPEDIDOID { get; set; }

        public DateTime FECHACREACION { get; set; }

        
        [StringLength(10)]
        public string ORDENESTADO_ESTADO { get; set; }

        public int PROVEEDOR_PROVEEDORID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DETALLEPEDIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialOrden> HISTORIALORDEN { get; set; }

        public virtual OrdenEstado ORDENESTADO { get; set; }

        public virtual Proveedor PROVEEDOR { get; set; }
    }
}
