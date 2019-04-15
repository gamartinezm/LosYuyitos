namespace LosYuyitos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class YuyitosModel : DbContext
    {
        public YuyitosModel()
            : base("name=YuyitosModel")
        {
        }

        public virtual DbSet<BOLETA> BOLETA { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<CLIENTE> CLIENTE { get; set; }
        public virtual DbSet<COMPROBANTE> COMPROBANTE { get; set; }
        public virtual DbSet<COMUNA> COMUNA { get; set; }
        public virtual DbSet<FAMILIAPRODUCTO> FAMILIAPRODUCTO { get; set; }
        public virtual DbSet<GENERO> GENERO { get; set; }
        public virtual DbSet<HISTORIALCOMPRA> HISTORIALCOMPRA { get; set; }
        public virtual DbSet<ORDENESTADO> ORDENESTADO { get; set; }
        public virtual DbSet<ORDENPEDIDO> ORDENPEDIDO { get; set; }
        public virtual DbSet<PAGOESTADO> PAGOESTADO { get; set; }
        public virtual DbSet<PERFIL> PERFIL { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<PROVEEDOR> PROVEEDOR { get; set; }
        public virtual DbSet<REGION> REGION { get; set; }
        public virtual DbSet<RUBRO> RUBRO { get; set; }
        public virtual DbSet<STOCK> STOCK { get; set; }
        public virtual DbSet<TIPOPAGO> TIPOPAGO { get; set; }
        public virtual DbSet<TIPOPRODUCTO> TIPOPRODUCTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VENTADETALLE> VENTADETALLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOLETA>()
                .Property(e => e.BOLETAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BOLETA>()
                .Property(e => e.LISTADOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BOLETA>()
                .Property(e => e.VENTAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.CATEGORIAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .HasMany(e => e.CLIENTE)
                .WithRequired(e => e.CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CLIENTEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.PERSONAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CATEGORIAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.COMPROBANTEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.VENTADETALLEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.TIPOPAGOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.ESTADOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.USUARIOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMPROBANTE>()
                .HasMany(e => e.HISTORIALCOMPRA)
                .WithRequired(e => e.COMPROBANTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.COMUNAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.REGIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COMUNA>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMUNA>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .Property(e => e.TIPOPRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.FAMILIAPRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENERO>()
                .Property(e => e.GENEROID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<GENERO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<GENERO>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.GENERO1)
                .HasForeignKey(e => e.GENERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .Property(e => e.HISTORIALID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .Property(e => e.COMPROBANTEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .HasMany(e => e.BOLETA)
                .WithRequired(e => e.HISTORIALCOMPRA)
                .HasForeignKey(e => e.LISTADOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDENESTADO>()
                .Property(e => e.ORDENESTADOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ORDENESTADO>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDENESTADO>()
                .HasMany(e => e.ORDENPEDIDO)
                .WithRequired(e => e.ORDENESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ORDENPEDIDOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.PRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ORDENESTADOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ORDENPEDIDO>()
                .HasMany(e => e.PRODUCTO)
                .WithMany(e => e.ORDENPEDIDO)
                .Map(m => m.ToTable("DETALLEPEDIDO", "PORTAFOLIO").MapLeftKey("ORDENPEDIDOID").MapRightKey("PRODUCTOID"));

            modelBuilder.Entity<PAGOESTADO>()
                .Property(e => e.ESTADOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PAGOESTADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PAGOESTADO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PAGOESTADO>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.PAGOESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERFIL>()
                .Property(e => e.PERFILID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PERFIL>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PERFIL>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PERFIL>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.PERFIL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.PERSONAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.APPATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.APMATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.GENERO)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.COMUNAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.CLIENTE)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.TIPOPRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PROVEEDORID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.MEDIDAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIOVENTA)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIOCOMPRA)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.STOCK)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.PROVEEDORID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RAZONSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.TELEFONO)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.CONTACTO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RUBROID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.COMUNAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<PROVEEDOR>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REGION>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.ORDEN)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REGION>()
                .HasMany(e => e.COMUNA)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RUBRO>()
                .Property(e => e.RUBROID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RUBRO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<RUBRO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<RUBRO>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.RUBRO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.INVENTARIOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.PRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.TOTAL)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STOCK>()
                .Property(e => e.STOCKCRITICO)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TIPOPAGO>()
                .Property(e => e.TIPOPAGOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TIPOPAGO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOPAGO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOPAGO>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.TIPOPAGO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TIPOPRODUCTO>()
                .Property(e => e.TIPOPRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<TIPOPRODUCTO>()
                .Property(e => e.TIPO)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOPRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOPRODUCTO>()
                .Property(e => e.ABREVIATURA)
                .IsUnicode(false);

            modelBuilder.Entity<TIPOPRODUCTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.TIPOPRODUCTO)
                .HasForeignKey(e => e.MEDIDAID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USUARIOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PERSONAID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PERFILID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.VENTADETALLEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.PRODUCTOID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.CLIENTEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VENTADETALLE>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.VENTADETALLE)
                .WillCascadeOnDelete(false);
        }
    }
}
