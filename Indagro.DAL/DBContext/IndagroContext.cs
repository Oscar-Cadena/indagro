using System;
using System.Collections.Generic;
using Indagro.Entity;
using Microsoft.EntityFrameworkCore;

namespace Indagro.DAL.DBContext;

public partial class IndagroContext : DbContext
{
    public IndagroContext()
    {
    }

    public IndagroContext(DbContextOptions<IndagroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ColaboradorCliente> ColaboradorClientes { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<DetalleCotizacion> DetalleCotizacions { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<FacturasProveedores> FacturasProveedores { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Negocio> Negocios { get; set; }

    public virtual DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<SeguimientoFactura> SeguimientoFacturas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EEA1FAA6B4");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Alias)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("alias");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
        });

        modelBuilder.Entity<ColaboradorCliente>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__A6A5C3967E8B6283");

            entity.ToTable("ColaboradorCliente");

            entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ColaboradorClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Colaborad__idCli__4E88ABD4");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.IdCotizacion).HasName("PK__Cotizaci__D931C39B01AC2225");

            entity.ToTable("Cotizacion");

            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.CondicionPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("condicionPago");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("formaPago");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Lab)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lab");
            entity.Property(e => e.Moneda)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("moneda");
            entity.Property(e => e.Notas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notas");
            entity.Property(e => e.NumeroCotizacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numeroCotizacion");
            entity.Property(e => e.Referencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Validez).HasColumnName("validez");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Cotizacio__idCli__534D60F1");

            entity.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.IdColaborador)
                .HasConstraintName("FK__Cotizacio__idCol__5441852A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Cotizacio__idUsu__52593CB8");
        });

        modelBuilder.Entity<DetalleCotizacion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCotizacion).HasName("PK__DetalleC__3152BA3DB202F8E9");

            entity.ToTable("DetalleCotizacion");

            entity.Property(e => e.IdDetalleCotizacion).HasColumnName("idDetalleCotizacion");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Categoria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Entrega)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("entrega");
            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.IdCotizacionProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idCotizacionProveedor");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Sku)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__DetalleCo__idCot__5DCAEF64");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.DetalleCotizacions)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__DetalleCo__idPro__5EBF139D");
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleOrdenCompra).HasName("PK__DetalleO__E7A3B83926961261");

            entity.ToTable("DetalleOrdenCompra");

            entity.Property(e => e.IdDetalleOrdenCompra).HasColumnName("idDetalleOrdenCompra");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Categoria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrdenCompra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Sku)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetalleOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .HasConstraintName("FK__DetalleOr__idOrd__74AE54BC");
        });

        modelBuilder.Entity<FacturasProveedores>(entity =>
        {
            entity.HasKey(e => e.IdFacturaProveedor).HasName("PK__Facturas__0D70DF9720DBB450");

            entity.Property(e => e.IdFacturaProveedor).HasColumnName("idFacturaProveedor");
            entity.Property(e => e.Estado)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaPago)
                .HasColumnType("date")
                .HasColumnName("fechaPago");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrdenCompra");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("importe");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("moneda");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("numeroFactura");
            entity.Property(e => e.Referencia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Vence)
                .HasColumnType("date")
                .HasColumnName("vence");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.FacturasProveedores)
                .HasForeignKey(d => d.IdOrdenCompra)
                .HasConstraintName("FK__FacturasP__idOrd__7B5B524B");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.FacturasProveedores)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__FacturasP__idPro__7C4F7684");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF483458AAB3F");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("paginaAccion");

            entity.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
                .HasForeignKey(d => d.IdMenuPadre)
                .HasConstraintName("FK__Menu__idMenuPadr__3A81B327");
        });

        modelBuilder.Entity<Negocio>(entity =>
        {
            entity.HasKey(e => e.IdNegocio).HasName("PK__Negocio__70E1E107858147B3");

            entity.ToTable("Negocio");

            entity.Property(e => e.IdNegocio)
                .ValueGeneratedNever()
                .HasColumnName("idNegocio");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Iva)
                .HasColumnType("decimal(2, 2)")
                .HasColumnName("IVA");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreLogo");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<NumeroCorrelativo>(entity =>
        {
            entity.HasKey(e => e.IdNumeroCorrelativo).HasName("PK__NumeroCo__25FB547E996F8722");

            entity.ToTable("NumeroCorrelativo");

            entity.Property(e => e.IdNumeroCorrelativo).HasColumnName("idNumeroCorrelativo");
            entity.Property(e => e.CantidadDigitos).HasColumnName("cantidadDigitos");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaActualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gestion");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimoNumero");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK__OrdenCom__543558842DE1BB34");

            entity.ToTable("OrdenCompra");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrdenCompra");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("moneda");
            entity.Property(e => e.NumeroOrden)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numeroOrden");
            entity.Property(e => e.Referencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Uso)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("uso");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__OrdenComp__idCot__6EF57B66");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__OrdenComp__idPro__6FE99F9F");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__OrdenComp__idUsu__6E01572D");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__OrdenComp__idVen__70DDC3D8");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A13273984CF9");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.CostoUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costoUSD");
            entity.Property(e => e.CotizacionProveedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cotizacionProveedor");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreImagen");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Sku)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Stock)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("stock");
            entity.Property(e => e.Unidad)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("unidad");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlImagen");
            entity.Property(e => e.Utilidad).HasColumnName("utilidad");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__A3FA8E6B3D0CFB84");

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Alias)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("alias");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Colonia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colonia");
            entity.Property(e => e.Credito).HasColumnName("credito");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("importe");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Plazo).HasColumnName("plazo");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.SaldoRestante)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("saldoRestante");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76EE75CD5E");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PK__RolMenu__CD2045D899C2A6EA");

            entity.ToTable("RolMenu");

            entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__RolMenu__idMenu__3F466844");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolMenu__idRol__3E52440B");
        });

        modelBuilder.Entity<SeguimientoFactura>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__1B37049CCC451BAF");

            entity.Property(e => e.IdSeguimiento).HasColumnName("idSeguimiento");
            entity.Property(e => e.Credito).HasColumnName("credito");
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAlmacen)
                .HasColumnType("date")
                .HasColumnName("fechaAlmacen");
            entity.Property(e => e.FechaReal)
                .HasColumnType("date")
                .HasColumnName("fechaReal");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrdenCompra");
            entity.Property(e => e.Importe)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("importe");
            entity.Property(e => e.Krea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("krea");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("moneda");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("numeroFactura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.SeguimientoFacturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Seguimien__idCli__787EE5A0");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.SeguimientoFacturas)
                .HasForeignKey(d => d.IdOrdenCompra)
                .HasConstraintName("FK__Seguimien__idOrd__778AC167");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A69604D88F");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreFoto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__4316F928");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.IdVendedor).HasName("PK__Vendedor__A6693F93B2CD0D4F");

            entity.ToTable("Vendedor");

            entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Vendedors)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Vendedor__idProv__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
