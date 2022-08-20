using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repositories;

namespace Pottencial.Infraestructure.Data.Repositories;

public class VendaRepository : IVendaRepository
{
    private List<Venda> vendas { get; set; } = new();

    public IEnumerable<Venda> Get(int id = 0)
    {
        if (id == 0) return vendas;

        return vendas.Where(x => x.Id == id);
    }

    public Venda Post(Venda obj)
    {
        vendas.Add(obj);
        return obj;
    }

    public Venda Put(Venda obj)
    {
        throw new NotImplementedException();
    }

    public void RemovePorId(int id)
    {
        //Usando remove all por conta da possibilidade de aplicar um lambda;
        vendas.RemoveAll(x => x.Id == id);
    }
}
