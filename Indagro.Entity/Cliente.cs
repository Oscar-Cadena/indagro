using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Rfc { get; set; }

    public string? Calle { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Alias { get; set; }

    public virtual ICollection<ColaboradorCliente> ColaboradorClientes { get; set; } = new List<ColaboradorCliente>();

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<SeguimientoFactura> SeguimientoFacturas { get; set; } = new List<SeguimientoFactura>();
}
