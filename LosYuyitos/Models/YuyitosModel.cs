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
                .Property(e => e.BOLETAID);

            modelBuilder.Entity<BOLETA>()
                .Property(e => e.LISTADOID);

            modelBuilder.Entity<BOLETA>()
                .Property(e => e.VENTAID);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.CATEGORIAID);                

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
                .Property(e => e.CLIENTEID);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.PERSONAID);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.CATEGORIAID);                

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.COMPROBANTEID);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.VENTADETALLEID);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.TIPOPAGOID);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.ESTADOID);

            modelBuilder.Entity<COMPROBANTE>()
                .Property(e => e.USUARIOID);                

            modelBuilder.Entity<COMPROBANTE>()
                .HasMany(e => e.HISTORIALCOMPRA)
                .WithRequired(e => e.COMPROBANTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.COMUNAID);                

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<COMUNA>()
                .Property(e => e.REGIONID);                

            modelBuilder.Entity<COMUNA>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMUNA>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .Property(e => e.TIPOPRODUCTOID);                

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILIAPRODUCTO>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.FAMILIAPRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENERO>()
                .Property(e => e.GENEROID);                

            modelBuilder.Entity<GENERO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<GENERO>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.GENERO1)
                .HasForeignKey(e => e.GENERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .Property(e => e.HISTORIALID);

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .Property(e => e.COMPROBANTEID);                

            modelBuilder.Entity<HISTORIALCOMPRA>()
                .HasMany(e => e.BOLETA)
                .WithRequired(e => e.HISTORIALCOMPRA)
                .HasForeignKey(e => e.LISTADOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDENESTADO>()
                .Property(e => e.ORDENESTADOID);                

            modelBuilder.Entity<ORDENESTADO>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDENESTADO>()
                .HasMany(e => e.ORDENPEDIDO)
                .WithRequired(e => e.ORDENESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ORDENPEDIDOID);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.PRODUCTOID);                

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<ORDENPEDIDO>()
                .Property(e => e.ORDENESTADOID);                

            modelBuilder.Entity<ORDENPEDIDO>()
                .HasMany(e => e.PRODUCTO)
                .WithMany(e => e.ORDENPEDIDO)
                .Map(m => m.ToTable("DETALLEPEDIDO", "YUYITOS").MapLeftKey("ORDENPEDIDOID").MapRightKey("PRODUCTOID"));

            modelBuilder.Entity<PAGOESTADO>()
                .Property(e => e.ESTADOID);                

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
                .Property(e => e.PERFILID);                

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
                .Property(e => e.PERSONAID);                

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
                .Property(e => e.GENERO);                

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONA>()
                .Property(e => e.COMUNAID);                

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.CLIENTE)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRODUCTOID);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.TIPOPRODUCTOID);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PROVEEDORID);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.MEDIDAID);                

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIOVENTA);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.PRECIOCOMPRA);                

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.STOCK)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.PROVEEDORID);                

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RAZONSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.TELEFONO);                

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.CONTACTO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.RUBROID);                

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<PROVEEDOR>()
                .Property(e => e.COMUNAID);                

            modelBuilder.Entity<PROVEEDOR>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.REGIONID);
                

            modelBuilder.Entity<REGION>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<REGION>()
                .Property(e => e.ORDEN);
                

            modelBuilder.Entity<REGION>()
                .HasMany(e => e.COMUNA)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RUBRO>()
                .Property(e => e.RUBROID);
                

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
                .Property(e => e.INVENTARIOID);


            modelBuilder.Entity<STOCK>()
                .Property(e => e.PRODUCTOID);


            modelBuilder.Entity<STOCK>()
                .Property(e => e.TOTAL);


            modelBuilder.Entity<STOCK>()
                .Property(e => e.STOCKCRITICO);


            modelBuilder.Entity<TIPOPAGO>()
                .Property(e => e.TIPOPAGOID);
                

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
                .Property(e => e.TIPOPRODUCTOID);
                

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
                .Property(e => e.USUARIOID);


            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PERSONAID);


            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PERFILID);
                

            modelBuilder.Entity<USUARIO>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.VENTADETALLEID);


            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.PRODUCTOID);
                

            modelBuilder.Entity<VENTADETALLE>()
                .Property(e => e.CLIENTEID);

            modelBuilder.Entity<VENTADETALLE>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.VENTADETALLE)
                .WillCascadeOnDelete(false);
        }
    }
}
