namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.ORDENPEDIDO")]
    public partial class ORDENPEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDENPEDIDO()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        public decimal ORDENPEDIDOID { get; set; }

        public decimal PRODUCTOID { get; set; }

        public DateTime? FECHACREACION { get; set; }

        [StringLength(100)]
        public string ESTADO { get; set; }

        public decimal ORDENESTADOID { get; set; }

        public virtual ORDENESTADO ORDENESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
