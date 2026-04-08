using System;
using System.Collections.Generic;

namespace ApiGenericaCsharp.Models;

public partial class CarInnovacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;
}
