using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Vendedor
{
    public int IdVendedor { get; set; }

    public int? IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
