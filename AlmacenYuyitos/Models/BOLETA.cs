namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.BOLETA")]
    public partial class Boleta
    {
        public int BOLETAID { get; set; }

        public int LISTADOID { get; set; }

        public int VENTAID { get; set; }

        public virtual HistorialCompra HISTORIALCOMPRA { get; set; }
    }
}
