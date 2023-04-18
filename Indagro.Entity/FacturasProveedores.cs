using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class FacturasProveedores
{
    public int IdFacturaProveedor { get; set; }

    public string? NumeroFactura { get; set; }

    public int? IdOrdenCompra { get; set; }

    public int? IdProveedor { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Vence { get; set; }

    public string? Estado { get; set; }

    public decimal? Importe { get; set; }

    public string? Moneda { get; set; }

    public DateTime? FechaPago { get; set; }

    public string? Referencia { get; set; }

    public virtual OrdenCompra? IdOrdenCompraNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
