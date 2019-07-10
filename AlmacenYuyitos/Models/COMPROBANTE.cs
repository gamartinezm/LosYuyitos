namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.COMPROBANTE")]
    public partial class Comprobante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comprobante()
        {
            HISTORIALCOMPRA = new HashSet<HistorialCompra>();
            VENTADETALLE = new HashSet<VentaDetalle>();
        }

        public int COMPROBANTEID { get; set; }

        public int TIPOPAGOID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FECHAEMISION { get; set; }

        public int ESTADOID { get; set; }

        public int USUARIOID { get; set; }

        public int? TOTALCOMPRA { get; set; }

        public int? MONTOCANCELADO { get; set; }

        public virtual PagoEstado PAGOESTADO { get; set; }

        public virtual TipoPago TIPOPAGO { get; set; }

        public virtual Usuario USUARIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialCompra> HISTORIALCOMPRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDetalle> VENTADETALLE { get; set; }
    }
}