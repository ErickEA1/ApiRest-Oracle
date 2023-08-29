using System;
using System.Collections.Generic;

namespace OracleDDD.Domain.Entities;

public partial class Producto
{
    public decimal Id { get; set; }

    public string? Nombreproducto { get; set; }

    public decimal? Codigobarras { get; set; }

    public decimal? Stock { get; set; }

    public decimal? Precio { get; set; }

    public string? Categoria { get; set; }
    public string? UrlImagen { get; set; }
    public string? Descripcion { get; set; }
}
