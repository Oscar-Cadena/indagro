using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Sku { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Unidad { get; set; }

    public string? Categoria { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Precio { get; set; }

    public double? Utilidad { get; set; }

    public decimal? CostoUsd { get; set; }

    public string? CotizacionProveedor { get; set; }

    public int? IdProveedor { get; set; }

    public string? Stock { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public bool? EsActivo { get; set; }
}
