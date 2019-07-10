namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.FAMILIAPRODUCTO")]
    public partial class FamiliaProducto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FamiliaProducto()
        {
            DETALLEPEDIDO = new HashSet<DetallePedido>();
            PRODUCTO = new HashSet<Producto>();
        }

        [Required]
        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        public int FAMILIAPRODUCTOID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DETALLEPEDIDO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> PRODUCTO { get; set; }
    }
}
