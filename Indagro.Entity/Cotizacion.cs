using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Cotizacion
{
    public int IdCotizacion { get; set; }

    public string? NumeroCotizacion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public int? IdColaborador { get; set; }

    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? FormaPago { get; set; }

    public string? CondicionPago { get; set; }

    public int? Validez { get; set; }

    public string? Lab { get; set; }

    public string? Moneda { get; set; }

    public string? Descripcion { get; set; }

    public string? Notas { get; set; }

    public string? Estatus { get; set; }

    public string? Referencia { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ColaboradorCliente? IdColaboradorNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}
