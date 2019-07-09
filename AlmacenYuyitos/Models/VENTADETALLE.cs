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
        public int VENTADETALLEID { get; set; }

        public int CLIENTEID { get; set; }

        public Int64 PRODUCTO_PRODUCTOID { get; set; }

        public int COMPROBANTE_COMPROBANTEID { get; set; }

        public virtual Cliente CLIENTE { get; set; }

        public virtual COMPROBANTE COMPROBANTE { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}