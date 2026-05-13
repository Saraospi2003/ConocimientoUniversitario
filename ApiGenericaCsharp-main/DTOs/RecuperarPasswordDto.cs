namespace ApiGenericaCsharp.DTOs
{
    public class RecuperarPasswordDto
    {
        public string Correo { get; set; } = string.Empty;

        public string Codigo { get; set; } = string.Empty;

        public string NuevaPassword { get; set; } = string.Empty;
    }
}