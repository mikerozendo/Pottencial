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

    public int ObterQuantidade()
    {
        return vendas.Count;
    }

    public void Remove(Venda obj)
    {
        vendas.RemoveAll(x => x.Id == obj.Id);
    }
}
