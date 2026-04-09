using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGenericaCsharp.Models;

public partial class Aliado
{
    [Column("nit")]
    public long Nit { get; set; }

    [Column("razon_social")]
    public string RazonSocial { get; set; } = null!;

    [Column("nombre_contacto")]
    public string NombreContacto { get; set; } = null!;

    [Column("correo")]
    public string Correo { get; set; } = null!;

    [Column("telefono")]
    public string Telefono { get; set; } = null!;

    [Column("ciudad")]
    public string Ciudad { get; set; } = null!;
}