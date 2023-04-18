using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public string? NumeroOrden { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdVendedor { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Referencia { get; set; }

    public string? Moneda { get; set; }

    public string? Uso { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ICollection<FacturasProveedores> FacturasProveedores { get; set; } = new List<FacturasProveedores>();

    public virtual Cotizacion? IdCotizacionNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }

    public virtual ICollection<SeguimientoFactura> SeguimientoFacturas { get; set; } = new List<SeguimientoFactura>();
}
