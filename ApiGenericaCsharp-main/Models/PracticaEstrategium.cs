using System;
using System.Collections.Generic;

namespace ApiGenericaCsharp.Models;

public partial class PracticaEstrategium
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
