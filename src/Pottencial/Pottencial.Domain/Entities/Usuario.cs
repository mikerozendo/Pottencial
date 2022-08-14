using System.Text;
using System.Security.Cryptography;

namespace Pottencial.Domain.Entities;

public class Usuario : Pessoa
{
    public string Email { get; set; }
    public string Senha { get; private set; }

    public Usuario(string email, string senha)
    {
        Email = email;
        Senha = senha;

        if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Senha))
            GerarSenhaHasheada(Senha);
    }

    private void GerarSenhaHasheada(string senha)
    {
        //gerar senha hasheada para persistencia no db;
        //Senha = Senha hasheada;

        StringBuilder Sb = new StringBuilder();

        using SHA256 hash = SHA256.Create();
        Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

        foreach (Byte b in result)
            Sb.Append(b.ToString("x2"));

        Senha = Sb.ToString();
    }

    public override bool Equals(object? obj)
    {
        //Equals utilizado p/ comparacao entre a base de dados e objeto de login recebido da API;
        Usuario? comparer = obj as Usuario;
        if (comparer is null) return false;

        return Email.ToLower() == comparer.Email.ToLower() &&
            Senha == comparer.Senha;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
