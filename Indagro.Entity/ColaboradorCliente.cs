using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class ColaboradorCliente
{
    public int IdColaborador { get; set; }

    public int? IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
