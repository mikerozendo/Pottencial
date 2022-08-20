using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IVendedorRepository : IBaseQueryRepository<Vendedor>, IBaseCommandRepository<Vendedor>
{
    Vendedor? ObterPorDocumento(Vendedor vendedor);
}
