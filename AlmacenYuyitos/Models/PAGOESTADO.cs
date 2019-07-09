namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.PAGOESTADO")]
    public partial class PAGOESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAGOESTADO()
        {
            COMPROBANTE = new HashSet<COMPROBANTE>();
            HISTORIALCOMPRA = new HashSet<HISTORIALCOMPRA>();
        }

        [Key]
        public int ESTADOID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [StringLength(100)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPROBANTE> COMPROBANTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIALCOMPRA> HISTORIALCOMPRA { get; set; }
    }
}
