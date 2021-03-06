namespace AlmacenYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    using System.Linq;

    [Table("YUYITOS.PERSONA")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            CLIENTE = new HashSet<Cliente>();
            USUARIO = new HashSet<Usuario>();
        }

        public int PERSONAID { get; set; }

        [Required]
        [StringLength(10)]
        [Remote("ValidacionRut", "PERSONA", ErrorMessage = "RUT no valido")]
        public string RUT { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "APELLIDO PATERNO")]
        public string APPATERNO { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "APELLIDO MATERNO")]
        public string APMATERNO { get; set; }

        [Required]
        [Display(Name = "FECHA NACIMIENTO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FECHANACIMIENTO { get; set; }

        [Required]
        public int? TELEFONO { get; set; }

        [Required]
        public int GENERO { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "DIRECCION")]
        public string CALLE { get; set; }

        [Required]
        [StringLength(30)]
        public string NUMERO { get; set; }

        [StringLength(50)]
        public string COMPLEMENTO { get; set; }

        [Required]
        public int COMUNAID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> CLIENTE { get; set; }

        public virtual Comuna COMUNA { get; set; }

        public virtual Genero GENERO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> USUARIO { get; set; }
    }
}
