using System;
using System.Collections.Generic;

namespace Indagro.Entity;

public partial class Negocio
{
    public int IdNegocio { get; set; }

    public string? UrlLogo { get; set; }

    public string? NombreLogo { get; set; }

    public string? Nombre { get; set; }

    public string? Rfc { get; set; }

    public string? Correo { get; set; }

    public string? Calle { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Telefono { get; set; }

    public decimal? Iva { get; set; }
}
