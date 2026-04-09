using System;
using System.Collections.Generic;

namespace ApiGenericaCsharp.Models;

public partial class Universidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Ciudad { get; set; } = null!;
}
