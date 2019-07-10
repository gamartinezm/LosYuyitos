namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.HISTORIALORDEN")]
    public partial class HistorialOrden
    {
        public int HISTORIALORDENID { get; set; }

        [Required]
        [StringLength(100)]
        public string OBSERVACION { get; set; }

        public DateTime FECHOPERACION { get; set; }

        [Required]
        [StringLength(10)]
        public string ORDENESTADO_ESTADO { get; set; }

        public int ORDENPEDIDO_ORDENPEDIDOID { get; set; }

        public virtual OrdenEstado ORDENESTADO { get; set; }

        public virtual OrdenPedido ORDENPEDIDO { get; set; }
    }
}
