using System;
using System.Collections.Generic;

namespace ApiGenericaCsharp.Models;

public partial class Enfoque
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
