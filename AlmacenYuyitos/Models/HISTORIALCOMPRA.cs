namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.HISTORIALCOMPRA")]
    public partial class HISTORIALCOMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HISTORIALCOMPRA()
        {
            BOLETA = new HashSet<BOLETA>();
        }

        [Key]
        public int HISTORIALID { get; set; }

        public int COMPROBANTEID { get; set; }

        public DateTime FECHAMODIFICACION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLETA> BOLETA { get; set; }

        public virtual COMPROBANTE COMPROBANTE { get; set; }
    }
}
