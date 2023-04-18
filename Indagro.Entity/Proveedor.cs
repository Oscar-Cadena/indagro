using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Rfc { get; set; }

    public string? Calle { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Alias { get; set; }

    public bool? Credito { get; set; }

    public int? Plazo { get; set; }

    public decimal? Importe { get; set; }

    public decimal? SaldoRestante { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual ICollection<FacturasProveedores> FacturasProveedores { get; set; } = new List<FacturasProveedores>();

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();

    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
}
