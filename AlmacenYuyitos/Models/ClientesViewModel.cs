using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AlmacenYuyitos.Models
{
    public class ClientesViewModel
    {
        public int CLIENTEID { get; set; }

        public int PERSONAID { get; set; }

        public int CATEGORIAID { get; set; }

        public DateTime? FECHACREACION { get; set; }

        public virtual Categoria CATEGORIA { get; set; }

        public virtual Persona PERSONA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentaDetalle> VENTADETALLE { get; set; }
    }

}