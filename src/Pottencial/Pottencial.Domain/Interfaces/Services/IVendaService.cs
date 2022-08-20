using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Services;

public interface IVendaService : IBaseService<Venda>
{
    Venda AlterarStatusVenda(int idVenda, int statusAlteracao);
}
