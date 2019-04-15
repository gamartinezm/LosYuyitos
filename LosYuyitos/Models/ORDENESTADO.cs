namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.ORDENESTADO")]
    public partial class ORDENESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDENESTADO()
        {
            ORDENPEDIDO = new HashSet<ORDENPEDIDO>();
        }

        public decimal ORDENESTADOID { get; set; }

        [StringLength(5)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDENPEDIDO> ORDENPEDIDO { get; set; }
    }
}
