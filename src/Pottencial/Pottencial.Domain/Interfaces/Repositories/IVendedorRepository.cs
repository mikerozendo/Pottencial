using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repositories;

public interface IVendedorRepository : IBaseGetRepository<Vendedor>, IBaseCommandRepository<Vendedor>
{
    int ObterQuantiadeVendedores();
    void Remove(Vendedor vendedor);
    Vendedor? ObterPorDocumento(Vendedor vendedor);
}
