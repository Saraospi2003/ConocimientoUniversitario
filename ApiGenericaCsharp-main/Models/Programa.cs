using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class Programa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public string FechaCreacion { get; set; } = null!;

    public string FechaCierre { get; set; } = null!;

    public string NumCohortes { get; set; } = null!;

    public string CantGraduados { get; set; } = null!;

    public string FechaActualizacion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public int Facultad { get; set; }
}