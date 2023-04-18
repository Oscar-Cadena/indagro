using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class DetalleCotizacion
{
    public int IdDetalleCotizacion { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Sku { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public string? Entrega { get; set; }

    public string? IdCotizacionProveedor { get; set; }

    public int? IdProveedor { get; set; }

    public virtual Cotizacion? IdCotizacionNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
