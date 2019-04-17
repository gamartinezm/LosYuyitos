namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.TIPOPRODUCTO")]
    public partial class TIPOPRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPOPRODUCTO()
        {
            PRODUCTO = new HashSet<PRODUCTO>();
        }

        public int TIPOPRODUCTOID { get; set; }

        [StringLength(30)]
        public string TIPO { get; set; }

        [StringLength(30)]
        public string NOMBRE { get; set; }

        [StringLength(5)]
        public string ABREVIATURA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}
