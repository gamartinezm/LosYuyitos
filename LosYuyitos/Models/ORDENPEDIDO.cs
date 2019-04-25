namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.ORDENPEDIDO")]
    public partial class ORDENPEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDENPEDIDO()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        public int ORDENPEDIDOID { get; set; }

        public int PRODUCTOID { get; set; }

        public DateTime? FECHACREACION { get; set; }

        [StringLength(100)]
        public string ESTADO { get; set; }

        public int ORDENESTADOID { get; set; }

        public virtual ORDENESTADO ORDENESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
