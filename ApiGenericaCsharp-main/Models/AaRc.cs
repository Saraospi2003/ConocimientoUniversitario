using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class AaRc
{
    public int ActivAcademica { get; set; }

    public int RegistroCalificado { get; set; }

    public string Componente { get; set; } = null!;

    public string Semestre { get; set; } = null!;
}