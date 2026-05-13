namespace ApiGenericaCsharp.DTOs;

public class ProgramaMaestroDetalleDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = "";

    public string Tipo { get; set; } = "";

    public string Nivel { get; set; } = "";

    public string? FechaCreacion { get; set; }

    public string? FechaCierre { get; set; }

    public int? NumCohortes { get; set; }

    public int? CantGraduados { get; set; }

    public string? FechaActualizacion { get; set; }

    public string Ciudad { get; set; } = "";

    public int? Facultad { get; set; }

    public List<AcreditacionDetalleDto> Acreditaciones { get; set; } = new();
}

public class AcreditacionDetalleDto
{
    public string Resolucion { get; set; } = "";

    public string Tipo { get; set; } = "";

    public string Calificacion { get; set; } = "";

    public string? FechaInicio { get; set; }

    public string? FechaFin { get; set; }
}