using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IVendaRepository : IBaseQueryRepository<Venda>, IBaseCommandRepository<Venda>
{
    void RemovePorId(int id);
    int ObterQuantidade();
}
