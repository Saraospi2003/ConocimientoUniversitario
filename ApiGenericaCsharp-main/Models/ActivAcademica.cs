using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class ActivAcademica
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumCreditos { get; set; }

    public string Tipo { get; set; } = null!;

    public string AreaFormacion { get; set; } = null!;

    public int HAcom { get; set; }

    public int HIndep { get; set; }

    public string Idioma { get; set; } = null!;

    public string Espacio { get; set; } = null!;

    public string EntidadApoyo { get; set; } = null!;

    public string PaisEspejo { get; set; } = null!;

    public int Programa { get; set; }
}