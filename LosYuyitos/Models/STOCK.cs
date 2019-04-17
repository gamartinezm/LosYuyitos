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
        public decimal INVENTARIOID { get; set; }

        public decimal PRODUCTOID { get; set; }

        public decimal? TOTAL { get; set; }

        public decimal STOCKCRITICO { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
