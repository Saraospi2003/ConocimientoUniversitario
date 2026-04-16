using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class RegistroCalificado
{
    public int Codigo { get; set; }

    public string CantCred { get; set; } = null!;

    public string HoraAcom { get; set; } = null!;

    public string HoraInd { get; set; } = null!;

    public string Metodologia { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string DuracionAnios { get; set; } = null!;

    public string DuracionSemes { get; set; } = null!;

    public string TipoTitulacion { get; set; } = null!;

    public int Programa { get; set; }
}