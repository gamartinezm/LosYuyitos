namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.BOLETA")]
    public partial class BOLETA
    {
        public decimal BOLETAID { get; set; }

        public decimal LISTADOID { get; set; }

        public decimal VENTAID { get; set; }

        public virtual HISTORIALCOMPRA HISTORIALCOMPRA { get; set; }
    }
}
