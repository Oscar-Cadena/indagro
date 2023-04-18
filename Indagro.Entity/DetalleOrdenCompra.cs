using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class DetalleOrdenCompra
{
    public int IdDetalleOrdenCompra { get; set; }

    public int? IdOrdenCompra { get; set; }

    public int? IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Sku { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Total { get; set; }

    public virtual OrdenCompra? IdOrdenCompraNavigation { get; set; }
}
