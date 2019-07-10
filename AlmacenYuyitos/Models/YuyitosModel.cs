namespace AlmacenYuyitos.Models
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

        //control + r + r

        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<FamiliaProducto> FamiliaProducto { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<HistorialCompra> HistorialCompra { get; set; }
        public virtual DbSet<HistorialOrden> HistorialOrden { get; set; }
        public virtual DbSet<OrdenEstado> OrdenEstado { get; set; }
        public virtual DbSet<OrdenPedido> OrdenPedido { get; set; }
        public virtual DbSet<PagoEstado> PagoEstado { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Rubro> Rubro { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleta>()
                .Property(e => e.BOLETAID);

            modelBuilder.Entity<Boleta>()
                .Property(e => e.LISTADOID);

            modelBuilder.Entity<Boleta>()
                .Property(e => e.VENTAID);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.CATEGORIAID);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.CLIENTE)
                .WithRequired(e => e.CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CLIENTEID);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.PERSONAID);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CATEGORIAID);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.COMPROBANTEID);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.TIPOPAGOID);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.ESTADOID);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.USUARIOID);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.TOTALCOMPRA);

            modelBuilder.Entity<Comprobante>()
                .Property(e => e.MONTOCANCELADO);

            modelBuilder.Entity<Comprobante>()
                .HasMany(e => e.HISTORIALCOMPRA)
                .WithRequired(e => e.COMPROBANTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comprobante>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.COMPROBANTE)
                .HasForeignKey(e => e.COMPROBANTE_COMPROBANTEID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comuna>()
                .Property(e => e.COMUNAID);

            modelBuilder.Entity<Comuna>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Comuna>()
                .Property(e => e.REGIONID);

            modelBuilder.Entity<Comuna>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comuna>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.COMUNA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.CANTIDAD);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.TIPOPRODUCTO_TIPOPRODUCTOID);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.ORDENPEDIDO_ORDENPEDIDOID);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.FAMILIAPRODUCTOID);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.PRECIOCOMPRA);

            modelBuilder.Entity<FamiliaProducto>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliaProducto>()
                .Property(e => e.FAMILIAPRODUCTOID);

            modelBuilder.Entity<FamiliaProducto>()
                .HasMany(e => e.DETALLEPEDIDO)
                .WithRequired(e => e.FAMILIAPRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliaProducto>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.FAMILIAPRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.GENEROID);

            modelBuilder.Entity<Genero>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.PERSONA)
                .WithRequired(e => e.GENERO1)
                .HasForeignKey(e => e.GENERO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HistorialCompra>()
                .Property(e => e.HISTORIALID);

            modelBuilder.Entity<HistorialCompra>()
                .Property(e => e.COMPROBANTEID);

            modelBuilder.Entity<HistorialCompra>()
                .Property(e => e.PAGOESTADO_ESTADOID);

            modelBuilder.Entity<HistorialCompra>()
                .HasMany(e => e.BOLETA)
                .WithRequired(e => e.HISTORIALCOMPRA)
                .HasForeignKey(e => e.LISTADOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HistorialOrden>()
                .Property(e => e.HISTORIALORDENID);

            modelBuilder.Entity<HistorialOrden>()
                .Property(e => e.OBSERVACION)
                .IsUnicode(false);

            modelBuilder.Entity<HistorialOrden>()
                .Property(e => e.ORDENESTADO_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HistorialOrden>()
                .Property(e => e.ORDENPEDIDO_ORDENPEDIDOID);

            modelBuilder.Entity<OrdenEstado>()
                .Property(e => e.ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OrdenEstado>()
                .HasMany(e => e.HISTORIALORDEN)
                .WithRequired(e => e.ORDENESTADO)
                .HasForeignKey(e => e.ORDENESTADO_ESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdenEstado>()
                .HasMany(e => e.ORDENPEDIDO)
                .WithRequired(e => e.ORDENESTADO)
                .HasForeignKey(e => e.ORDENESTADO_ESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdenPedido>()
                .Property(e => e.ORDENPEDIDOID);

            modelBuilder.Entity<OrdenPedido>()
                .Property(e => e.ORDENESTADO_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OrdenPedido>()
                .Property(e => e.PROVEEDOR_PROVEEDORID);

            modelBuilder.Entity<OrdenPedido>()
                .HasMany(e => e.DETALLEPEDIDO)
                .WithRequired(e => e.ORDENPEDIDO)
                .HasForeignKey(e => e.ORDENPEDIDO_ORDENPEDIDOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdenPedido>()
                .HasMany(e => e.HISTORIALORDEN)
                .WithRequired(e => e.ORDENPEDIDO)
                .HasForeignKey(e => e.ORDENPEDIDO_ORDENPEDIDOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PagoEstado>()
                .Property(e => e.ESTADOID);

            modelBuilder.Entity<PagoEstado>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PagoEstado>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PagoEstado>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.PAGOESTADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PagoEstado>()
                .HasMany(e => e.HISTORIALCOMPRA)
                .WithRequired(e => e.PAGOESTADO)
                .HasForeignKey(e => e.PAGOESTADO_ESTADOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.PERFILID);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.PERFIL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.PERSONAID);

            modelBuilder.Entity<Persona>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.APPATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.APMATERNO)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.TELEFONO);

            modelBuilder.Entity<Persona>()
                .Property(e => e.GENERO);

            modelBuilder.Entity<Persona>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.COMUNAID);

            modelBuilder.Entity<Persona>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.CLIENTE)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.USUARIO)
                .WithRequired(e => e.PERSONA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PRODUCTOID);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PRECIOVENTA);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PRECIOCOMPRA);

            modelBuilder.Entity<Producto>()
                .Property(e => e.STOCK);

            modelBuilder.Entity<Producto>()
                .Property(e => e.STOCKCRITICO);

            modelBuilder.Entity<Producto>()
                .Property(e => e.TIPOPRODUCTO_TIPOPRODUCTOID);

            modelBuilder.Entity<Producto>()
                .Property(e => e.PROVEEDOR_PROVEEDORID);

            modelBuilder.Entity<Producto>()
                .Property(e => e.FAMILIAPRODUCTOID);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.VENTADETALLE)
                .WithRequired(e => e.PRODUCTO)
                .HasForeignKey(e => e.PRODUCTO_PRODUCTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.PROVEEDORID);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.RUT)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.RAZONSOCIAL)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.TELEFONO);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.CONTACTO)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.RUBROID);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.CALLE)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.NUMERO)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.COMUNAID);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.COMPLEMENTO)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.ORDENPEDIDO)
                .WithRequired(e => e.PROVEEDOR)
                .HasForeignKey(e => e.PROVEEDOR_PROVEEDORID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.PROVEEDOR)
                .HasForeignKey(e => e.PROVEEDOR_PROVEEDORID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.REGIONID);

            modelBuilder.Entity<Region>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.ORDEN);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.COMUNA)
                .WithRequired(e => e.REGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rubro>()
                .Property(e => e.RUBROID);

            modelBuilder.Entity<Rubro>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<Rubro>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<Rubro>()
                .HasMany(e => e.PROVEEDOR)
                .WithRequired(e => e.RUBRO)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<TipoPago>()
                .Property(e => e.TIPOPAGOID);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPago>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.TIPOPAGO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.TIPOPRODUCTOID);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.MEDIDA);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.UNIDADMEDIDA)
                .IsUnicode(false);

            modelBuilder.Entity<TipoProducto>()
                .HasMany(e => e.DETALLEPEDIDO)
                .WithRequired(e => e.TIPOPRODUCTO)
                .HasForeignKey(e => e.TIPOPRODUCTO_TIPOPRODUCTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoProducto>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.TIPOPRODUCTO)
                .HasForeignKey(e => e.TIPOPRODUCTO_TIPOPRODUCTOID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.USUARIOID);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PERSONAID);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PERFILID);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PERSONA_RUT)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.COMPROBANTE)
                .WithRequired(e => e.USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentaDetalle>()
                .Property(e => e.VENTADETALLEID);

            modelBuilder.Entity<VentaDetalle>()
                .Property(e => e.CLIENTEID);

            modelBuilder.Entity<VentaDetalle>()
                .Property(e => e.PRODUCTO_PRODUCTOID);

            modelBuilder.Entity<VentaDetalle>()
                .Property(e => e.COMPROBANTE_COMPROBANTEID);
        }
    }
}