using System.Net;
using System.Net.Mail;

namespace ApiGenericaCsharp.Services;

public class CorreoService
{
    private readonly IConfiguration _configuration;

    public CorreoService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarCodigo(string destino, string codigo)
    {
        var email = _configuration["Correo:Email"];
        var password = _configuration["Correo:Password"];

        var cliente = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(email, password),
            EnableSsl = true
        };

        var mensaje = new MailMessage
        {
            From = new MailAddress(email!),
            Subject = "Código de recuperación de contraseña",
            Body = $"Tu código de recuperación es: {codigo}"
        };

        mensaje.To.Add(destino);

        await cliente.SendMailAsync(mensaje);
    }
}