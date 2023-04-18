using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class SeguimientoFactura
{
    public int IdSeguimiento { get; set; }

    public string? NumeroFactura { get; set; }

    public int? IdOrdenCompra { get; set; }

    public int? IdCliente { get; set; }

    public string? Estado { get; set; }

    public decimal? Importe { get; set; }

    public string? Moneda { get; set; }

    public DateTime? FechaAlmacen { get; set; }

    public int? Credito { get; set; }

    public DateTime? FechaReal { get; set; }

    public string? Krea { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual OrdenCompra? IdOrdenCompraNavigation { get; set; }
}
