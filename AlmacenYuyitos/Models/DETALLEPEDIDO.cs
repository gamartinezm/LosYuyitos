namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.DETALLEPEDIDO")]
    public partial class DetallePedido
    {
        public int? CANTIDAD { get; set; }

        [Key]
        [Column(Order = 0)]
        public int TIPOPRODUCTO_TIPOPRODUCTOID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ORDENPEDIDO_ORDENPEDIDOID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FAMILIAPRODUCTOID { get; set; }

        public int? PRECIOCOMPRA { get; set; }

        public virtual OrdenPedido ORDENPEDIDO { get; set; }

        public virtual TipoProducto TIPOPRODUCTO { get; set; }

        public virtual FamiliaProducto FAMILIAPRODUCTO { get; set; }
    }
}
