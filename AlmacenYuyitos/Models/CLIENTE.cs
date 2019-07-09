namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YUYITOS.CLIENTE")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            VENTADETALLE = new HashSet<VENTADETALLE>();
        }

        [Display(Name = "CODIGO")]
        public int CLIENTEID { get; set; }

        [Display(Name = "RUT CLIENTE")]
        public int PERSONAID { get; set; }

        [Display(Name = "ESTADO")]
        public int CATEGORIAID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FECHACREACION { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTADETALLE> VENTADETALLE { get; set; }
    }
}
