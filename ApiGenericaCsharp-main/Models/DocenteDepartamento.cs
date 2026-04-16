using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class DocenteDepartamento
{
    public int Docente { get; set; }

    public int Departamento { get; set; }

    public string Dedicacion { get; set; } = null!;

    public string Modalidad { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaSalida { get; set; }
}