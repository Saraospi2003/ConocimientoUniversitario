namespace ApiGenericaCsharp.DTOs
{
    public class CambiarPasswordDto
    {
        public string Correo { get; set; } = string.Empty;

        public string PasswordActual { get; set; } = string.Empty;

        public string PasswordNueva { get; set; } = string.Empty;
    }
}