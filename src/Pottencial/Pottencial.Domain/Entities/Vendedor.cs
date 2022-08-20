namespace Pottencial.Domain.Entities;

public class Vendedor : Pessoa
{
    public List<Venda> Vendas { get; set; } = new();
    public Vendedor(string cpf) : base(cpf) { }
}
