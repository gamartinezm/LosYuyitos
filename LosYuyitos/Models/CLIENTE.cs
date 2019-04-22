namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.CLIENTE")]
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            VENTADETALLE = new HashSet<VENTADETALLE>();
        }

        public int CLIENTEID { get; set; }

        public int PERSONAID { get; set; }

        public int CATEGORIAID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd / MM / yyyy HH: mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? FECHACREACION { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }
    }
}
