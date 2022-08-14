namespace Pottencial.Infraestructure.CrossCutting.JWT;

public class JwtConfiguration
{
    //Configurações hardcode, no appsettings.json seria muito facil de quem tem os arquivos de publicação fazer a leitura
    //Dessa forma a pessoa ainda teria que ter o trabalho de descompilar a minha dll;

    public string Key { get; set; } = "@@!!Pottencial!!TesteMichael##ffwwwrrdd";
    public string Issuer { get; set; } = "PottencialTesteMichelRozendo";
    public string Audience { get; set; } = "http://localhost";
    public DateTime ExpiresIn { get; set; } = DateTime.UtcNow.AddHours(2);
}
