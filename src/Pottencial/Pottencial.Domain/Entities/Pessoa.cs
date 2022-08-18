using Pottencial.Domain.ValueObjects;

namespace Pottencial.Domain.Entities;

public class Pessoa : Base
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public CPF CPF { get; set; }

    public Pessoa()
    {

    }

    public Pessoa(string cpf)
    {
        CPF = new(cpf);
    }
}
