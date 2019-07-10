namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.HISTORIALCOMPRA")]
    public partial class HistorialCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HistorialCompra()
        {
            BOLETA = new HashSet<Boleta>();
        }

        [Key]
        public int HISTORIALID { get; set; }

        public int COMPROBANTEID { get; set; }

        public DateTime FECHAMODIFICACION { get; set; }

        public int PAGOESTADO_ESTADOID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boleta> BOLETA { get; set; }

        public virtual Comprobante COMPROBANTE { get; set; }

        public virtual PagoEstado PAGOESTADO { get; set; }
    }
}