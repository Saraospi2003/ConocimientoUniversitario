using System;
using System.Collections.Generic;
namespace ApiGenericaCsharp.Models;

public partial class Premio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string EntidadOtorgante { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public int Programa { get; set; }
}