using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class Alianza
{
    public int Id { get; set; }

    public int Departamento { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public int Docente { get; set; }
}