namespace ApiGenericaCsharp.DTOs;

public class ProgramaAcreditacionDto
{
    public int ProgramaId { get; set; }

    public string? NombrePrograma { get; set; }

    public string? TipoPrograma { get; set; }

    public string? NivelPrograma { get; set; }

    public string? CiudadPrograma { get; set; }

    public int? FacultadId { get; set; }

    public int? ResolucionAcreditacion { get; set; }

    public string? TipoAcreditacion { get; set; }

    public string? Calificacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }
}