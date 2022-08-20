using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IVendaRepository : IBaseGetRepository<Venda>, IBaseCommandRepository<Venda>
{
}
