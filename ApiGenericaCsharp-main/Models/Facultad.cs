using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class Facultad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime FechaIn { get; set; }

    public int Universidad { get; set; }
}