namespace LosYuyitos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PORTAFOLIO.PERSONA")]
    public partial class PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERSONA()
        {
            CLIENTE = new HashSet<CLIENTE>();
            USUARIO = new HashSet<USUARIO>();
        }

        public int PERSONAID { get; set; }

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
        [StringLength(10)]
        public string RUT { get; set; }

        public int GENERO { get; set; }

        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [Display(Name = "FECHA NACIMIENTO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FECHANACIMIENTO { get; set; }

        [StringLength(100)]
        [Display(Name = "DIRECCION")]
        public string CALLE { get; set; }

        [StringLength(30)]
        public string NUMERO { get; set; }

        public int COMUNAID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }

        public virtual COMUNA COMUNA { get; set; }

        public virtual GENERO GENERO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }


        //public ObtenerRegionesComunas()
        //{
        //    RegionesList = new SelectList<(new list(String)>;



        //}

    }
}
