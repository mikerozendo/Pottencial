using Pottencial.Domain.ValueObjects;

namespace Pottencial.Domain.Entities;

public class Pessoa : Base
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public CPF CPF { get; set; }
}
