namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.DETALLEPEDIDO")]
    public partial class DETALLEPEDIDO
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

        public virtual ORDENPEDIDO ORDENPEDIDO { get; set; }

        public virtual TIPOPRODUCTO TIPOPRODUCTO { get; set; }

        public virtual FAMILIAPRODUCTO FAMILIAPRODUCTO { get; set; }
    }
}
