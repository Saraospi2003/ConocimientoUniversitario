using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class Acreditacion
{
    public int Resolucion { get; set; }

    public string Tipo { get; set; } = null!;

    public string Calificacion { get; set; } = null!;

    public string FechaInicio { get; set; } = null!;

    public string FechaFin { get; set; } = null!;

    public int Programa { get; set; }
}