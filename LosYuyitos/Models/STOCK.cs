namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.STOCK")]
    public partial class STOCK
    {
        [Key]
        public int INVENTARIOID { get; set; }

        public int PRODUCTOID { get; set; }

        public int? TOTAL { get; set; }

        public int STOCKCRITICO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
