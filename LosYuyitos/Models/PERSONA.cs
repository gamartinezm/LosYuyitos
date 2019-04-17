namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTAFOLIO.PERSONA")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            CLIENTE = new HashSet<CLIENTE>();
            USUARIO = new HashSet<USUARIO>();
        }

        public decimal PERSONAID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string APPATERNO { get; set; }

        [Required]
        [StringLength(50)]
        public string APMATERNO { get; set; }

        [Required]
        [StringLength(10)]
        public string RUT { get; set; }

        public decimal GENERO { get; set; }

        public DateTime? FECHANACIMIENTO { get; set; }

        [StringLength(100)]
        public string CALLE { get; set; }

        [StringLength(30)]
        public string NUMERO { get; set; }

        public decimal COMUNAID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }

        public virtual COMUNA COMUNA { get; set; }

        public virtual GENERO GENERO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
