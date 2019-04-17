namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.COMPROBANTE")]
    public partial class COMPROBANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMPROBANTE()
        {
            HISTORIALCOMPRA = new HashSet<HISTORIALCOMPRA>();
        }

        public decimal COMPROBANTEID { get; set; }

        public decimal VENTADETALLEID { get; set; }

        public decimal TIPOPAGOID { get; set; }

        public DateTime FECHAEMISION { get; set; }

        public decimal ESTADOID { get; set; }

        public decimal USUARIOID { get; set; }

        public virtual PAGOESTADO PAGOESTADO { get; set; }

        public virtual TIPOPAGO TIPOPAGO { get; set; }

        public virtual USUARIO USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIALCOMPRA> HISTORIALCOMPRA { get; set; }

        public virtual VENTADETALLE VENTADETALLE { get; set; }
    }
}
