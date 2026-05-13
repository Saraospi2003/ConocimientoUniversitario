using System;

namespace ApiGenericaCsharp.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string? CodigoRecuperacion { get; set; }

    public DateTime? ExpiracionCodigo { get; set; }
}