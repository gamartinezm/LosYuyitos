namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.COMPROBANTE")]
    public partial class COMPROBANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPROBANTE()
        {
            HISTORIALCOMPRA = new HashSet<HISTORIALCOMPRA>();
            VENTADETALLE = new HashSet<VENTADETALLE>();
        }

        public int COMPROBANTEID { get; set; }

        public int TIPOPAGOID { get; set; }

        public DateTime FECHAEMISION { get; set; }

        public int ESTADOID { get; set; }

        public int USUARIOID { get; set; }

        public int? TOTALCOMPRA { get; set; }

        public int? MONTOCANCELADO { get; set; }

        public virtual PAGOESTADO PAGOESTADO { get; set; }

        public virtual TIPOPAGO TIPOPAGO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIALCOMPRA> HISTORIALCOMPRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }
    }
}
