using System;
using System.Collections.Generic;

namespace ApiGenericaCsharp.Models;

public partial class AspectoNormativo
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Fuente { get; set; } = null!;
}
