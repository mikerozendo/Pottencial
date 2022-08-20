using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IVendaService 
{
    Venda Post(Venda obj);
    IEnumerable<Venda> Get();
    Venda AlterarStatusVenda(int idVenda, int statusAlteracao);
    Venda GetById(int id);
}
